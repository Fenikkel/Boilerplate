using UnityEngine;

public class FruitSalad : MonoBehaviour
{
    public void DefaultConstructors() 
    {
        /* Default constructors */

        Debug.Log("Creating the fruit");
        Fruit myFruit = new Fruit();
        Debug.Log("Creating the apple");
        Apple myApple = new Apple();


        /* Fruit class methods */

        myFruit.SayHello();
        myFruit.Chop();


        /* Apple class methods */
        // Class Apple has access to all
        // of the public methods of class Fruit.

        myApple.SayHello();
        myApple.Chop();
    }

    public void CustomConstructors() 
    {
        /* Custom constructors */

        Debug.Log("Creating the fruit");
        Fruit myFruit = new Fruit("yellow");

        Debug.Log("Creating the apple");
        Apple myApple = new Apple("green");


        /* Fruit class methods */
        myFruit.SayHello();
        myFruit.Chop();


        /* Apple class methods */
        // Class Apple has access to all
        // of the public methods of class Fruit.
        myApple.SayHello();
        myApple.Chop();
    }
}
