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
        public List<Pod> Parking { get => _parking; }

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
            Parking.Add(pod);
        }

        /// <summary>
        /// Extracts a random Pod from the parking lot
        /// </summary>
        /// <returns></returns>
        public Pod? CheckoutRandomPod()
        {
            if (Parking.Count == 0) return null;
            Pod pod = Parking[World.alea.Next(Parking.Count)];
            _parking.Remove(pod);
            return pod;
        }

        /// <summary>
        /// Selects randomly a road that exits this hub
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Road GetAnExitRoad()
        {
            List<Road> candidates = World.Roads.Where(r => r.From == this).ToList();
            if (candidates.Count == 0)
                throw new Exception($"Hub {Name} is a deadend");
            else
                return candidates[World.alea.Next(candidates.Count)];
        }
    }
}
