using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// An itinerary is built as a list of roads to use (and not a list of hubs)
    /// </summary>
    public class Itinerary
    {
        private List<Road> _roads;

        public Itinerary()
        {
            _roads = new List<Road>();
        }

        public List<Road> Roads { get => _roads; set => _roads = value; }

        /// <summary>
        /// Indicates that all roads of the itinerary are properly chained
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (_roads.Count == 0) return false;
            if (_roads.Count == 1) return true;  // can't be wrong ;)
            for (int i = 0; i < _roads.Count-1; i++)
                if (_roads[i].To != _roads[i+1].From)
                    return false;
            return true;
        }
    }
}
