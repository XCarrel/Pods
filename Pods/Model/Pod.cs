using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Pod
    {
        private string _id;
        private int _capacity;
        private Vector2 _position;
        private int _speed = 0;                 // km/h

        public Pod(string id, int capacity)
        {
            this._id = id;
            this._capacity = capacity;
        }

        public Pod(string id, int capacity, Vector2 position) : this(id, capacity)
        {
            Position = position;
        }

        public Pod(string id, int capacity, Vector2 position, int speed) : this(id, capacity, position)
        {
            Speed = speed;
        }

        public string Id { get => _id; }
        public int Capacity { get => _capacity; }
        public Vector2 Position { get => _position; set => _position = value; }
        public int Speed { get => _speed; set => _speed = value; }

        public void Move (float dt, float roadDx, float roadDy)
        {
            float distance = Speed * dt;
            float fractionCovered = distance / (float)Math.Sqrt(Math.Pow(roadDx,2)+Math.Pow(roadDy,2));
            _position.X += roadDx * fractionCovered;
            _position.Y += roadDy * fractionCovered;
        }

    }
}
