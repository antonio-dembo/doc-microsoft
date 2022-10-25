// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;

namespace AttributeTestNet6.TestingAttribute;

[Developer("Joan Smith", "42", reviewed: true)]
[Developer("Antonio", "50", reviewed: true)]
public class MainApp
{
    public static void GetStarted()
    {
        GetAttribute(typeof(MainApp));
    }

    private static void GetAttribute(Type type)
    {
        // Get Instance of the attribute
        DeveloperAttribute? myAttribute = Attribute.GetCustomAttribute(type, typeof(DeveloperAttribute)) as DeveloperAttribute;
        
        if(myAttribute == null)
        {
            Console.WriteLine("The attribute was not found.");
        }
        else
        {
            // Get the Name value.
            Console.WriteLine("The Name Attribute is: {0}.", myAttribute.Name);
            // Get the Level value.
            Console.WriteLine("The Level Attribute is: {0}.", myAttribute.Level);
            // Get the Reviewed value.
            Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
        }
    }

    public static void GetAttributes (Type type)
    {
        DeveloperAttribute[] myAttributes = (DeveloperAttribute[]) Attribute.GetCustomAttributes(type, typeof(DeveloperAttribute));
        
        if( myAttributes.Length == 0)
        {
            Console.WriteLine("The attribute was not found.");
        }
        else
        {
            for (int i = 0; i < myAttributes.Length ; i++)
            {
                Console.WriteLine("The Name Attribute is: {0}", myAttributes[i].Name);
                Console.WriteLine("The Level Attribute is: {0}", myAttributes[i].Level);
                Console.WriteLine("The Reviewed Attribute is: {0}", myAttributes[i].Reviewed);
            }
        }
    }
}
