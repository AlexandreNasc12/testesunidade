namespace testesunidade.domain;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Cpf Cpf { get; private set; }
    public DateTime DataDeNascimento { get; private set; }

    //EF
    private HashSet<Endereco> _Enderecos;
    public IReadOnlyCollection<Endereco> Enderecos => _Enderecos;

    public int Idade
    {
        get
        {
            if (DataDeNascimento == DateTime.MinValue) return 0;

            var idade = DateTime.Now.Year - DataDeNascimento.Year;

            if (DateTime.Now.Month < DataDeNascimento.Month ||
            (DateTime.Now.Month == DataDeNascimento.Month && DateTime.Now.Day < DataDeNascimento.Day))
            {
                idade--;
            }

            return idade;
        }
    }

    private Usuario() { 
        _Enderecos = new HashSet<Endereco>();
    }

    public Usuario(string nome, Cpf cpf, DateTime dataDeNascimento) : this()
    {
        Nome = nome;
        Cpf = cpf;
        DataDeNascimento = dataDeNascimento;
    }

    public void AtribuirNome(string nome) => Nome = nome;

    public void AtribuirDataDeNascimento(DateTime dataNascimento) => DataDeNascimento = dataNascimento;

    public void Adicionar(Endereco endereco) => _Enderecos.Add(endereco);
}
