using System.Linq;
using NeuralNetwork.network;
using NeuralNetwork.neuron;

namespace NeuralNetwork.learning
{
    public class Backpropagation
    {
        public Perceptron Perceptron { get; set; }
        public double DeltaLearning { get; set; }

        public Backpropagation(Perceptron p, double deltaLearning)
        {
            Perceptron = p;
            DeltaLearning = deltaLearning;
        }

        public void Step(double[] input, double[] answer)
        {
            Perceptron.SendSignal(input);

            SetErrorInLastLayer(answer);

            for (int i = Perceptron.Layers.Count - 2; i > 0; i--)
            {
                Layer layer = Perceptron.Layers[i];
                foreach (Neuron neuron in layer.Neurons)
                {
                    double sumError = 0;
                    foreach (Link link in neuron.Outputs)
                    {
                        sumError += link.End.LastError * link.Weight;
                    }
                    SetError(sumError, neuron);
                }
            }

            for (int i = 1; i < Perceptron.Layers.Count; i++)
            {
                Layer layer = Perceptron.Layers[i];
                foreach (Neuron neuron in layer.Neurons)
                {
                    foreach (Link link in neuron.Inputs)
                    {
                        double delta = link.SignalIn * neuron.LastError * DeltaLearning;
                        link.Weight += delta;
                    }

                }
            }
        }

        private void SetError(double sumError, Neuron neuron)
        {
            neuron.LastError = sumError * neuron.ActivationFunction.EvaluateDerivative(neuron.SignalIn);
        }

        private void SetErrorInLastLayer(double[] answer)
        {
            int i = 0;
            foreach (Neuron neuron in Perceptron.Layers.Last().Neurons)
            {
                SetError(answer[i++] - neuron.SignalOut, neuron);
            }
        }
    }
}
