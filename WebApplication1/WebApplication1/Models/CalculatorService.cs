public interface ICalculatorService
{
    double Calculate(double num1, double num2, string operation);
}

public class CalculatorService : ICalculatorService
{
    public double Calculate(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "Add":
                return num1 + num2;
            case "Subtract":
                return num1 - num2;
            case "Multiply":
                return num1 * num2;
            case "Divide":
                if (num2 == 0)
                    throw new DivideByZeroException("Деление на ноль недопустимо.");
                return num1 / num2;
            default:
                throw new ArgumentException("Неизвестная операция.");
        }
    }
}