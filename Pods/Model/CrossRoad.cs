using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// A crossroad is simply a point where roads meet
    /// </summary>
    public class CrossRoad
    {
        static public readonly int DIAMETER = 4;

        private string _name;
        private Vector2 _position;

        public CrossRoad(string name, Vector2 position)
        {
            _name = name;
            _position = position;
        }

        public string Name { get => _name; set => _name = value; }
        public Vector2 Position { get => _position; set => _position = value; }

    }
}
