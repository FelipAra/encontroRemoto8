using System.Collections.Generic;
using System.IO;

namespace cadastroPessoa

{
    public class PessoaJurica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        public override double pagarImposto(float rendimento)
        {
            if(rendimento <= 5000)
            {
                return rendimento * .06;
            } else if(rendimento > 5000 && rendimento <= 10000)

            {
                return rendimento * .08;
                
            } else {
                return rendimento * 10;
            }
        }

        public bool validarCNPJ(string cnpj){

            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001") {

                return true;
            }
                return false;
        }
    
        public string prepararLinhasCsv(PessoaJurica pj)
        {
            return $"{pj.cnpj};{pj.nome};{pj.razaoSocial}";
        }
    
        public void inserir(PessoaJurica pj)
        {
            string[] linhas = {prepararLinhasCsv(pj)};

            File.AppendAllLines(caminho, linhas);
        }
    
        public List<PessoaJurica> Ler()
        {
            List<PessoaJurica> listaPj = new List<PessoaJurica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaJurica cadaPj = new PessoaJurica();

                cadaPj.cnpj = atributos[0];
                cadaPj.nome = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                listaPj.Add(cadaPj);
            }
                return listaPj;
        }
    }
}