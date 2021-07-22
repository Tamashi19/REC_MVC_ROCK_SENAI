using System;
using System.Collections.Generic;
using System.IO;

namespace Rock_Senai.Models
{
    public class Musico : Usuario
    {


        public int OMB { get; set; }

        private const string PATH = "Database/usuario.csv";


        public override bool Logar(string Email, string Senha)
        {
             bool logado = false;

            List<string> csv = ReadAllLinesCSV(PATH);

            var usuarioLogado =
            csv.Find(
                x =>
                x.Split(";")[2] == Senha &&
                x.Split(";")[1] == Email
            );

            usuarioLogado =
            csv.Find(
                x =>
                x.Split(";")[2] == Senha &&
                x.Split(";")[3] == Email
            );


           
            if (usuarioLogado != null)
            {
                logado = true;
                return logado;
            }

            
            return logado; 
        }



        public void Create(Musico m)
        {
            string[] linha = { PrepararLinha(m) };
            File.AppendAllLines(PATH, linha);
        }


        private string PrepararLinha(Musico m)
        {
            return $";{m.Nome};{m.Email};{m.Senha};{m.OMB}";
        }
    }
}