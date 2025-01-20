namespace LeiaJa.Domain.Entities;
public sealed class LivroEntity : EntityBase
{
    public string Livro { get; private set; } = null!;
    public int AutorId { get; private set; }
    public int CategoriaId { get; set; }
    public string Editora { get; private set; } = null!;
    public DateTime AnoPublicacao { get; private set; }
    public string Edicao { get; private set; } = null!;
    public string Imagem { get; set; } = null!;
    public string Documento { get; set; } = null!;

    [JsonIgnore]
    public CategoriaEntity Categoria { get; set; } = null!;

    [JsonIgnore]
    public AutorEntity Autor { get; set; } = null!;

    [JsonIgnore]
    public ICollection<EmprestimoEntity> Emprestimos { get; set; } = null!;

    [JsonConstructor]
    public LivroEntity(int id, string livro, int autorId, int categoriaId, string editora, DateTime anoPublicacao, string edicao, string imagem, string documento)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Livro Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Livro Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(livro,autorId, categoriaId, editora, anoPublicacao, edicao, imagem, documento);
    }
    public LivroEntity( string livro, int autorId, int categoriaId, string editora, DateTime anoPublicacao, string edicao, string imagem, string documento)
    {
        ValidationDomain(livro,autorId, categoriaId, editora, anoPublicacao, edicao, imagem, documento);
    }
    public void Update(string livro, int autorId, int categoriaId, string editora, DateTime anoPublicacao, string edicao, string imagem, string documento)
    {
        ValidationDomain(livro,autorId, categoriaId, editora, anoPublicacao, edicao, imagem, documento);
    }
    public void ValidationDomain( string livro,int autorId, int categoriaId, string editora, DateTime anoPublicacao, string edicao, string imagem, string documento)
    {

        DomainExceptionValidation.When(string.IsNullOrEmpty(livro), "O Livro É Obrigatório.");
        DomainExceptionValidation.When(livro.Length > 200, "O Livro Não Pode Ter Mais De 200 Caracteres.");

        DomainExceptionValidation.When(int.IsNegative(autorId), "O ID Do Autor Não Pode Ser Negativo.");
        DomainExceptionValidation.When(autorId <= 0, "O ID Do Livro Deve Ser Maior Que Zero.");

        DomainExceptionValidation.When(int.IsNegative(categoriaId), "O ID Da Categoria Não Pode Ser Negativo.");
        DomainExceptionValidation.When(categoriaId <= 0, "O ID Da Categoria Deve Ser Maior Que Zero.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(editora), "A Editora É Obrigatória.");
        DomainExceptionValidation.When(editora.Length > 100, "A Editora Não Pode Ter Mais De 100 Caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(edicao), "A Edição É Obrigatória.");
        DomainExceptionValidation.When(edicao.Length > 100, "A Edição Não Pode Ter Mais De 100 Caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imagem), "A Imagem É Obrigatório.");
        DomainExceptionValidation.When(edicao.Length <= 1, "A Imagem Não Pode Ter Menos De 1 Caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(documento), "O Documento É Obrigatório.");
        DomainExceptionValidation.When(edicao.Length <= 1, "O documento Não Pode Ter Menos De 1 Caracteres.");


        Livro = livro;
        AutorId = autorId;
        CategoriaId = categoriaId;
        Editora = editora;
        AnoPublicacao = anoPublicacao;
        Edicao = edicao;
        Imagem = imagem;
        Documento = documento;
    }
}
