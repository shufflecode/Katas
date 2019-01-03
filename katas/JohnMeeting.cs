using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace katas
{
    public class JohnMeeting
    {

        public static string Meeting(string s)
        {
            var sb = new StringBuilder();
            var names = s.Split(';').ToList();
            var persons = new List<Person>();
            foreach (string name in names)
            {
                persons.Add(new Person(name));
            }
            var sorted = persons.OrderBy(p => p.Surname).ThenBy(p => p.Name);

            foreach (var person in sorted)
            {
                sb.Append($"{person}");
            }
            return sb.ToString();
        }

        public class Person
        {
            public Person(string completeName)
            {
                Name = completeName.Split(':')[0].ToUpper();
                Surname = completeName.Split(':')[1].ToUpper();
            }
            public string Name { get; set; }
            public string Surname { get; set; }

            public override string ToString()
            {
                return $"({Surname}, {Name})";
            }
        }
    }
}
