using AnimalFeedingCalculator.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace AnimalFeedingCalculator.Backend
{
    class FruitCalculator : IRateCalculator
    {

        public double Calculate()
        {
            FoodCalculator food = new FoodCalculator();
            double totalFruit = food.GetFoodRate("fruit");
            return totalFruit;
        }

    }
}
