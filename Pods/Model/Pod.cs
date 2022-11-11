using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pod
    {
        private string _id;
        private int _passengerCapacity;
        private int _containerCapacity;
        private Vector2 _position;
        private int _speed = 0;                 // km/h
        private List<Person> _occupancy;

        public Pod(string id, int passengerCapacity, int containerCapacity)
        {
            this._id = id;
            this._passengerCapacity = passengerCapacity;
            this._containerCapacity = containerCapacity;
            this._occupancy = new List<Person>();
        }

        public Pod(string id, int passengerCapacity, int containerCapacity, Vector2 position) : this(id, passengerCapacity, containerCapacity)
        {
            Position = position;
        }

        public Pod(string id, int passengerCapacity, int containerCapacity, Vector2 position, int speed) : this(id, passengerCapacity, containerCapacity, position)
        {
            Speed = speed;
        }

        public int PassengerCapacity { get => _passengerCapacity; }
        public int ContainerCapacity { get => _containerCapacity; }
        public string Id { get => _id; }
        public int Speed { get => _speed; set => _speed = value; }
        public Vector2 Position { get => _position; set => _position = value; }

        public void addTraveller (Person traveller)
        {
            if (_occupancy.Count == this.PassengerCapacity)
            {
                throw new Exception("Pod is full");
            } else
            {
                _occupancy.Add(traveller);
            }
        }

        public void Move (float dt, float roadDx, float roadDy)
        {
            float distance = Speed * dt;
            float fractionCovered = distance / (float)Math.Sqrt(Math.Pow(roadDx,2)+Math.Pow(roadDy,2));
            _position.X += roadDx * fractionCovered;
            _position.Y += roadDy * fractionCovered;
        }

    }
}
