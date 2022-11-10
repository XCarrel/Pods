using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hub
    {
        static public readonly int DIAMETER = 20;

        private string _name;
        private Vector2 _position;
        private List<Person> _occupancy;
        private List<Pod> _parking;

        public string Name { get => _name; set => _name = value; }
        public Vector2 Position { get => _position; set => _position = value; }

        public Hub(string name, Vector2 position)
        {
            _name = name;
            _position = position;
            _occupancy = new List<Person>();
            _parking = new List<Pod>();
        }

        public void AddPerson(Person person)
        {
            _occupancy.Add(person);
        }

        public void AddPod(Pod pod)
        {
            _parking.Add(pod);
        }

    }
}
