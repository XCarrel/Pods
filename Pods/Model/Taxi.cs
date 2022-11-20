using System;
using System.Collections.Generic;
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
        List<Person> _travellers;

        public Taxi(string id, int capacity) : base(id, capacity)
        {
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

    }
}
