namespace gum_lab5;

public class MegaNote : Note
{
    public string Address { get; set; }

    public MegaNote()
    {
        Address = "Красноярск";
    }

    public MegaNote(MegaNote otherMegaNote) : base(otherMegaNote)
    {
        Address = otherMegaNote.Address;
    }

    public static MegaNote operator ++(MegaNote oneNote)
    {
        return new MegaNote(oneNote) { Year = oneNote.Year + 1 };
    }

    public new string GetNote()
    {
        return $"That's a note about {Name}, who lives at {Address}";
    }
}