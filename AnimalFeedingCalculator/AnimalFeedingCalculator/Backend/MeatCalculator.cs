using AnimalFeedingCalculator.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using System.Linq;

namespace AnimalFeedingCalculator.Backend
{
    class MeatCalculator : IRateCalculator
    {
        public double Calculate()
        {
            FoodCalculator food = new FoodCalculator();
            double totalMeat = food.GetFoodRate("meat");
            return totalMeat;
        }

    }
}
