using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// A hub is a crossraod with infrastructures to host people, pods and containers
    /// </summary>
    public class Hub : CrossRoad
    {
        static public readonly new int DIAMETER = 20;

        private List<Person> _occupancy;
        private List<Pod> _parking;
        private List<Container> _containers;

        public List<Pod> Parking { get => _parking; }
        public List<Container> Containers { get => _containers; }
        public List<Person> Occupancy { get => _occupancy; }

        public Hub(string name, Vector2 position) : base (name, position)
        {
            _occupancy = new List<Person>();
            _parking = new List<Pod>();
            _containers = new List<Container>();
        }

        public void AddPerson(Person person)
        {
            Occupancy.Add(person);
        }

        public void AddPod(Pod pod)
        {
            Parking.Add(pod);
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
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

    }
}
