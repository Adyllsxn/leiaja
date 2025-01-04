namespace LeiaJa.Domain.Entities;
public sealed class EmprestimoEntity : EntityBase
{
    public int UsuarioId { get; private set; }
    public int LivroId { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataEntrega { get; private set; }
    public bool Entrega { get; private set; }

    [JsonIgnore]
    public UsuarioEntity usuario { get; set; } = null!;

    [JsonIgnore]
    public LivroEntity Livro { get; set; } = null!;

    [JsonConstructor]
    public EmprestimoEntity(){}
    public EmprestimoEntity(int id, int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Emprestimo Não Pode Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Emprestimo Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(usuarioId, livroId, dataEmprestimo, dataEntrega, entrega);
    }

    public EmprestimoEntity(int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
    {
        ValidationDomain(usuarioId, livroId, dataEmprestimo, dataEntrega, entrega);
    }
    public void Update(int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
    {
        ValidationDomain(usuarioId, livroId, dataEmprestimo, dataEntrega, entrega);
    }

    public void ValidationDomain(int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
    {
        DomainExceptionValidation.When(int.IsNegative(usuarioId), "O O ID Do Usuário Não Deve Ser Negativo.");
        DomainExceptionValidation.When(usuarioId <= 0, "O Usuário Deve Ser Maior Que Zero.");

        DomainExceptionValidation.When(int.IsNegative(livroId), "O O ID Do Livro Não Deve Ser Negativo.");
        DomainExceptionValidation.When(livroId <= 0, "O Livro Deve Ser Maior Que Zero.");


        UsuarioId = usuarioId;
        LivroId = livroId;
        DataEmprestimo = dataEmprestimo;
        DataEntrega = dataEntrega;
        Entrega = entrega;
    }
}
