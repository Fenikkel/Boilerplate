using UnityEngine;

public class PikachuCreator : MonoBehaviour
{
    void Start()
    {
        Pikachu pika_1 = new Pikachu();

        print("pika_1 -> Name: " + pika_1.m_Name + "    Life: " + pika_1.m_Life);


        Pikachu pika_2 = new Pikachu("Rosalia");

        print("pika_2 -> Name: " + pika_2.m_Name + "    Life: " + pika_2.m_Life);


        Pikachu pika_3 = new Pikachu("Over nine thousand", 9999);

        print("pika_3 -> Name: " + pika_3.m_Name + "    Life: " + pika_3.m_Life);
    }

}
