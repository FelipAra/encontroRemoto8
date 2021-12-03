using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {

            List<PessoaJurica> listaPj = new List<PessoaJurica>();
            List<PessoaFisica> listapf = new List<PessoaFisica>();

            string opcao;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
================================================
|       Bem vindo  ao sistema de cadastro de   |
|           pessoas física e jurídica          |
================================================
");
            Console.ResetColor();
            Thread.Sleep(3000);

            // barraCarregamento("Iniciando");

            Console.ResetColor();

            Console.Clear();

            do
            {
                Console.WriteLine(@$"
=====================================================
|           Escolha uma das opções abaixo           |
|---------------------------------------------------|
|               PESSOA FÍSICA                       |
|           1 - Cadastrar pessoa física             |
|           2 - Listar pessoa física                |
|           3 - Remover pessoa física               |
|                                                   |
|               PESSOA JURÍDICA                     |
|           4 - Cadastrar pessoa Jurídica           |
|           5 - Listar pessoa jurídicas             |
|           6 - Remover pessoa jurídica             |
|                                                   |
|           0 - Sair                                |
=====================================================
");

            opcao = Console.ReadLine();

            switch (opcao) {

                case "1":
                    PessoaFisica pf = new PessoaFisica();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco end = new Endereco();

                    // Console.WriteLine($"Digite seu logradouro:");
                    // end.logradouro = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite o número da sua casa:");
                    // end.numero = int.Parse(Console.ReadLine());

                    // Console.WriteLine($"Digite um complemento:");
                    // end.complemento = Console.ReadLine();
                    
                    // Console.WriteLine($"Seu endereço é comercial? S/N:");
                    // string tipoEnd = Console.ReadLine().ToUpper();
                    // if (tipoEnd == "S") {
                        
                    //     end.enderecoComercial = true;
                    // } else {

                    //     end.enderecoComercial = false;
                    // }

                    // novaPf.endereco = end;

                    Console.WriteLine($"Digite seu nome: ");
                    novaPf.nome = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite seu cpf (Apenas números):");
                    // novaPf.cpf = Console.ReadLine();
                    
                    // Console.WriteLine($"Informe seu rendimento mensal (Apenas números):");
                    // novaPf.rendimento = float.Parse(Console.ReadLine());

                    // Console.WriteLine($"Informe sua data de nascimento. EX: AAAA-MM-DD:");
                    // novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                    // bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                    // if (idadeValida == true) {

                    //     Console.WriteLine($"Cadastro aprovado!");
                    //     listapf.Add(novaPf);
                    //     Console.WriteLine(pf.pagarImposto(novaPf.rendimento));

                    // } else {
                    //     Console.WriteLine($"Cadastro não aprovado!");
                        
                    // }

                    // StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                    // sw.Write($"{novaPf.nome}");
                    // sw.Close();

                    // using(StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                    // {
                    //     sw.Write($"{novaPf.nome}");
                    // }

                    using (StreamReader sr = new StreamReader($"{novaPf.nome}.txt"))
                    {
                        string linha;

                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine($"{linha}");
                        }
                    }

                    break;

                case "2":
                        foreach (var cadaitemPf in listapf)
                        {
                            Console.WriteLine($"{cadaitemPf.nome}, {cadaitemPf.cpf}, {cadaitemPf.endereco.logradouro}");
                        }
                    break;

                case "3":
                        Console.WriteLine($"Digite o cpf que deseja remover:");
                        string cpfProcurado = Console.ReadLine();
                        
                        PessoaFisica pessoaEncontrada = listapf.Find(cadaitemPf => cadaitemPf.cpf == cpfProcurado);

                        if(pessoaEncontrada != null)
                        {
                            listapf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro removido!");
                            
                        } else {
                            Console.WriteLine($"cadastro não encontrado!");
                            
                        }

                    break;
                
                case "4":
                    PessoaJurica pj = new PessoaJurica();
                    PessoaJurica novapj = new PessoaJurica();
                    Endereco endPj = new Endereco();

                    // Console.WriteLine($"Digite seu logradouro:");
                    // endPj.logradouro = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite o número da residência:");
                    // endPj.numero = int.Parse(Console.ReadLine());
                    
                    // Console.WriteLine($"Digite um complemento:");
                    // endPj.complemento = Console.ReadLine();
                    
                    // Console.WriteLine($"Seu endereço é comercial? S/N");
                    // string tipoEndPj = Console.ReadLine().ToUpper();
                    // if(tipoEndPj == "S")
                    // {
                    //     endPj.enderecoComercial = true;
                    // } else
                    // {
                    //     endPj.enderecoComercial = false;
                    // }

                    // novapj.endereco = endPj;

                    Console.WriteLine($"Digite seu Nome:");
                    novapj.nome = Console.ReadLine();
                    
                    Console.WriteLine($"Digite seu CNPJ:");
                    novapj.cnpj = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite seu rendimento:");
                    // novapj.rendimento = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine($"Digite a razão social:");
                    novapj.razaoSocial = Console.ReadLine();

                    if(pj.validarCNPJ(novapj.cnpj))
                    {

                        Console.WriteLine("CNPJ Válido");
                    } else
                    {
                        Console.WriteLine($"CNPJ Inválido");
                    }
                    
                    // pj.verificarArquivo(pj.caminho);
                    // pj.inserir(novapj);

                    if(pj.Ler().Count > 0)
                    {
                    foreach (var item in pj.Ler())
                    {
                        Console.WriteLine($"CNPJ: {item.cnpj} - Nome: {item.nome} - Razão social: {item.razaoSocial}");
                    }
                    } else
                    {
                        Console.WriteLine($"Lista vazia.");
                    }

                    break;
                case "5":
                        foreach (var cadaItemPj in listaPj)
                        {
                            Console.WriteLine($"{cadaItemPj.nome}, {cadaItemPj.endereco.logradouro}, {cadaItemPj.cnpj}");
                        }
                    break;
                case "6":
                        Console.WriteLine($"Digite o cnpj que deseja excluir:");
                        string cnpjProcurado = Console.ReadLine();
                        
                        PessoaJurica cnpjEncontrado = listaPj.Find(cadaItemPj => cadaItemPj.cnpj == cnpjProcurado);

                        if(cnpjEncontrado != null) {

                            listaPj.Remove(cnpjEncontrado);
                            Console.WriteLine($"Cadastro removido com sucesso!");
                        } else
                        {
                            Console.WriteLine($"Cadastro não encontrado!");
                            
                        }
                        
                    break;
                case "0":
                Console.Clear();
                Console.WriteLine($"Obrigado por utillizar nosso sistema.");

                // barraCarregamento("Finalizando");

                Console.ResetColor();
                break;
            
            default:
                Console.ResetColor();
                Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
                break;
            }
        } while (opcao != "0"); }
    
        static void barraCarregamento(string textoCarregamento) {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);
            for(var i = 0; i < 10; i++) 
            {
                Console.Write(".");
                Thread.Sleep(500);
            }

        }
    }
}
