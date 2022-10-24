// See https://aka.ms/new-console-template for more information

namespace AttributeTestNet6.TestingAttribute;

public class DeveloperAttribute : Attribute
{
    public string? Name { get; set; }
    public string? Level { get; set; }
    public bool Reviewed { get; set; }

    public DeveloperAttribute(string name, string level, bool reviewed)
    {
        Name = name;
        Level = level;
        Reviewed = reviewed;
    }
}
