namespace LeiaJa.UnitTest.Core.Domain.Entities;
public class CategoryTest
{

    #region <Constants>
    private const int InvalidNumberZero = 0;
    private const int InvalidNumber = -1;
    private const string ValidCategory = "Test";
    private const string ValidDescription = "Test This Category";
    #endregion </Constants>

    #region <Id>
    [Theory]
    [InlineData(InvalidNumber, ValidCategory, ValidDescription)]
    [InlineData(InvalidNumberZero, ValidCategory, ValidDescription)]
    public void ShouldFailIfIdIsNegative(int id, string category, string description)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new CategoryEntity(id, category, description);
        });
    }
    #endregion </Id>

    #region <Category>
    [Theory]
    [InlineData("", ValidDescription)]
    [InlineData(null, ValidDescription)]
    [InlineData(" ", ValidDescription)]
    public void ShouldFailIfCategoryIsNullOrEmptyOrWhiteSpace(string category, string description)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new CategoryEntity(category, description);
        });
    }
    #endregion </Category>

    #region <Description>
    [Theory]
    [InlineData(ValidCategory, "")]
    [InlineData(ValidCategory, null)]
    [InlineData(ValidCategory, " ")]
    public void ShouldFailIfDescriptionIsNullOrEmptyOrWhiteSpace(string category, string description)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new CategoryEntity(category, description);
        });
    }
    #endregion </Description>

    #region <LongLenght>
    [Fact]
    public void ShouldFailIfIsHaveLongLenghtInCategory()
    {
        var LongLenght = new string('B', 56);
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new CategoryEntity(LongLenght, LongLenght);
        });
    }
    #endregion </LongLenght>
    
    #region <Create>
    [Theory]
    [InlineData(ValidCategory, ValidDescription)]
    public void ShouldCreateCategory(string category, string description)
    {
        var count = new CategoryEntity(category, description);
        Assert.NotNull(count);
    }
    #endregion <Create>

    #region <Update>
    [Theory]
    [InlineData(ValidCategory, ValidDescription)]
    public void ShouldEditCategory(string category, string description)
    {
        var count = new CategoryEntity(category, description);
        count.Update("Teste", "Teste");
        Assert.Equal("Teste", count.Category);
        Assert.Equal("Teste", count.Description);
    }
    #endregion </Update>

}
