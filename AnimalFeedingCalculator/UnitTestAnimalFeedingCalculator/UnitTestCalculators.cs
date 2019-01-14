using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalFeedingCalculator.Common;
using AnimalFeedingCalculator.Backend;

namespace UnitTestAnimalFeedingCalculator
{
    [TestClass]
    public class UnitTestFoodCalculator
    {

        PerDayCalculator _perDayCalculator;
        FoodCalculator fd;


        [TestInitialize]
        public void Setup()
        {
            _perDayCalculator = new PerDayCalculator();
            fd = new FoodCalculator();

        }

        [TestMethod]
        public void FailedCalculatePerDayRate()
        {
            Assert.AreEqual(100, _perDayCalculator.CalculatePerDayRate(), "Incorrect Value");
        }
        [TestMethod]
        public void PassedCalculatePerDayRate()
        {
            Assert.AreEqual(1609.00896, _perDayCalculator.CalculatePerDayRate(), 0.1);
        }

        [TestMethod]
        public void PassedMeat()
        {
            fd.GetFoodRate("meat");
            Assert.AreEqual(1260.72256, fd.GetFoodRate("meat"), 12.1);

        }
        [TestMethod]
        public void FailedMeat()
        {
            fd.GetFoodRate("meat");
            Assert.AreEqual(100, fd.GetFoodRate("meat"), "Incorrect Value");
        }

        [TestMethod]
        public void PassedFruit()
        {
            fd.GetFoodRate("fruit");
            Assert.AreEqual(348.2864, fd.GetFoodRate("fruit"), 0.1);

        }
        [TestMethod]
        public void FailedFruit()
        {
            fd.GetFoodRate("fruit");
            Assert.AreEqual(100, fd.GetFoodRate("fruit"), "Incorrect Value");
        }





    }
}
