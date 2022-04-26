using DiscordBot_CoinGecko.Config;
using DiscordBot_CoinGecko.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;
using System.Text;

namespace DiscordBot_CoinGecko.BotSettings
{
    internal class DiscordBot_Settings
    {
        string Json = string.Empty;
        EventId BotId;


        DiscordClient DiscordBot;
        DiscordConfiguration DiscordBotConfiguration;

        CommandsNextExtension DiscordBotCommands;
        CommandsNextConfiguration DiscordBotCommandConfiguration;

        // The program basically starts here.
        // It reads the config.js for the secret key and prefix.
        // Configurates the bot, and commands, register events for both of it.
        public async Task MainAsync()
        {
            BotId = new EventId(0, "CoinGeckoBot");

            #region ConfigJsonRead
            using (var fileStream = File.OpenRead(@"..\..\..\Config\config.json"))
            using (var streamReader = new StreamReader(fileStream, new UTF8Encoding(false)))
                Json = await streamReader.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(Json);
            #endregion

            #region Bot Configuration
            //Configuring the bot
            DiscordBotConfiguration = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                LogTimestampFormat = "yyyy MM dd hh:mm:ss tt"
            };

            //Initializing the bot with the set configuration
            DiscordBot = new DiscordClient(DiscordBotConfiguration);

            #region Event registration
            //Registering events to use with the bot

            //Ready event registration
            DiscordBot.Ready += (sender, e) =>
            {
                sender.Logger.LogInformation(BotId, "Client is ready to process events!");
                return Task.CompletedTask;
            };

            //Joining a guild/server event registration
            DiscordBot.GuildAvailable += (sender, e) =>
            {
                sender.Logger.LogInformation(BotId, $"{BotId.Name} has joined to the server: {e.Guild.Name}!");
                return Task.CompletedTask;
            };

            //Error event registration
            DiscordBot.ClientErrored += (sender, e) =>
            {
                sender.Logger.LogInformation(BotId, $"Exception occured with {BotId.Name}!");
                return Task.CompletedTask;
            };
            #endregion

            #endregion

            #region Bot Commands Configuration
            //Configuring the commands of the bot
            DiscordBotCommandConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                DmHelp = true
            };

            //Setting up commands configuration and registering command classes
            DiscordBotCommands = DiscordBot.UseCommandsNext(DiscordBotCommandConfiguration);
            DiscordBotCommands.RegisterCommands<CoinGeckoBotCommands>();

            #region Command Event Registration
            DiscordBotCommands.CommandExecuted += (sender, e) =>
            {
                e.Context.Client.Logger.LogInformation(BotId, $"{e.Context.User.Username} successfully executed the command named \"{e.Command.QualifiedName}\"!");
                return Task.CompletedTask;
            };
            DiscordBotCommands.CommandErrored += (sender, e) =>
            {
                e.Context.Client.Logger.LogInformation(BotId, $"{e.Context.User.Username} tried to execute \"{e.Command.Name}\", but run into error!\nError: {e.Exception.Message}");
                return Task.CompletedTask;
            };
            #endregion
            #endregion

            await DiscordBot.ConnectAsync().ConfigureAwait(false);
            await Task.Delay(-1).ConfigureAwait(false);
        }
    }
}
