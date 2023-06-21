using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ExampleBot.Modules;

namespace ExampleBot.SlashCommands;

public class ExampleSlashModule : ApplicationCommandModule
{
    //Name, description and method of the bot, 3 parameters that come with default values 
    [SlashCommand("roll", "Roll a highly configurable dice")]
    public async Task Roll(InteractionContext ctx, 
        [Option("min", "Lowest number")] long min = 1, 
        [Option("max", "Max number")] long max = 6,
        [Option("dices", "Number of dices")] long dices = 1)
    {
        //Console output in red that shows us what the user wanted to roll, also creates the answer message
        //Letting the user know that the bot is thinking
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"The user executed the following dice command:\nMin = {min}\nMax = {max}\nDices = {dices}");
        Console.ResetColor();
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        //3 cases are possible: the user enters an invalid amount of dices (negative)
        //amount of dices = 1
        //amount of dices > 1
        //Edits our initial message from above with the result of the random number generator module
        if (dices < 1)
        {
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Negative dices don't work lmao!"));
        } else if (dices == 1)
        {
            long output = RandomNumberModule.RandomNumber((int)min, (int)max);
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Roll: {output}"));
        } else
        {
            var output = "";
            for (int i = 0; i < dices; i++)
            {
                output += "Roll: " + RandomNumberModule.RandomNumber((int)min, (int)max) + "\n";
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent(output));
        }
    }
}