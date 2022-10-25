// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;

namespace AttributeTestNet6.TestingAttribute;

[Developer("Joan Smith", "42", reviewed: true)]
[Developer("Antonio", "50", reviewed: true)]
public class MainApp
{
    public static void GetClassLevelAttribute(Type type)
    {
        // Get Class level Instance of the attribute
        DeveloperAttribute? myAttribute = Attribute.GetCustomAttribute(type, typeof(DeveloperAttribute)) as DeveloperAttribute;
        
        if(myAttribute == null)
        {
            Console.WriteLine("No attribute in class {0}.\n", type.ToString());
        }
        else
        {
            Console.WriteLine("The Name Attribute on the class level is: {0}.", myAttribute.Name);
            Console.WriteLine("The Level Attribute on the class level is: {0}.", myAttribute.Level);
            Console.WriteLine("The Reviewed Attribute on the class level is: {0}.\n", myAttribute.Reviewed);
        }
    }
        
    public static void GetMultipleClassLevelAttributes (Type type)
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

    public static void GetMultipleAttributesInDifferentScopes(Type type)
    {
        DeveloperAttribute? att;

        GetClassLevelAttribute(type);

        // Get method-level attributes.

        // Get all the public methods in this class, and put them
        // in an array of System.Reflection.MemberInfo objects.
        MemberInfo[] myMemberInfo = type.GetMethods();

        for (int i = 0; i < myMemberInfo.Length; i++)
        {
            att = Attribute.GetCustomAttribute(myMemberInfo[i], typeof(DeveloperAttribute)) as DeveloperAttribute;

            if (att == null)
            {
                Console.WriteLine("No attribute in member functioln {0}.\n", myMemberInfo[i].ToString());
            }
            else
            {
                Console.WriteLine("The Name Attribute for the {0} member is: {1}.", myMemberInfo[i].ToString(), att.Name);
                Console.WriteLine("The Level Attribute for the {0} member is: {1}.", myMemberInfo[i].ToString(), att.Level);
                Console.WriteLine("The Reviewed Attribute for the {0} member is: {1}.\n", myMemberInfo[i].ToString(), att.Reviewed);
            }
        }
    }

    [Developer("Antonio", "23", false)]
    public static void TestMemberAttribute()
    {

    }
}
