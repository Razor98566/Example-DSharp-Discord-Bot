using DSharpPlus;
using DSharpPlus.CommandsNext;
using ExampleBot.PrefixCommands;
using DSharpPlus.SlashCommands;
using ExampleBot.SlashCommands;

namespace ExampleBot;

public class Program
{
    static async Task Main(string[] args)
    {
        //The user enters the Bot Token and connects to the bot
        //Declaration of intents
        Console.WriteLine("Please enter the Bot Token: ");
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Console.ReadLine(),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
        });
        
        //Initialize the Pefix CommandHandler, as well as registers the example command
        var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
        {
            StringPrefixes = new[] { "!" }
        });
        commands.RegisterCommands<ExamplePrefixModule>();
        
        //Initialize the Slash CommandHandler, as well as registers the example command
        var slash = discord.UseSlashCommands();
        
        slash.RegisterCommands<ExampleSlashModule>();
        
        //Finally the bot establishes the connection, Task.Delay(-1) is necessary at the end of the main method
        await discord.ConnectAsync();
        await Task.Delay(-1);
    }
}