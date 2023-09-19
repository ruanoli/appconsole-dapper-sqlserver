using Projeto03.Entities;
using Projeto03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Controllers
{
    public class PessoaController
    {

        public void ConsultarPessoas()
        {
            try
            {
                Console.WriteLine("Consultar Pessoa.");

                var pessoaRepository = new PessoaRepository();

                var pessoas = pessoaRepository.GetAllPessoa();

                foreach (var item in pessoas)
                {
                    Console.WriteLine($"ID: {item.IdPessoa}");
                    Console.WriteLine($"Nome: {item.Nome}");
                    Console.WriteLine($"CPF: {item.Cpf}");
                    Console.WriteLine($"Data de Nascimento: {item.DataNascimento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine("-----------------------");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao Consultar. {ex.Message}");
            }
           
        }

        public void CadastrarPessoa()
        {
            try
            {
                Console.WriteLine($"\nCadastro de Pessoa.");
                Pessoa pessoa = new Pessoa();

                pessoa.IdPessoa = Guid.NewGuid();

                Console.WriteLine("Informe o CPF da pessoa:");
                pessoa.Cpf = Console.ReadLine();

                Console.WriteLine("Informe o nome da pessoa:");
                pessoa.Nome = Console.ReadLine();

                Console.WriteLine("Informe a data de nascimento da pessoa:");
                pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());

                var pessoaRepository = new PessoaRepository();

                pessoaRepository.CreatePessoa(pessoa);

                Console.WriteLine("Pessoa Cadastrada com Sucesso.");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro de validação {ex.Message}");

                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao cadastrar {ex.Message}");
            }
            finally
            {
                if (DesejaRepetirProcesso())
                {
                    Console.Clear();
                    CadastrarPessoa(); //Recursividade
                }
            }
        }

        public void AtualizarPessoa()
        {
            try
            {
                Console.WriteLine($"\nEdição de Pessoa.");
                Console.WriteLine("Informe o Id da pessoa:");

                var pessoaId = Guid.Parse(Console.ReadLine());

                var pessoaRepository = new PessoaRepository();

                var pessoa = pessoaRepository.GetPessoaById(pessoaId);

                if (pessoa == null)
                    throw new ArgumentException("O id informado não existe no banco de dados.");

                bool desejaAtualizar = false;

                Console.WriteLine("Deseja atualizar o nome?");

                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if(desejaAtualizar)
                {
                    Console.WriteLine("Digite o Nome:");
                    pessoa.Nome = Console.ReadLine();
                }

                Console.WriteLine("Deseja atualizar o CPF?");

                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.WriteLine("Digite o CPF:");
                    pessoa.Cpf = Console.ReadLine();
                }

                Console.WriteLine("Deseja atualizar a Data de nascimento?");

                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.WriteLine("Digite a Data de Nascimento:");
                    pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());
                }

                pessoaRepository.UpdatePessoa(pessoa);

                Console.WriteLine("Pessoa atualizada com sucesso!");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"\nErro de validação. {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao tentar editar. {ex.Message}");
            }
            finally
            {
                if (DesejaRepetirProcesso())
                {
                    Console.Clear();
                    AtualizarPessoa(); //Recursividade
                }
            }

        }

        public void ExcluirPessoa()
        {
            try
            {
                Console.WriteLine($"\nExclusão de Pessoa.");

                Console.WriteLine("Informe o Id da pessoa:");

                var pessoaId = Guid.Parse( Console.ReadLine());

                var pessoaRepository = new PessoaRepository();

                var pessoa = pessoaRepository.GetPessoaById(pessoaId);

                if (pessoa == null)
                    throw new ArgumentException("O id informado não existe no banco de dados.");

                pessoaRepository.DeletePessoa(pessoa);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro de validação. {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao tentar excluir. {ex.Message}");
            }
            finally
            {
                if (DesejaRepetirProcesso())
                {
                    Console.Clear();
                    ExcluirPessoa(); //Recursividade
                }
            }
        }

        public void Menu()
        {
            try
            {
                var pessoaController = new PessoaController();

                Console.WriteLine("\nSistema de cadastro de pessoas.\n");

                Console.WriteLine("1 - Cadastrar Pessoa.");
                Console.WriteLine("2 - Consultar Pessoas.");
                Console.WriteLine("3 - Atualizar Pessoa.");
                Console.WriteLine("4 - Excluir Pessoa.");

                Console.WriteLine("\nEscolha uma opção:");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        pessoaController.CadastrarPessoa();
                        break;
                    case 2:
                        pessoaController.ConsultarPessoas();
                        break;
                    case 3:
                        pessoaController.AtualizarPessoa();
                        break;
                    case 4:
                        pessoaController.ExcluirPessoa();
                        break;
                    default:
                        throw new Exception("Opção inválida.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Deseja sair do programa S/N?");

                var desejaSair = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (!desejaSair)
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Fim do Programa.");
                }
            }
            Console.ReadKey();
        }

        private bool DesejaRepetirProcesso()
        {
            Console.WriteLine($@"Deseja tentar novamente? S/N");

            var opcao = Console.ReadLine();

            return opcao != null && opcao.Equals("S", StringComparison.OrdinalIgnoreCase);

        }
    }
}
