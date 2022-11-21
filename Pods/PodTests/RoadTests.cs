using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace PodTests
{
    [TestClass]
    public class RoadTests
    {
        [TestMethod]
        public void TaxiMustHaveEnoughTravellersTest()
        {
            // Arrange
            Taxi[] taxis = new Taxi[3]
            {
                new Taxi("xxx", 2),
                new Taxi("xxx", 8),
                new Taxi("xxx", 13)
            };
            int[] limits = new int[3] { 1, 4, 7 }; // from that point for each taxi, it should be Ok to ride
            Road road = new Road("AB", new Hub("A", new Vector2(1, 1)), new Hub("B", new Vector2(2, 2)));

            // Assert
            foreach (Taxi taxi in taxis)
                Assert.IsFalse(road.AllowEnter(taxi)); // Empty taxis can't drive

            // Arrange: add some travellers, but not enough
            for (int i = 0; i < limits.Length; i++)
                for (int nbt = 0; nbt < limits[i] - 1; nbt++)
                    taxis[i].addTraveller(new Person("xxx"));
            // Assert
            foreach (Taxi taxi in taxis)
                Assert.IsFalse(road.AllowEnter(taxi)); // Less than half full taxis can't drive

            // Arrange: add one traveller, should be enough
            for (int i = 0; i < taxis.Length; i++)
                taxis[i].addTraveller(new Person("xxx"));
            // Assert
            foreach (Taxi taxi in taxis)
                Assert.IsTrue(road.AllowEnter(taxi)); // More than half full taxis can drive

        }
    }
}
