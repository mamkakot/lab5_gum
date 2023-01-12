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

    public Note(Note otherNote)
    {
        Name = otherNote.Name;
        PhoneNumber = otherNote.PhoneNumber;
        Year = otherNote.Year;
    }

    public string GetNote()
    {
        return $"That's a note about {Name}";
    }

    public static Note operator +(Note oneNote, Note otherNote)
    {
        return new Note
        {
            Name = $"{oneNote.Name} и {otherNote.Name}",
            PhoneNumber = $"{oneNote.PhoneNumber}, а может и {otherNote.PhoneNumber}",
            Year = oneNote.Year + otherNote.Year
        };
    }

    public static bool operator >(Note oneNote, Note otherNote)
    {
        return oneNote.Year > otherNote.Year;
    }

    public static bool operator <(Note oneNote, Note otherNote)
    {
        return !(oneNote > otherNote);
    }

    public static bool operator ==(Note oneNote, Note otherNote)
    {
        return oneNote.Year == otherNote.Year &&
               oneNote.Name == otherNote.Name &&
               oneNote.PhoneNumber == otherNote.PhoneNumber;
    }

    public static bool operator !=(Note oneNote, Note otherNote)
    {
        return !(oneNote == otherNote);
    }

    public static Note operator ++(Note oneNote)
    {
        return new Note(oneNote) { Year = oneNote.Year + 1 };
    }

    public static Note operator --(Note oneNote)
    {
        return new Note(oneNote) { Year = oneNote.Year - 1 };
    }
}