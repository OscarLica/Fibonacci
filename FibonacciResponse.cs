namespace FibonacciAPI
{
    public class FibonacciResponse
    {
        public int? FibonacciNumber { get; set; }
        public string Message => FibonacciNumber != null ? "Fibonacci number found" : "fibonacci number not found, max index 40 ";
    }
}
