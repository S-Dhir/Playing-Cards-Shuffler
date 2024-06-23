using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsShuffler;

public class Card
{
    public byte owner;

    public readonly string cardName;
    public readonly byte cardNumber;
    public readonly Symbols cardSymbol;
    /// <summary>
    /// card number for joker is 0
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <param name="cardSymbol"></param>
    public Card(byte cardNumber, Symbols cardSymbol)
    {
        this.cardNumber = cardNumber;
        this.cardSymbol = cardSymbol;

        switch (cardNumber)
        {
            case 11: cardName = "Jack"; break;
            case 12: cardName = "Queen"; break;
            case 13: cardName = "King"; break;
            default: cardName = cardNumber.ToString(); break;
        }
    }
}
public class CardTable
{
    public static readonly Card[][] Table = getTable();
    private static Card[][] getTable()
    {
        Card[][] table = new Card[5][];
        table[(int)Symbols.Joker] = [new Card(0, Symbols.Joker), new Card(0, Symbols.Joker)];
        for (int i =0; i != 4;)
        {
            table[i] = new Card[13];
            for (int k = 0; k != 13;)
            {
                table[i][k] = new Card((byte)(k + 1), (Symbols) i);
                k++;
            }
            i++;
        }
        return table;
    }
}
