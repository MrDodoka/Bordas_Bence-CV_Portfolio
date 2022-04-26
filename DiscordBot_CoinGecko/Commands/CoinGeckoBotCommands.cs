using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CoinGecko.Entities.Response.Shared;
using CoinGecko.Entities.Response.Simple;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_CoinGecko.Commands
{
    // All commands are created here.
    internal class CoinGeckoBotCommands : BaseCommandModule
    {
        private CoinGeckoClient coinGeckoClient = new CoinGeckoClient();

        static string coinGeckoImgUrl = "https://static.coingecko.com/s/coingecko-branding-guide-4f5245361f7a47478fa54c2c57808a9e05d31ac7ca498ab189a3827d6000e22b.png";

        DiscordEmbedBuilder EmbedScheme = new DiscordEmbedBuilder()
            .WithImageUrl(coinGeckoImgUrl)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Data provided by CoinGecko");

        #region !price command
        //Giving the name of command and the description of it
        [Command("price")]
        [Description("The bot will tell you the price and the 24 hours change in percentage for the choosen curreny and crypto(s).")]
        public async Task CryptoPrice(CommandContext ctx,
            [Description("The currency which you want to compare the crypto(s) with. You have to use the symbol of the currency.\nExamples: \"usd\", \"huf\", \"btc\".")] string vsCurrency,
            [Description("The crypto(s) you would like to ask the price of. You have to use the Id's of the cryptos.\nExamples: \"bitcoin\", \"shiba-inu\", \"curve-dao-token\".")] params string[] cryptoIds)
        {

            await ctx.TriggerTypingAsync();
            var supportedVsCurrency = await coinGeckoClient.SimpleClient.GetSupportedVsCurrencies();
            if (!supportedVsCurrency.Contains(vsCurrency))
            {
                string supportedCurrencies = string.Empty;

                for (int i = 0; i < supportedVsCurrency.Count; i++)
                {
                    if (i + 1 == (supportedVsCurrency.Count))
                        supportedCurrencies += supportedVsCurrency[i].ToUpper();
                    else supportedCurrencies += supportedVsCurrency[i].ToUpper() + " | ";
                }

                var coinPriceEmbed = EmbedScheme
                    .WithTitle("**ERROR!**")
                    .WithDescription($"Sorry there is no currency such as: \"{vsCurrency}\"")
                    .AddField("The following currencies are supported by CoinGecko:", $"{supportedCurrencies}")
                    .WithColor(DiscordColor.Red);

                await ctx.Channel.SendMessageAsync(coinPriceEmbed).ConfigureAwait(false);
            }
            else if (cryptoIds != null)
            {
                var choosenCoins = await coinGeckoClient.CoinsClient.GetCoinMarkets(vsCurrency, cryptoIds, null, null, null, false, null, null);
                CoinFullDataById cryptoData;
                string coinHttps = "https://www.coingecko.com/en/coins/";

                var coinPriceEmbed = EmbedScheme;
                foreach (CoinMarkets coin in choosenCoins)
                {
                    cryptoData = await coinGeckoClient.CoinsClient.GetAllCoinDataWithId(coin.Id);
                    coinPriceEmbed.WithThumbnail(cryptoData.Image.Large);
                    coinPriceEmbed.WithTitle($"{coin.Name} {vsCurrency.ToUpper()}/{coin.Symbol.ToUpper()}");
                    coinPriceEmbed.WithUrl($"{coinHttps}{coin.Id}");
                    coinPriceEmbed.WithDescription($"A {coin.Name}'s price is: {PriceCheck(coin.CurrentPrice)} {vsCurrency.ToUpper()}\n" +
                                                   $"24 hours change: {Math.Round((double)coin.PriceChangePercentage24H, 2)}%");

                    if (coin.PriceChangePercentage24H > 0) coinPriceEmbed.WithColor(DiscordColor.Green);
                    else coinPriceEmbed.WithColor(DiscordColor.Red);

                    await ctx.Channel.SendMessageAsync(coinPriceEmbed).ConfigureAwait(false);
                }
            }
        }
        #endregion

        #region !info command
        [Command("info")]
        [Description("The bot will tell you important info about the choosen crypto.")]
        [RequireRoles(RoleCheckMode.Any, new[] { "The owner", "Srákok", "Main Accs", "Secondary Accs" })]
        public async Task CryptoInfo(CommandContext ctx,
            [Description("The crypto's Id you'd like to ask the infos about.")] string cryptoId)
        {
            await ctx.TriggerTypingAsync();
            var coinList = await coinGeckoClient.CoinsClient.GetCoinList();
            bool isExists = false;

            foreach (var coin in coinList)
                if (coin.Id.Equals(cryptoId)) isExists = true;

            if (!isExists)
            {
                var coinInfoEmbed = EmbedScheme
                    .WithTitle("**ERROR!**")
                    .AddField($"Sorry there is no crypto such as: \"{cryptoId}\"", "You have to use the crypto's Id, if you do not know it please visit the website: [CoinGecko](https://www.coingecko.com/en)")
                    .WithColor(DiscordColor.Red);

                await ctx.Channel.SendMessageAsync(coinInfoEmbed).ConfigureAwait(false);
            }
            else
            {
                var choosenCoin = await coinGeckoClient.CoinsClient.GetAllCoinDataWithId(cryptoId);
                string coinHttps = "https://www.coingecko.com/en/coins/";
                string noData = "No data";

                var coinInfoEmbed = EmbedScheme
                    .WithThumbnail(choosenCoin.Image.Large)
                    .WithTitle($"{choosenCoin.Name} ({choosenCoin.Symbol.ToUpper()})")
                    .WithUrl($"{coinHttps}{choosenCoin.Id}")
                    .AddField("__Website__", $"[{choosenCoin.Name}'s website]({choosenCoin.Links.Homepage.First()})", false)
                    .AddField("__Explorers__", $"[Scan website]({choosenCoin.Links.BlockchainSite.First()})", false)
                    .AddField("__Community__", $"{(!choosenCoin.Links.SubredditUrl.Equals("") ? $"[Reddit]({choosenCoin.Links.SubredditUrl})" : noData)}" +
                                           $"{(!choosenCoin.Links.TwitterScreenName.Equals("") ? $" | [Twitter](https://twitter.com/{choosenCoin.Links.TwitterScreenName})" : noData)}" +
                                           $"{(!choosenCoin.Links.TelegramChannelIdentifier.Equals("") ? $" | [Telegram](https://t.me/{choosenCoin.Links.TelegramChannelIdentifier})" : "")}",
                                           false)
                    .AddField("__Price__", $"$ {PriceCheck(choosenCoin.MarketData.CurrentPrice["usd"])}\n")
                    .AddField("__Market Cap Rank__", $"{(choosenCoin.MarketData.MarketCapRank == null ? "No Data" : $"# {choosenCoin.MarketData.MarketCapRank}")}")
                    .AddField("__Market Cap__", $"{(choosenCoin.MarketData.MarketCap["usd"] == 0 ? "No Data" : $"$ {PriceCheck(choosenCoin.MarketData.MarketCap["usd"])}")}")
                    .AddField("__Market Cap 24 Hour Change__", $"{(choosenCoin.MarketData.MarketCapChange24H == 0 ? "No Data" : $"$ {PriceCheck(choosenCoin.MarketData.MarketCapChange24H)}")}")
                    .AddField("__Trading Volume__", $"$ {PriceCheck(choosenCoin.MarketData.TotalVolume["usd"])}")
                    .AddField("__24h Low / 24h High__", $"$ {PriceCheck(choosenCoin.MarketData.Low24H["usd"])} / $ {PriceCheck(choosenCoin.MarketData.High24H["usd"])}")
                    .AddField("__All-Time High__", $"$ {PriceCheck(choosenCoin.MarketData.Ath["usd"])} | {Math.Round(choosenCoin.MarketData.AthChangePercentage["usd"], 2)}%\n" +
                                               $"{choosenCoin.MarketData.AthDate["usd"].Value.DateTime.ToString("MM/dd/yyyy")} ({DateRound((DateTime.Now - choosenCoin.MarketData.AthDate["usd"].Value.DateTime).TotalDays)})")
                    .AddField("__All-Time Low__", $"$ {(choosenCoin.MarketData.Atl["usd"] == 0 ? "0" : $"$ {PriceCheck(choosenCoin.MarketData.Atl["usd"])}")} | {Math.Round(choosenCoin.MarketData.AtlChangePercentage["usd"], 2)}%\n" +
                                              $"{choosenCoin.MarketData.AtlDate["usd"].Value.DateTime.ToString("MM/dd/yyyy")} ({DateRound((DateTime.Now - choosenCoin.MarketData.AtlDate["usd"].Value.DateTime).TotalDays)})")
                    .WithColor(DiscordColor.SapGreen);

                await ctx.Channel.SendMessageAsync(coinInfoEmbed).ConfigureAwait(false);
            }
        }
        #endregion

        #region !market command
        [Command("market")]
        [Description("The bot will list you the top exchanges/swaps where you can find the choosen crypto, with some information.")]
        [RequireRoles(RoleCheckMode.Any, new[] { "The owner", "Srákok", "Main Accs", "Secondary Accs" })]
        public async Task CryptoMarkets(CommandContext ctx,
            [Description("The crypto's Id you'd like to ask the available exchanges/swaps.")] string cryptoId)
        {
            await ctx.TriggerTypingAsync();
            var coinList = await coinGeckoClient.CoinsClient.GetCoinList();
            bool isExists = false;

            foreach (var coin in coinList)
                if (coin.Id.Equals(cryptoId)) isExists = true;

            if (!isExists)
            {
                var coinMarketEmbed = EmbedScheme
                    .WithTitle("**ERROR!**")
                    .AddField($"Sorry there is no crypto such as: \"{cryptoId}\"", "You have to use the crypto's Id, if you do not know it please visit the website: [CoinGecko](https://www.coingecko.com/en)")
                    .WithColor(DiscordColor.Red);

                await ctx.Channel.SendMessageAsync(coinMarketEmbed).ConfigureAwait(false);
            }
            else
            {
                var choosenCoin = await coinGeckoClient.CoinsClient.GetAllCoinDataWithId(cryptoId);
                var swaps = choosenCoin.Tickers;
                string coinHttps = "https://www.coingecko.com/en/coins/";

                var coinMarketEmbed = EmbedScheme
                    .WithThumbnail(choosenCoin.Image.Large)
                    .WithTitle($"{choosenCoin.Name} ({choosenCoin.Symbol.ToUpper()})")
                    .WithUrl($"{coinHttps}{choosenCoin.Id}")
                    .WithColor(DiscordColor.SapGreen);

                for (int i = 0; i < (swaps.Length > 10 ? 10 : swaps.Length); i++)
                {
                    coinMarketEmbed.AddField($"__**{swaps[i].Market.Name}**__",
                                                                    $"**Link:** [{swaps[i].Market.Name}]({swaps[i].TradeUrl})\n" +
                                                                    $"**Price:** $ {PriceCheck(swaps[i].ConvertedLast["usd"])}\n" +
                                                                    $"**Pair:** {(swaps[i].Base.Length > 5 ? choosenCoin.Symbol.ToUpper() : swaps[i].Base)}/{swaps[i].Target}\n" +
                                                                    $"**24h Volume:** $ {PriceCheck(swaps[i].ConvertedVolume["usd"])} / {PriceCheck(swaps[i].Volume)} {(swaps[i].Base.Length > 5 ? choosenCoin.Symbol.ToUpper() : swaps[i].Base)}\n");
                }

                await ctx.Channel.SendMessageAsync(coinMarketEmbed).ConfigureAwait(false);
            }
        }
        #endregion

        private string PriceCheck(decimal? price)
        {
            string result = string.Empty;

            if (price >= 1000 || price <= -1000)
                result = $"{price:0,0}";
            else if (price >= 100 && price < 1000 || price <= -100 && price > -1000)
                result = $"{price:0,0.0}";
            else if ((price >= 10 && price < 100) || (price <= -10 && price > -100))
                result = $"{price:0.00}";
            else if ((price > 1 && price < 10) || (price < -1 && price > -10))
                result = $"{price:0.000}";
            else if ((price < 1 && price >= (decimal)0.001) || (price > -1 && price <= (decimal)-0.001))
                result = $"{price:0.000}";
            else if (price < (decimal)0.001 && price > 0)
                result = price.ToString();

            return result;
        }

        private string DateRound(double date)
        {
            string result = string.Empty;

            if (date < 30)
                result = $"{Math.Round(date)} days";
            else if (date >= 30 && date < 365)
                result = $"{Math.Round(date / 30)} months";
            else if (date >= 365)
                result = $"{Math.Round(date / 365)} years";

            return result;
        }
    }
}
