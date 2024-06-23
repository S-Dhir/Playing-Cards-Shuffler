
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace PlayingCardsShuffler;

public static class Program
{
    static byte playerCount;
    static Boolean joker;
    
    static void Main(string[] args)
    {
    
        Console.WriteLine("I will shuffle all playing cards. Enter number of players");
        if (!byte.TryParse(Console.ReadLine(), out playerCount)) { error(args); return; }
        Console.WriteLine("Distribute jocker? y/n");
        ConsoleKeyInfo jockerPrompt = Console.ReadKey();
        if (jockerPrompt.KeyChar.ToString().ToLower() != "y" && jockerPrompt.KeyChar.ToString().ToLower() != "n") { error(args); return; }

        joker = (jockerPrompt.Key == ConsoleKey.N);


        //Counting the number of cards. Are there jokers?
        float numberofCards = (52F + 2F * (joker ? 0F : 1F));
        var cardsPerPlayer =  (byte)float.Floor(numberofCards / (float)playerCount);
        
        Console.WriteLine("cardsPerplayer : "+cardsPerPlayer);
        Console.WriteLine("cardsPerPlayer * playerCount : " + (cardsPerPlayer * playerCount));
        Console.WriteLine($"number of cards : {numberofCards}");

        //Generates a repeating list of all players of length numberofCards in this fashion
        //a,b,c,a,b,c,a,b,c...
        //and then shuffles this list
        var randomizedOnwersList = randomizedOwnersList(playerCount, (int)numberofCards);

        //I would have preffered to read from a stream as it advances the the position in the array automatically
        var index = 0;
        

        //Final list of all cards with their owners.
        var Table = CardTable.Table;

        //Assigning owners with help of randomized list 
        for (int i = 0; i < Table.Length;)
        {
            for (int k = 0; k < Table[i].Length;)
            {
                try
                {
                    Table[i][k].owner = (byte)randomizedOnwersList[index];
                } catch(Exception _)
                {
                    Console.WriteLine(randomizedOnwersList.Length);
                    Console.WriteLine(index);
                    Console.ReadKey();
                }
                index++;
                k++;
            }
            i++;
        }
    }

    public static void error(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Error!");
        Main(args); return;
    }

    public static int[] randomizedOwnersList(int playerCount, int cardCount)
    {
        //not randomized
        int[] owners = new int[cardCount];
        for (int i = 0; i!=cardCount;)
        {
            owners[i] = i%playerCount;
            i++;
        }
        
        //randomizes
        Random rng = new();
        for (int i = 0; i!= owners.Length;)
        {
            var temp = owners[i];
            var index = rng.Next(0, owners.Length - 1);
            owners[i] = owners[index];
            owners[index] = temp;

            i++;
        }
    //here it's randomized
        return owners;
    }
}