namespace GroupB_A2.Models;

public class Category
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Category()
    {
        
    }

    public Category(string name)
    {
        Name = name;
    }
}