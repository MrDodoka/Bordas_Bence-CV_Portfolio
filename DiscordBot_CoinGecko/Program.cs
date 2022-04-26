global using Newtonsoft.Json;
using DiscordBot_CoinGecko.BotSettings;

DiscordBot_Settings DBS = new DiscordBot_Settings();
DBS.MainAsync().GetAwaiter().GetResult();