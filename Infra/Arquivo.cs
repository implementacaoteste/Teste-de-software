using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Infra
{
    public class Arquivo
    {
        public void CopiarArquivo(string _origem, string _destino)
        {
            File.Copy(_origem, _destino);
        }
        public void MoverArquivo(string _origem, string _destino)
        {
            File.Move(_origem, _destino);
        }
        public void ExcluirArquivo(string _arquivo)
        {
            File.Delete(_arquivo);
        }
        public static void CriarDiretorio(string _caminho)
        {
            Directory.CreateDirectory(_caminho);
        }
        public void ExcluirDiretorio(string _diretorio)
        {
            Directory.Delete(_diretorio);
        }
        public void RenomarArquivo(string _caminho, string _antigoNome, string _novoNome)
        {
            File.Replace(_antigoNome, _novoNome, _caminho + DateTime.Now.ToString());
        }
        public void GravarTextoNoFinalDoArquivo(string _texto, string _caminho)
        {
            FileStream fileStream = new FileStream(_caminho, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            streamWriter.WriteLine(_texto);

            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }

        public void GravarLog(string _texto)
        {
            CriarDiretorio(Constante.DiretorioDeLog);
            GravarTextoNoFinalDoArquivo(DateTime.Now.ToString() + ": " + _texto, Constante.DiretorioDeLog + Constante.NomeArquivoLog);
        }

        public ArrayList LerArquivo(string _caminho)
        {
            throw new NotImplementedException();
        }
        public string[] ListarArquivos(string _diretorio, string _filtro = null)
        {
            if (!Directory.Exists(_diretorio))
                throw new Exception(string.Format("O diretório {0} não existe", _diretorio));

            return _filtro is null ? Directory.GetFiles(_diretorio) : Directory.GetFiles(_diretorio, _filtro, SearchOption.AllDirectories);
        }
        public string[] ListarDiretorios(string _diretorio)
        {
            if (!Directory.Exists(_diretorio))
                throw new Exception(string.Format("O diretório {0} não existe", _diretorio));

            return Directory.GetDirectories(_diretorio);
        }
        public string GerarHash(string _arquivo)
        {
            if (!File.Exists(_arquivo))
                throw new Exception(string.Format("O arquivo {0} não existe", _arquivo));

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                try
                {
                    using (var stream = File.OpenRead(_arquivo))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLower();
                    }
                }
                catch (Exception ex)
                {
                    GravarLog(ex.Message);
                    return string.Format("Erro: {0}", ex.Message);
                }
            }
        }
    }
}
