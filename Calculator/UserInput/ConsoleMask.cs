using Calculator.Math;

namespace Calculator.UserInput
{
    public class ConsoleMask
    {
        public static Func<int, int, int> DetermineUserOperation(string? operation)
        {

            var func = operation switch
            {
                "1" => new Func<int, int, int>(Operations.AddTwoNumbers),
                "2" => new Func<int, int, int>(Operations.SubtractTwoNumbers),
                "3" => new Func<int, int, int>(Operations.MultiplyTwoNumbers),
                "4" => new Func<int, int, int>(Operations.DivideTwoNumbers),
                _ => throw new NotImplementedException("Invalid Operation requested")
            };
            return func;
        }

        public static void DetermineUserInput(string? x, string? y, out int valx, out int valy)
        {
            if (!Int32.TryParse(x, out valx)) throw new InvalidDataException("Invalid data supplied");
            if (!Int32.TryParse(y, out valy)) throw new InvalidDataException("Invalid data supplied");
        }

        public bool isInjected()
            {
            Console.WriteLine("Mask Injected");
            return true;
            }

    }
}
