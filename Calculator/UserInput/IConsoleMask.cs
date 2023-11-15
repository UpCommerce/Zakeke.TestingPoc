namespace Calculator.UserInput
{
    public interface IConsoleMask
    {
        Func<int, int, int> DetermineUserOperation(string? operation);

        public bool isInjected();

        public void DetermineUserInput(string? x, string? y, out int valx, out int valy);
        
       

    }
}