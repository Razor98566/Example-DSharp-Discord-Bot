using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ExampleBot.Modules;

namespace ExampleBot.SlashCommands;

public class ExampleSlashModule : ApplicationCommandModule
{
    [SlashCommand("roll", "Roll a highly configurable dice")]
    public async Task Roll(InteractionContext ctx, 
        [Option("min", "Lowest number")] long min, 
        [Option("max", "Max number")] long max,
        [Option("dices", "Number of dices")] long dices)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"The user executed the following dice command:\nMin = {min}\nMax = {max}\nDices = {dices}");
        Console.ResetColor();
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

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