using UnityEngine;

// Base class (Parent class)
public class Fruit
{
    public string color;

    // Default constructor (called when there are no arguments)
    // Not inherited by any derived classes.
    public Fruit()
    {
        color = "orange";
        Debug.Log("Default FRUIT Constructor Called");
    }

    // Custom constructor
    // Not inherited by any derived classes.
    public Fruit(string newColor)
    {
        color = newColor;
        Debug.Log("Custom FRUIT Constructor Called");
    }

    public void Chop()
    {
        Debug.Log("The " + color + " fruit has been chopped.");
    }

    public void SayHello()
    {
        Debug.Log("Hello, I am a fruit.");
    }
}
