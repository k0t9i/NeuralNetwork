using System;

namespace NeuralNetwork.ActivationFunction
{
    public class SigmoidActivationFunction : IActivationFunction
    {
        private double param;

        public SigmoidActivationFunction(double t = 1)
        {
            param = t;
        }

        public double Evaluate(double input)
        {
            return 1 / (1 + Math.Exp(param * (-input)));
        }

        public double EvaluateDerivative(double input)
        {
            return Evaluate(input) * (1 - Evaluate(input));
        }
    }
}
