
using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            person person = new person("Aqil","Agayev",19);
            person person2 = (person)person.Clone();
            Console.WriteLine(person2);
        }
    }
}
