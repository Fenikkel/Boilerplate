public class Pikachu
{
    /* Class properties */
    public string m_Name;
    public int m_Life;

    /* Constructors */
    public Pikachu()
    {
        m_Name = "Chukapi";
        m_Life = 100;
    }

    public Pikachu(string name)
    {
        m_Name = name;
        m_Life = 50;
    }

    public Pikachu(string name, int life)
    {
        m_Name = name;
        m_Life = life;
    }
}
