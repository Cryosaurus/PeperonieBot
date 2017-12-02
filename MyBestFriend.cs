using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace PeperonieBot {
    class MyBestFriend {

        static DiscordClient discord;
        static CommandsNextModule commands;
        static DiscordChannel choreChannel;

        static void Main(string[] args) {
            //Actually start the Pepperonibot process
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) {
            ulong peperonieChannelID = 0;
            ulong.TryParse(args[1], out peperonieChannelID);
            //ulong testChannelID = 0;
            //ulong.TryParse(args[2], out testChannelID);

            discord = new DiscordClient(new DiscordConfiguration {
                Token = args[0],
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration {
                StringPrefix = "!"
            });
            commands.RegisterCommands<MyBestCommands>();

            discord.Guild​Member​Added += NewMemberRequiredReading;

            await discord.ConnectAsync();
            choreChannel = await discord.GetChannelAsync(peperonieChannelID);
            //await discord.ConnectAsync();
            //choreChannel = await discord.GetChannelAsync(testChannelID);

            //Wait forever, all work should be done before this point
            await Task.Delay(-1);
        }

        static async Task NewMemberRequiredReading(Guild​Member​AddEventArgs e) {
            await e.Member.SendMessageAsync("Required viewing for acceptance in this server https://www.youtube.com/watch?v=RS1UddsRRFM");
        }
    }
}