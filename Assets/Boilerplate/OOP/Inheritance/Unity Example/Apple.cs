using UnityEngine;

// Derived class (Child class)
public class Apple : Fruit
{
    // Default constructor
    // This constructor call the parent constructor (Fruit) before it runs.
    public Apple()
    {
        // color is a public variable from the parent Fruit class.
        color = "red";
        Debug.Log("Default APPLE Constructor Called");
    }


    // We specify which constructor of the parent will be called using the "base" keyword and passing the argument.
    // It will execute the Base constructor first
    public Apple(string newColor) : base(newColor) // base() to call the other constructor
    {
        // We don't set the color since the base constructor
        // sets the color that is passed as an argument.
        Debug.Log("Default APPLE Constructor Called");
    }
}
