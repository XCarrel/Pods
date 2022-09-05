using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pod
    {
        private string id;
        private int passengerCapacity;
        private int containerCapacity;
        private List<Person> occupancy;

        public Pod(int passengerCapacity, int containerCapacity)
        {
            this.passengerCapacity = passengerCapacity;
            this.containerCapacity = containerCapacity;
            this.occupancy = new List<Person>();
        }

        public void addTraveller (Person traveller)
        {
            if (occupancy.Count == this.passengerCapacity)
            {
                throw new Exception("Pod is full");
            } else
            {
                occupancy.Add(traveller);
            }
        }

        public int Occupancy
            { get { return occupancy.Count; } }
    }
}
