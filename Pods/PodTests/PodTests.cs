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
        { }

        [TestMethod]
        public void TruckLoadTest()
        { }

        [TestMethod]
        public void DriverLicenseTest()
        { }


    }
}
