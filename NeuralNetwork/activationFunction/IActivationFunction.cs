namespace NeuralNetwork.ActivationFunction
{
    public interface IActivationFunction
    {
        double Evaluate(double input);
        double EvaluateDerivative(double input);
    }
}
