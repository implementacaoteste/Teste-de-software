using Infra;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(AplicarDesconto(10));
            ListarDiretorio(@"D:\Dropbox2022\Dropbox\");
        }

        public static string[] ListarDiretorio(string _diretorio)
        {
            Arquivo arquivo = new Arquivo();
            string[] retorno = arquivo.ListarDiretorios(_diretorio);
            string[] diretorios;
            string[] arquivos;

            foreach (string item in retorno)
            {
                if (!item.Contains("$") && !item.Contains("Programas Instalados"))
                {
                    diretorios = ListarDiretorio(item);
                    if (diretorios.Length > 0)
                        retorno = diretorios;
                }
                arquivos = arquivo.ListarArquivos(item);

                if (arquivos.Length > 0)
                    foreach (string arq in arquivos)
                        GravarArquivoNoBanco(arq);
                else
                    Console.WriteLine(item);
            }
            return retorno;
        }

        private static void GravarArquivoNoBanco(string _arquivo)
        {
            Arquivo arquivo = new Arquivo();
            Console.WriteLine(_arquivo);
            string hash = arquivo.GerarHash(_arquivo);
            arquivo.GravarTextoNoFinalDoArquivo(_arquivo, Environment.CurrentDirectory + "\\Arquivos.txt");
            Console.WriteLine(hash);
            arquivo.GravarTextoNoFinalDoArquivo(hash, Environment.CurrentDirectory + "\\Arquivos.txt");
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