﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Road
    {
        private string _name;
        private Hub _from;
        private Hub _to;
        private List<Pod> _pods;

        public Road(string name, Hub from, Hub to)
        {
            _name = name;
            _from = from;
            _to = to;
            _pods = new List<Pod>();
        }

        public string Name { get => _name; }
        public Hub From { get => _from; }
        public Hub To { get => _to; }
        public List<Pod> Pods { get => _pods; }

        public bool AllowEnter(Pod pod)
        {
            // Validate entry conditions
            if (pod.GetType() == typeof(Taxi))
            {
                Taxi taxi = (Taxi)pod;
                if (taxi.Travellers.Count < taxi.Capacity / 2.0) return false; // divide by float to deal withh odd capacities
            }
            pod.Position = EntryPoint;
            Pods.Add(pod);
            return true; // unconditional entry (for now...)
        }

        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(To.Position.X-From.Position.X,2)+Math.Pow(To.Position.Y-From.Position.Y,2));
        }

        private Vector2 PerpendicularDirection()
        {
            Vector2 v = new Vector2(_to.Position.Y-_from.Position.Y, -(_to.Position.X - _from.Position.X));
            v.X /= v.Length();
            v.Y /= v.Length();
            return v;
        }

        /// <summary>
        /// The exact coordinates of the road entry point
        /// </summary>
        /// <returns></returns>
        public Vector2 EntryPoint
        {
            get
            {
                return new Vector2(From.Position.X + Hub.DIAMETER / 2 * PerpendicularDirection().X, From.Position.Y + Hub.DIAMETER / 2 * PerpendicularDirection().Y);
            }
        }

        /// <summary>
        /// The exact coordinates of the road exit point
        /// </summary>
        /// <returns></returns>
        public Vector2 ExitPoint
        {
            get
            {
                return new Vector2(To.Position.X + Hub.DIAMETER / 2 * PerpendicularDirection().X, To.Position.Y + Hub.DIAMETER / 2 * PerpendicularDirection().Y);
            }
        }
        
        /// <summary>
        /// Make the pods engaged on this road move
        /// </summary>
        /// <param name="dt">The amount of time (in hours) the pods move</param>
        public void MovePods(float dt)
        {
            foreach (Pod pod in Pods)
                pod.Move(dt, _to.Position.X - _from.Position.X, _to.Position.Y - _from.Position.Y);

            // Manage road exits
            Vector2 exit = ExitPoint; // avoid repeated computations
            Vector2 entry = EntryPoint;
            // TODO Make entry and exit attributes, computed at creation once and for all

            foreach (Pod pod in Pods.ToList())
                if (Math.Abs(pod.Position.X-entry.X) >= Math.Abs(exit.X - entry.X))
                {
                    To.AddPod(pod); // park the pod at its destination
                    Pods.Remove(pod);
                }
        }


}
}
