using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Testar(-1000);
            Testar(0);
            Testar(400);
            Testar(400.99);
            Testar(500);
            Testar(500.01);
            Testar(600);
            Testar(1000);
            Testar(1000.01);
            Testar(10 * 100);
        }

        public static void Testar(double _valor)
        {
            try
            {
                Console.WriteLine(string.Format("\nTestar o valor: {0}", _valor));
                Console.WriteLine(string.Format("Desconto: {0}", AplicarDesconto(_valor)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Essa função aplicará desconto de 10% ao valor recebido
        /// por parâmetro, se este valor for de 500 a 1000, aplicará
        /// um desconto de 15% se o valor for superior a 1000 e não
        /// aplicará desconto caso o valor seja menor que 500
        /// </summary>
        /// <param name="_valor">Valor recebido para aplicar o desconto</param>
        /// <returns>Valor menos o desconto</returns>
        public static double AplicarDesconto(double _valor)
        {
            double retorno;

            if (_valor <= 0)
                throw new Exception("Para aplicar o desconto você deve passar um valor maior que zero.");


            if (_valor >= 500 && _valor <= 1000)
                retorno = _valor - _valor * 0.1;
            else if (_valor > 1000)
                retorno = _valor - _valor * 0.15;
            else
                retorno = _valor;

            return retorno;
        }
    }
}