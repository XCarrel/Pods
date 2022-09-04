using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        private String name;

        public Person(string name)
        {
            Name = name.Substring(0,1).ToUpper()+name.Substring(1).ToLower();
        }

        public string Name { get => name; set => name = value; }
    }
}
