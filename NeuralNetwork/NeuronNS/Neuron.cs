using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.ActivationFunction;
using NeuralNetwork.NeuronNS.Weight;

namespace NeuralNetwork.NeuronNS
{
    public class Neuron
    {
        public double SignalIn
        {
            get
            {
                return Inputs.Sum(i => i.SignalOut);
            }
        }
        public double SignalOut
        {
            get
            {
                return Inputs.Count > 0 ? ActivationFunction.Evaluate(SignalIn) : signalOut;
            }
            set
            {
                if (Inputs.Count > 0)
                {
                    throw new ArgumentException("Inputs count greater than zero, SignalOut calculated from input signals");
                }
                signalOut = value;
            }
        }
        public double LastError { get; set; }
        public List<Link> Inputs { get; private set; }
        public List<Link> Outputs { get; private set; }
        public IActivationFunction ActivationFunction { get; set; }

        private double signalOut;

        public Neuron(IActivationFunction activationFunction)
        {
            LastError = 0;
            if (activationFunction == null)
            {
                throw new ArgumentNullException("activationFunction");
            }
            ActivationFunction = activationFunction;
            Inputs = new List<Link>();
            Outputs = new List<Link>();
        }

        public void CreateLink(Neuron start, IWeightInit weight)
        {
            Link link = new Link(start, this, weight);
            start.Outputs.Add(link);
            Inputs.Add(link);
        }

        public void Evaluate()
        {
            foreach (Link link in Outputs)
            {
                link.SignalIn = SignalOut;
            }
        }
    }
}
