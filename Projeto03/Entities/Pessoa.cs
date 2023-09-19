using Projeto03.Validations;


namespace Projeto03.Entities
{
    public class Pessoa
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;

        public Guid IdPessoa 
        { 
            get => _id; 
            set 
            {
                if (!IdValidation.IsValid(value))
                     throw new ArgumentException("Id inválido.");

                _id = value; 
            } 
        }
        public string Nome 
        { 
            get => _nome;
            set 
            {
                if (!NomeValidation.IsValid(value))
                    throw new ArgumentException("Nome é inválido");

                _nome = value; 
            } 
        }
        public DateTime DataNascimento 
        {
            get => _dataNascimento;
            set 
            {
                if (!DataValidation.IsValid(value))
                    throw new ArgumentException("Data de nascimento inválida.");

                _dataNascimento = value; 
            } 
        }
        public string Cpf 
        {
            get => _cpf;
            set 
            {
                if (!CpfValidation.IsValid(value))
                    throw new ArgumentException("CPF inválido");

                _cpf = value; 
            } 
        }
    }
}
