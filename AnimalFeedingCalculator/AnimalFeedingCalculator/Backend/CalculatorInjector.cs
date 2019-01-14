using AnimalFeedingCalculator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFeedingCalculator.Backend
{
    class CalculatorInjector
    {

        private IRateCalculator _rateCalculator;
        public CalculatorInjector(IRateCalculator rateCalculator)
        {
            _rateCalculator = rateCalculator;

        }

        public double CalculateRate()
        {
            return _rateCalculator.Calculate();
        }

    }
}
