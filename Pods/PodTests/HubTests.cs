using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PodTests
{
    [TestClass]
    public class HubTests
    {
        [TestMethod]
        public void HostPeople()
        {
            // Arrange
            Hub hub = new Hub("A", new Vector2(1, 1));
            Assert.AreEqual(0, hub.Occupancy.Count);
            hub.AddPerson(new Person("Joe"));
            Assert.AreEqual(1, hub.Occupancy.Count);
        }
        [TestMethod]
        public void ParkPods()
        {
            // Arrange
            Hub hub = new Hub("A", new Vector2(1, 1));
            Assert.AreEqual(0, hub.Parking.Count);
            hub.AddPod(new Taxi("Joe",2));
            Assert.AreEqual(1, hub.Parking.Count);
        }

        [TestMethod]
        public void StoreContainers()
        {
            // Arrange
            Hub hub = new Hub("A", new Vector2(1, 1));
            Assert.AreEqual(0, hub.Containers.Count);
            hub.AddContainer(new Container("Joe"));
            Assert.AreEqual(1, hub.Containers.Count);
        }
    }
}
