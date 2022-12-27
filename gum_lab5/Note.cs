namespace gum_lab5;

public class Note
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int Year { get; set; }

    public Note()
    {
        Name = "Иван";
        PhoneNumber = "88005553535";
        Year = 1995;
    }
}