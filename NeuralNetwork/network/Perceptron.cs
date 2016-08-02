using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.ActivationFunction;
using NeuralNetwork.NeuronNS.Weight;
using NeuralNetwork.NeuronNS;

namespace NeuralNetwork.Network
{
    public class Perceptron
    {
        public List<Layer> Layers { get; private set; }
        public IActivationFunction ActivationFunction { get; private set; }
        public List<Link> Links
        {
            get
            {
                List<Link> result = new List<Link>();
                foreach (Layer layer in Layers)
                {
                    foreach (Neuron neuron in layer.Neurons)
                    {
                        result.AddRange(neuron.Inputs);
                    }
                }

                return result;
            }
        }

        public Perceptron(int[] neuronsInlayers, IActivationFunction activationFunction) : this(neuronsInlayers, activationFunction, new SimpleValueWeightInit(1))
        {

        }

        public Perceptron(int[] neuronsInlayers, IActivationFunction activationFunction, IWeightInit weight)
        {
            if (neuronsInlayers == null)
            {
                throw new ArgumentNullException("neuronsInlayers");
            }
            if (activationFunction == null)
            {
                throw new ArgumentNullException("activationFunction");
            }
            if (weight == null)
            {
                throw new ArgumentNullException("weight");
            }

            ActivationFunction = activationFunction;

            Layer prev = null;
            Layers = new List<Layer>();
            foreach (int neuronCount in neuronsInlayers)
            {
                Layer layer = new Layer(neuronCount, activationFunction);
                if (prev != null)
                {
                    LinkLayers(layer, prev, weight);
                }
                prev = layer;
                Layers.Add(layer);
            }
        }

        public double[] SendSignal(double[] signals)
        {
            if (signals == null)
            {
                throw new ArgumentNullException("values");
            }
            if (signals.Length != Layers[0].Neurons.Count)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < signals.Length; i++)
            {
                Layers[0].Neurons[i].SignalOut = signals[i];
            }

            foreach (Layer layer in Layers)
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    neuron.Evaluate();
                }
            }

            Layer last = Layers.Last();

            List<double> result = new List<double>();

            foreach (Neuron neuron in last.Neurons)
            {
                result.Add(neuron.SignalOut);
            }

            return result.ToArray();
        }

        private void LinkLayers(Layer layer, Layer prevLayer, IWeightInit weight)
        {
            if (layer == null)
            {
                throw new ArgumentNullException("layer");
            }
            if (prevLayer == null)
            {
                throw new ArgumentNullException("prevLayer");
            }
            if (weight == null)
            {
                throw new ArgumentNullException("weight");
            }
            foreach (Neuron neuron in layer.Neurons)
            {
                foreach (Neuron n in prevLayer.Neurons)
                {
                    neuron.CreateLink(n, weight);
                }
            }
        }

    }
}
