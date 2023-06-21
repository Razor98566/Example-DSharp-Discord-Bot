namespace ExampleBot.Modules;

public class RandomNumberModule
{
    public static long RandomNumber(int min, int max)
    {
        Random r = new Random();
        return r.NextInt64(min, max);
    }
}