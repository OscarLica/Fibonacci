namespace FibonacciAPI.Service
{
    public interface IFibonacciService
    {
        FibonacciResponse GetFibonacciByIndex(int index);
    }
    public class FibonacciService : IFibonacciService
    {
        /// <summary>
        ///     arreglo de numeros fibonacci
        /// </summary>
        private int[] _arreglo { get; set; }

        /// <summary>
        ///     Constructor base, inicializa dependencias
        /// </summary>
        public FibonacciService()
        {
            _arreglo = new int[41];
            GenerateFibonacciSeries();
        }

        /// <summary>
        ///     Obtiene un numero fibonacci en base al indece
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FibonacciResponse GetFibonacciByIndex(int index) {
            return new FibonacciResponse { FibonacciNumber = index <= _arreglo.Length - 1 ? _arreglo[index] : null };
        }
        
        /// <summary>
        /// Genera la serie fibonacci
        /// </summary>
        private void GenerateFibonacciSeries() {

            _arreglo[0] = 0;
            _arreglo[1] = 1;

            for (int i = 2; i < 41; i++)
                _arreglo[i] = _arreglo[i - 1] + _arreglo[i - 2];
        }
    }
}
