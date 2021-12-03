using System;

namespace cadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }

        public override double pagarImposto(float rendimento){            
            if(rendimento <= 1500.00)
            {
                return 0;
            } else if(rendimento > 1500 && rendimento <= 5000)

            {
                return rendimento * .03;
                
            } else {
                return rendimento * .05;
            }
        }
        public bool ValidarDataNascimento(DateTime dataNasc){

            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;


            if (anos >= 18) {

                return true;
            
            } 
            return false;
        }
    }
}