namespace NeuralNetwork.activationFunction
{
    public class LinearActivationFunction : IActivationFunction
    {
        private double k;
        private double b;

        public LinearActivationFunction(double k = 1, double b = 0)
        {
            this.k = k;
            this.b = b;
        }

        public double Evaluate(double input)
        {
            return k * input + b;
        }

        public double EvaluateDerivative(double input)
        {
            return k;
        }
    }
}
