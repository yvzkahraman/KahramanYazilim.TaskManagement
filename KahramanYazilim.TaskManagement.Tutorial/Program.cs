class Program
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        people.Add(new Person()
        {
            Id = 1,
            Name = "Oğuze"
        });

        people.Add(new Person()
        {
            Id = 2,
            Name = "Zeynep"
        });

        people.Add(new Person()
        {
            Id = 3,
            Name = "Ebrar İnci"
        });


        var someting = (Person x) =>
        {
            return x.Name;
        };

        Func<Person, bool> funcDelegate = new Func<Person, bool>(GetZeynep);

        funcDelegate += GetOguz;

        var result = people.SingleOrDefault(funcDelegate);


        //List<Person> people = new List<Person>();


        //Person person1 = new Person();
        //person1.Name = "Zeynep";
        //person1.Id = 1;


        //Person person2 = new Person();
        //person2.Name = "Zeynep";
        //person2.Id = 1;


        //var control = person1 == person2;


        //PersonRecord personRecord1 = new PersonRecord(1, "Zeynep");

        //PersonRecord personRecord2 = new PersonRecord(1, "Zeynep");

        //var control2 = personRecord1 == personRecord2;

        //// IEquatable 
        //Console.WriteLine("Control :" + control);
        //Console.WriteLine("Control2 : " + control2);

    }

    public static bool GetZeynep(Person person)
    {
        return person.Name == "Zeynep";
    }

    public static bool GetOguz(Person person)
    {
        return person.Name == "Oguz";
    }
}


record PersonRecord(int Id, string Name);

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}


static class ListOfPersonExtensions
{
    public static Person? GetirZeynep(this List<Person> people)
    {
        return people.SingleOrDefault(x => x.Name == "Zeynep");
    }
}




// Extension metod, ek özellik kazandırmak.