using System;

namespace NeuralNetwork.NeuronNS.Weight
{
    public class RandomWeightInit : IWeightInit
    {
        private Random rnd;
        private double min;
        private double max;

        public RandomWeightInit(double min = 0, double max = 1)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min greater or equal than max");
            }
            rnd = new Random();
            this.min = min;
            this.max = max;
        }

        public double GetWeight()
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }
}
