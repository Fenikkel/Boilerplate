using UnityEngine;

public class FunctionOverloadingExample : MonoBehaviour
{

    private void Start()
    {
        PrintSomething();
        PrintSomething("Caracola");
        PrintSomething("Pepsicola", 22);
    }

    public void PrintSomething() 
    {
        print("1 -> Without parameters");
    }

    public void PrintSomething(string parameter)
    {
        print("2 -> String parameter: " + parameter);
    }

    public int PrintSomething(string parameter, int parameter2)
    {
        print("3 -> Two parameter and return: " + parameter + ", " + parameter2);
        return parameter2;
    }

}
