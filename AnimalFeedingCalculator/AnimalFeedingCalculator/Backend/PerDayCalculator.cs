using AnimalFeedingCalculator.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AnimalFeedingCalculator.Backend
{
    public class PerDayCalculator
    {

        public double CalculatePerDayRate()
        {
            MeatCalculator meatCalculator = new MeatCalculator();
            CalculatorInjector perDayCalculator = new CalculatorInjector(meatCalculator);
            double meat = perDayCalculator.CalculateRate();

            FruitCalculator fruitCalculator = new FruitCalculator();
            perDayCalculator = new CalculatorInjector(fruitCalculator);
            double fruit = perDayCalculator.CalculateRate();
            return meat + fruit;
        }

    }
}
