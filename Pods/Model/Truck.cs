﻿using System;
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
        List<Container> _containers;

        public Truck(string id, int capacity) : base(id, capacity)
        {
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
    }
}