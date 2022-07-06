using UnityEngine;

public class EncapsulationVariables : MonoBehaviour
{
    //Field (variable)
    public int coinsPublic = 1;

    private int coinsPrivate = 2;

    //Automatic Properties (Short Hand)
    public int CoinsAutomatic{ get; set; }  // we "convert" it into a Property

    //Backing field (Manual Hand)
    private int coinsManual = 4;
    public int CoinsManual
    {
        get
        {
            return coinsManual;
        }
        set
        {
            coinsManual = value;
        }
    }

    //Backing field (Manual Hand)
    private int coinsCustom = 5;
    public int CoinsCustom
    {
        get
        {
            return coinsCustom + 100;
        }
        set
        {
            if (value % 2 == 0.0f)
            {
                coinsCustom = value + 2; //Calls the get!
            }
            else 
            {
                coinsCustom = value - 3; //Calls the get!
            }
        }
    }

    // Getters and Setters functions
    public int GetCoins() 
    {
        return coinsPrivate;
    }

    public void SetCoins(int newValue)
    {
        coinsPrivate = newValue;
    }

}

/* 
 * A private field that stores the data exposed by a public property 
 * is called a backing store or backing field 
 */

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
