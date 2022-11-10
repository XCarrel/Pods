using System;
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
        private List<PodTracker> _pods;

        public Road(string name, Hub from, Hub to)
        {
            _name = name;
            _from = from;
            _to = to;
            _pods = new List<PodTracker>();
        }

        public string Name { get => _name; }
        public Hub From { get => _from; }
        public Hub To { get => _to; }
        public List<PodTracker> Pods { get => _pods; }

        public bool AllowEnter(Pod pod)
        {
            Pods.Add(new PodTracker(pod));
            return true;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(To.Position.X-From.Position.X,2)+Math.Pow(To.Position.Y-From.Position.Y,2));
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
        public Vector2 Entry()
        {
            Vector2 res = new Vector2(From.Position.X + Hub.DIAMETER/2 * PerpendicularDirection().X, From.Position.Y + Hub.DIAMETER/2 * PerpendicularDirection().Y);
            return res;
        }

        /// <summary>
        /// The exact coordinates of the road exit point
        /// </summary>
        /// <returns></returns>
        public Vector2 Exit()
        {
            Vector2 res = new Vector2(To.Position.X + Hub.DIAMETER / 2 * PerpendicularDirection().X, To.Position.Y + Hub.DIAMETER / 2 * PerpendicularDirection().Y);
            return res;
        }

    }
}
