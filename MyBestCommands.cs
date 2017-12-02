using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace PeperonieBot {
    public class MyBestCommands {

        [Command("commands")]
        public async Task Commands(CommandContext context) {
            await context.RespondAsync($"!purpose");
        }

        [Command("purpose")]
        public async Task Purpose(CommandContext context) {
            await context.RespondAsync($"My purpose is to post this message.");
        }
    }
}