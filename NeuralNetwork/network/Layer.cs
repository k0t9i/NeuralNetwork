using System;
using System.Collections.Generic;
using NeuralNetwork.NeuronNS;
using NeuralNetwork.ActivationFunction;

namespace NeuralNetwork.Network
{
    public class Layer
    {
        public List<Neuron> Neurons { get; private set; }

        public Layer(int neuronCount, IActivationFunction activationFunction)
        {
            if (activationFunction == null)
            {
                throw new ArgumentNullException("activationFunction");
            }
            Neurons = new List<Neuron>();
            for (int i = 0; i < neuronCount; i++)
            {
                Neurons.Add(new Neuron(activationFunction));
            }
        }
    }
}
