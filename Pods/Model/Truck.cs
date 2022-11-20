using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// A truck is a pod that can only transport containers
    /// </summary>
    public class Truck : Pod
    {
        public static readonly int[] ALLOWED_CAPACITIES = { 2, 4, 8, 16 };
        public static readonly int MAX_LOAD = 2000;

        List<Container> _containers;

        public Truck(string id, int capacity) : base(id, capacity)
        {
            if (!ALLOWED_CAPACITIES.Contains(capacity)) throw new Exception($"Invalid container capacity ({capacity})");
            _containers = new List<Container>();
        }

        public Truck(string id, int capacity, Vector2 position) : this(id, capacity)
        {
            Position = position;
        }

        public Truck(string id, int capacity, Vector2 position, int speed) : this(id, capacity, position)
        {
            Speed = speed;
        }

        public List<Container> Containers { get => _containers; }

        public void AddContainer(Container container)
        {
            if (TotalLoad + container.LoadWeight > MAX_LOAD) throw new Exception($"Truck overload");
            _containers.Add(container);
        }

        public int TotalLoad {
            get {
                int total = 0;
                foreach (Container container in _containers)
                    total += container.LoadWeight;
                return total;
            }
        }
    }
}
