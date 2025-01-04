namespace LeiaJa.UnitTests.Entities;
public class AutorEntityTest
{
    #region NÃO CRIAR AUTOR SEM O ID
    [Fact(DisplayName = "Não Cria Autor Sem o ID")]
    public void CriarAutor_NaoCriaAutorSemID()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(0, "Test", "Test"));
        Assert.Equal("O ID Do Autor Deve Ser Positivo.", exception.Message);
    }
    #endregion

    #region NÃO CRIAR AUTOR SE O ID FOR NEGATIVO
    [Fact(DisplayName = "Não Cria Autor Com ID Negativo")]
    public void CriarAutor_NaoCriaAutorComIdNegativo()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(-1, "Test", "Test"));
        Assert.Equal("O ID Do Autor Não Pode Ser Negativo.", exception.Message);
    }
    #endregion

    #region NÃO CRIAR AUTOR SEM O NOME
    [Fact(DisplayName = "Não Cria Autor Sem Nome")]
    public void CriarAutor_NaoCriaAutorSemNome()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(1, "", "Test"));
        Assert.Equal("O Nome É Obrigatório.", exception.Message);
    }
    #endregion

    #region NÃO CRIAR AUTOR SEM O SOBRENOME
    [Fact(DisplayName = "Não Cria Autor Sem Sobrenome")]
    public void CriarAutor_NaoCriaAutorSemSobrenome()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(1, "Test", ""));
        Assert.Equal("O Sobrenome É Obrigatório.", exception.Message);
    }
    #endregion

    #region CRIAR AUTOR SEM ID
    [Fact(DisplayName = "Cria Autor Sem ID")]
    public void CriarAutor_ComNomeESobrenome_DeveCriarSemID()
    {
        var autor = new AutorEntity("Test", "Test");
        Assert.NotNull(autor);
        Assert.Equal("Test", autor.Nome);
        Assert.Equal("Test", autor.SobreNome);
    }
    #endregion

    #region CRIAR AUTOR COM ID
    [Fact(DisplayName = "Cria Autor Com ID")]
    public void CriarAutor_ComIdNomeESobrenome_DeveCriar()
    {
        var autor = new AutorEntity(1, "Test", "Test");
        Assert.NotNull(autor);
        Assert.Equal(1, autor.Id);
        Assert.Equal("Test", autor.Nome);
        Assert.Equal("Test", autor.SobreNome);
    }
    #endregion

    #region EDITAR AUTOR SEM ID
    [Fact(DisplayName = "Editar Autor Sem ID")]
    public void EditarAutor_SemId_DeveAtualizarPropriedades()
    {
        var autor = new AutorEntity("Test", "Test");
        autor.Update("Test1", "Test1");

        Assert.Equal("Test1", autor.Nome);
        Assert.Equal("Test1", autor.SobreNome);
    }
    #endregion

    #region EDITAR AUTOR COM ID
    [Fact(DisplayName = "Editar Autor Com ID")]
    public void EditarAutor_ComId_DeveAtualizarPropriedades()
    {
        var autor = new AutorEntity(1, "Test", "Test");
        autor.Update("Test1", "Test1");

        Assert.Equal("Test1", autor.Nome);
        Assert.Equal("Test1", autor.SobreNome);
    }
    #endregion

    #region NÃO PERMITIR NOME LONGO
    [Fact(DisplayName = "Não Cria Autor Com Nome Muito Longo")]
    public void CriarAutor_ComNomeMuitoLongo_DeveLancarExcecao()
    {
        var nomeLongo = new string('A', 59);

        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(1, nomeLongo, "Test"));
        Assert.Equal("O Nome Não Pode Ter Mais De 50 Caracteres.", exception.Message);
    }
    #endregion

    #region NÃO PERMITIR SOBRENOME LONGO
    [Fact(DisplayName = "Não Cria Autor Com Sobrenome Muito Longo")]
    public void CriarAutor_ComSobrenomeMuitoLongo_DeveLancarExcecao()
    {
        var sobrenomeLongo = new string('B', 56);

        var exception = Assert.Throws<DomainExceptionValidation>(() => new AutorEntity(1, "Test", sobrenomeLongo));
        Assert.Equal("O Sobrenome Não Pode Ter Mais De 50 Caracteres.", exception.Message);
    }
    #endregion
}
