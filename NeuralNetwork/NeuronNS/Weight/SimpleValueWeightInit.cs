﻿namespace NeuralNetwork.NeuronNS.Weight
{
    public class SimpleValueWeightInit : IWeightInit
    {
        private double value;

        public SimpleValueWeightInit(double value)
        {
            this.value = value;
        }

        public double GetWeight()
        {
            return value;
        }
    }
}
