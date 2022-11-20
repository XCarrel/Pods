using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodTests
{
    [TestClass]
    public class PodTests
    {
        [TestMethod]
        public void ValidTravellerCapacityTest()
        {
            // Act: build one taxi for each capacity
            foreach (int capa in Taxi.ALLOWED_CAPACITIES)
            {
                Taxi taxi = new Taxi("xxx", capa);
                Assert.IsNotNull(taxi);
            }
            // Act: try to build taxies with invalid capacities
            bool noBadBuild = true;
            for (int capa = 0; capa < 30; capa++)
                if (!Taxi.ALLOWED_CAPACITIES.Contains(capa))
                    try
                    {
                        Taxi taxi = new Taxi("xxx", capa);
                        noBadBuild = false; // it's not OK to reach this line
                    }
                    catch (Exception e)
                    {
                        // Good!
                    }
            Assert.IsTrue(noBadBuild);
        }

        [TestMethod]
        public void ValidContainerCapacityTest()
        {
            // Act: build one taxi for each capacity
            foreach (int capa in Truck.ALLOWED_CAPACITIES)
            {
                Truck truck = new Truck("xxx", capa);
                Assert.IsNotNull(truck);
            }
            // Act: try to build taxies with invalid capacities
            bool noBadBuild = true;
            for (int capa = 0; capa < 30; capa++)
                if (!Truck.ALLOWED_CAPACITIES.Contains(capa))
                    try
                    {
                        Truck truck = new Truck("xxx", capa);
                        noBadBuild = false; // it's not OK to reach this line
                    }
                    catch (Exception e)
                    {
                        // Good!
                    }
            Assert.IsTrue(noBadBuild);
        }

        [TestMethod]
        public void TruckLoadTest()
        {
            // Arrange
            Truck truck = new Truck("xxx", 4);
            Container container1 = new Container("xxx");
            container1.LoadWeight = 1000; // 1Ton
            Container container2 = new Container("xxx");
            container2.LoadWeight = 800;
            Container container3 = new Container("xxx");
            container3.LoadWeight = 500;

            // Act: load the truck with decent weight
            truck.AddContainer(container2);
            truck.AddContainer(container3);
            // Assert
            Assert.AreEqual(1300,truck.TotalLoad);

            // Act: overcome the limit
            bool noBadLoad = true;
            try
            {
                truck.AddContainer(container1);
                noBadLoad = false;
            } catch(Exception e)
            {
                // OK
            }
            Assert.IsTrue(noBadLoad);
        }

        [TestMethod]
        public void DriverLicenseTest()
        {
            //Arrange
            Person personLicense = new Person("Lucky", "xxxx", true);
            Person person1 = new Person("Joe", "xxxx", false);
            Person person2 = new Person("Jack", "xxxx", false);
            Person person3 = new Person("William", "xxxx", false);
            Person person4 = new Person("Averell", "xxxx", false);
            Person person5 = new Person("Rantanplan", "xxxx", false);
            Person person6 = new Person("Jolly", "xxxx", false);

            Taxi taxi = new Taxi("xxx",21);

            taxi.addTraveller(person1);

            Assert.IsTrue(taxi.canTravel());

            taxi.addTraveller(person2);
            taxi.addTraveller(person3);
            taxi.addTraveller(person4);
            taxi.addTraveller(person5);
            taxi.addTraveller(person6); // There are now 6 passengers without license

            Assert.IsFalse(taxi.canTravel());

            taxi.addTraveller(personLicense);

            Assert.IsTrue(taxi.canTravel());
        }


    }
}
