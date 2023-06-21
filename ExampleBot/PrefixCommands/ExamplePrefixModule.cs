using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ExampleBot.PrefixCommands;

public class ExamplePrefixModule : BaseCommandModule
{
    //Pretty simple command, reacts to the !greet command with a "Hello There!"
    [Command("greet")]
    public async Task GreetCommand(CommandContext ctx)
    {
        await ctx.RespondAsync("Hello there!");
    }
}