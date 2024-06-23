using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsShuffler;

//OOP
//Each playing card has a number, a symbol and an owner(where the card currently is)
//The owner can change. Rest everything is constant
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

//a 2d array containing a table of all cards. Each column is a different symbol with a 5th column for jockers
//Learnt about jagged and multi-dimensional arrays while programming this. In a multidimensional array, all columns have the same nmber of rows.
//Jagged arrays are arrays of arrays. Each child array in the parent can be of a different length
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
