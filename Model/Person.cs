using System;
namespace Model
{
    public class Person
    {
        private String _name;
        
        public Person()
        {
        }

        public string Name { get => _name; set => _name = value; }
    }
}

