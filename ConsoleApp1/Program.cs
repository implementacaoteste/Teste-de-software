using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(AplicarDesconto(10));
        }

        public static double AplicarDesconto(double _valor)
        {
            double retorno;

            if (_valor < 1000 && _valor > 500)
                retorno = _valor - _valor * 0.1;
            else if (_valor > 1000)
                retorno = _valor - _valor * 0.15;
            else
                retorno = _valor;

            return retorno;
        }
    }
}