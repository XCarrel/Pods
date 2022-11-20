using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// A taxi is a pod that transport only persons
    /// </summary>
    public class Taxi : Pod
    {
        public static readonly int[] ALLOWED_CAPACITIES = { 1, 2, 3, 5, 8, 13, 21 };
        public static readonly int MAX_OCCUPANCY_WITHOUT_LICENSE = 5;

        List<Person> _travellers;

        public Taxi(string id, int capacity) : base(id, capacity)
        {
            if (!ALLOWED_CAPACITIES.Contains(capacity)) throw new Exception($"Invalid passenger capacity ({capacity})");
            _travellers = new List<Person>();
        }

        public Taxi(string id, int capacity, Vector2 position) : this(id, capacity)
        {
            Position = position;
        }

        public Taxi(string id, int capacity, Vector2 position, int speed) : this(id, capacity, position)
        {
            Speed = speed;
        }

        public List<Person> Travellers { get => _travellers; }

        public void addTraveller(Person traveller)
        {
            if (_travellers.Count == this.Capacity)
            {
                throw new Exception("Pod is full");
            }
            else
            {
                _travellers.Add(traveller);
            }
        }

        public bool canTravel()
        {
            if (_travellers.Count <= MAX_OCCUPANCY_WITHOUT_LICENSE) return true;
            foreach (Person traveller in _travellers)
                if (traveller.PodLicense)
                    return true;
            return false;
        }

    }
}
