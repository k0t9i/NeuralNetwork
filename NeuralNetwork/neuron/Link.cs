using System;
using NeuralNetwork.neuron.weight;

namespace NeuralNetwork.neuron
{
    public class Link
    {
        public double Weight { get; set; }
        public double SignalIn { get; set; }
        public double SignalOut
        {
            get
            {
                return SignalIn * Weight;
            }
        }
        public Neuron Start { get; set; }
        public Neuron End { get; set; }

        public Link(Neuron start, Neuron end, IWeightInit weight, double signal = 0)
        {
            if (start == null)
            {
                throw new ArgumentNullException("start");
            }
            if (end == null)
            {
                throw new ArgumentNullException("end");
            }
            Start = start;
            End = end;
            Weight = weight.GetWeight();
            SignalIn = signal;
        }
    }
}
