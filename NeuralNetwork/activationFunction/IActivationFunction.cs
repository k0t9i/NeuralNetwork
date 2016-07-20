namespace NeuralNetwork.activationFunction
{
    public interface IActivationFunction
    {
        double Evaluate(double input);
        double EvaluateDerivative(double input);
    }
}
