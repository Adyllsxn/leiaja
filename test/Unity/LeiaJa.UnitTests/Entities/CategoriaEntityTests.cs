namespace LeiaJa.UnitTests.Entities;
public class CategoriaEntityTests
{
    #region NÃO CRIA CATEGORIA SEM O ID 
    [Fact(DisplayName = "Não Cria Categoria Sem O ID")]
    public void CriarCategoria_NaoCriaCategoriaSemID()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(()=> new CategoriaEntity(0,"Teste"));
        Assert.Equal("O ID Da Categoria Deve Ser Maior Que Zero.", exception.Message);
    }
    #endregion

    #region NÃO CRIA CATEGORIA SE O ID FOR NEGATIVA
    [Fact(DisplayName = "Não Cria Categoria Se O ID For Negativa")]
    public void CriarCategoria_NaoCriaCategoriaSeIDForNegativa()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(()=> new CategoriaEntity(-1, "Teste"));
        Assert.Equal("O ID Da Categoria Não Pode Ser Negativo.", exception.Message);
    }
    #endregion

    #region NÃO CRIA CATEGORIA SEM O NOME
    [Fact(DisplayName = "Não Cria Categoria Sem O Nome")]
    public void CriarCategoria_NaoCriaCategoriaSemNome()
    {
        var exception = Assert.Throws<DomainExceptionValidation>(()=> new CategoriaEntity(1,""));
        Assert.Equal("A Categoria É Obrigatório.", exception.Message);
    }
    #endregion

    #region CRIAR CATEGORIA SEM O ID
    [Fact(DisplayName = "Criar Categoria Sem O ID")]
    public void CriarCategoria_DeveCriarCategoriaSemID()
    {
        var exception = new CategoriaEntity("Teste");
        Assert.NotNull(exception);
    }
    #endregion

    #region CRIAR CATEGORIA COM O ID
    [Fact(DisplayName = "Criar Categoria Com ID")]
    public void CriarCategoria_DeveCriCategoriaComID()
    {
        var exception = new CategoriaEntity(1,"Teste");
        Assert.NotNull(exception);
    }
    #endregion

    #region EDITAR CATEGORIA SEM O ID
    [Fact(DisplayName = "Editar Categoria Sem O ID")]
    public void EditarCategoria_DeveEditarCategoriaSemID()
    {
        var categoria = new CategoriaEntity("Teste");
        categoria.Update("Teste1");
        Assert.Equal("Teste1", categoria.Categoria);
    }
    #endregion

    #region EDITAR CATEGORIA COM ID
    [Fact(DisplayName = "Editar Categoria Com ID")]
    public void EditarCategoria_DeveEditarCategoriaComID()
    {
        var categoria = new CategoriaEntity(1,"Teste");
        categoria.Update("Teste1");
        Assert.Equal("Teste1", categoria.Categoria);
    }
    #endregion

    #region NÃO PERMITIR NOME LONGO
    [Fact(DisplayName = "Não Criar Categoria Com Nome Muito Longo")]
    public void CriarCategoria_NaoCriarCategoriaComNomeLongo()
    {
        var nomeLongo = new string('A',51);
        var exception = Assert.Throws<DomainExceptionValidation>(()=> new CategoriaEntity(nomeLongo));
        Assert.Equal("A Categoria Não Pode Ter Mais De 50 Caracteres.", exception.Message);
    }
    #endregion
}
