using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using NeuralNetwork.network;
using NeuralNetwork.activationFunction;

namespace NeuralNetwork.io
{
    [DataContract]
    public class SerializableData
    {
        [DataMember]
        public List<int> Topology { get; set; }
        [DataMember]
        public List<double> Weights { get; set; }

        public SerializableData(Perceptron perceptron)
        {
            Topology = perceptron.Layers.Select(i => i.Neurons.Count).ToList<int>();
            Weights = perceptron.Links.Select(i => i.Weight).ToList<double>();
        }

        public Perceptron CreateNetwork(IActivationFunction activationFunction)
        {
            Perceptron result = new Perceptron(Topology.ToArray(), activationFunction);

            for (int i = 0; i < Weights.Count; i++)
            {
                result.Links[i].Weight = Weights[i];
            }

            return result;
        }
    }
}
