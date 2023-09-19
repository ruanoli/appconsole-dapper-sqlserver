using Dapper;
using Projeto03.Entities;
using System.Data.SqlClient;


namespace Projeto03.Repositories
{
    public class PessoaRepository
    {

        private string _connectionString;

        public PessoaRepository()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_Project_Aula03;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        }

        public List<Pessoa> GetAllPessoa()
        {
            var sql = @"SELECT * FROM Pessoa";

            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>(sql).ToList();
            }
        }

        public Pessoa GetPessoaById(Guid idPessoa)
        {
            var sql = @"SELECT * FROM Pessoa WHERE idPessoa = @idPessoa";

            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<Pessoa>(sql, new { idPessoa }).FirstOrDefault();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    Guid guidResult = (Guid)command.ExecuteScalar();
                    // Agora, 'guidResult' contém o GUID retornado do banco de dados.
                }
            }
        }

        public void CreatePessoa(Pessoa pessoa)
        {
            var sql = @"
                    INSERT INTO Pessoa(idPessoa, nome, cpf, dataNascimento)
                    VALUES (@IdPessoa, @Nome, @Cpf, @DataNascimento)
                ";

            using (var connectionDb = new SqlConnection(_connectionString))
            {
                connectionDb.Execute(sql, pessoa);
            }        
        }

        public void UpdatePessoa(Pessoa pessoa)
        {
            var sql = @"
                        UPDATE Pessoa SET 
                            nome = @Nome, 
                            cpf = @Cpf, 
                            dataNascimento = @DataNascimento
                        WHERE idPessoa = @IdPessoa
                      ";

            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, pessoa);
            }
        }

        public void DeletePessoa(Pessoa pessoa)
        {
            var sql = " DELETE FROM Pessoa WHERE idPessoa = @IdPessoa";

            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, pessoa);
            }
        }

        
    }
}
