using System;

namespace Infra
{
    public static class Constante
    {
        public static string DiretorioDeLog = Environment.CurrentDirectory + "\\Logs\\";
        public static string NomeArquivoLog = string.Format("Log{0}.txt", DateTime.Now.ToString());
    }
}
