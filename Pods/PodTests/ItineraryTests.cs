using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace PodTests
{
    [TestClass]
    public class ItineraryTests
    {
        [TestMethod]
        public void TestFindDirectItinerary()
        {
            // Arrange
            World.Init();

            // Act
            Itinerary test = World.FindItinerary(World.Hubs[0], World.Hubs[1], new List<Hub>());

            // Assert
            Assert.AreEqual("A12 Lausanne-Genève", test.Roads[0].Name);

            // Arrange : destroy all roads
            World.Roads.Clear();

            // Act
            test = World.FindItinerary(World.Hubs[1], World.Hubs[2], new List<Hub>());

            // Assert
            Assert.AreEqual(0,test.Roads.Count);
        }

        [TestMethod]
        public void TestFindMultiLeggedItinerary()
        {
            // Arrange
            World.Init();

            // Act: find itinerary Geneve-Zurich
            Itinerary test = World.FindItinerary(World.Hubs[1], World.Hubs[4], new List<Hub>());

            // Assert that the beginning and end of the itinerary match the desired hubs, no matter the path
            Assert.IsTrue(test.Roads[0].From == World.Hubs[1] && test.Roads[test.Roads.Count-1].To == World.Hubs[4]);
        }

        public void TestRoadChaining()
        {
            // Arrange
            World.Init();
            Itinerary itinerary = new Itinerary();

            // Act
            itinerary.Roads.Add(World.Roads[0]); // Lausanne-Geneve
            itinerary.Roads.Add(World.Roads[1]); // Geneve-Lausanne
            itinerary.Roads.Add(World.Roads[3]); // Lausanne-Sion
            // Assert
            Assert.IsTrue(itinerary.IsValid());


            // Act
            itinerary = new Itinerary();
            itinerary.Roads.Add(World.Roads[0]); // Lausanne-Geneve
            itinerary.Roads.Add(World.Roads[1]); // Geneve-Lausanne
            itinerary.Roads.Add(World.Roads[2]); // Berne-Sion
            // Assert
            Assert.IsFalse(itinerary.IsValid());

        }
    }
}
