using System.Collections.Generic;
using System.IO;

namespace Rock_Senai.Models
{

    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        protected string Senha { get; set; }

        private const string PATH = "Database/usuario.csv";



        internal static List<string> ReadAllLinesCSV(string PATH)
        {

            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;

        }
        public virtual bool Logar(string Email, string Senha)
        {
            bool logado = false;

            List<string> csv = ReadAllLinesCSV(PATH);

            var usuarioLogado =
            csv.Find(
                x =>
                x.Split(";")[1] == "Email" &&
                x.Split(";")[2] == "Senha"
            );


           
            if (usuarioLogado != null)
            {
                logado = true;
                return logado;
            }

            
            return logado;
        }



        public void CriarPastaArquivo(string _path)
        {
            string folder = _path.Split("/")[0];
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }


        }
        
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }

    }
}
