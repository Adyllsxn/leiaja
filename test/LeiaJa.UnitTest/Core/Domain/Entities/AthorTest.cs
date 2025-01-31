namespace LeiaJa.UnitTest.Core.Domain.Entities;
public class AthorTest
{
    #region <Constants>
    private const int InvalidNumberZero = 0;
    private const int InvalidNumber = -1;
    private const string ValidFisrtName = "Test0";
    private const string ValidLastName = "Test1";
    private const string ValidPhoto = "123456789.jpng";
    #endregion </Constants>

    #region <Id>
    [Theory]
    [InlineData(InvalidNumber, ValidFisrtName, ValidLastName, ValidPhoto)]
    [InlineData(InvalidNumberZero, ValidFisrtName,ValidLastName, ValidPhoto)]
    public void ShouldFailIfIdIsNegative(int id, string firstName, string lastName, string photo)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new AthorEntity(id, firstName,lastName, photo);
        });
    }
    #endregion </Id>

    #region <FirstName>
    [Theory]
    [InlineData("", ValidLastName, ValidPhoto)]
    [InlineData(null, ValidLastName, ValidPhoto)]
    [InlineData(" ", ValidLastName, ValidPhoto)]
    public void ShouldFailIfFisrtNameIsNullOrEmptyOrWhiteSpace(string firstName, string lastName, string photo)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new AthorEntity(firstName, lastName, photo);
        });
    }
    #endregion </FirstName>

    #region <LasttName>
    [Theory]
    [InlineData(ValidFisrtName, "", ValidPhoto)]
    [InlineData(ValidFisrtName, null, ValidPhoto)]
    [InlineData(ValidFisrtName, " ", ValidPhoto)]
    public void ShouldFailIfLastNameIsNullOrEmptyOrWhiteSpace(string firstName, string lastName, string photo)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new AthorEntity(firstName, lastName, photo);
        });
    }
    #endregion </LasttName>

    #region <Photo>
    [Theory]
    [InlineData(ValidFisrtName, ValidLastName, "")]
    [InlineData(ValidFisrtName, ValidLastName, null)]
    [InlineData(ValidFisrtName, ValidLastName, " ")]
    public void ShouldFailIfPhotoIsNullOrEmptyOrWhiteSpace(string firstName, string lastName, string photo)
    {
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new AthorEntity(firstName, lastName, photo);
        });
    }
    #endregion </Photo>

    #region <LongLenght>
    [Fact]
    public void ShouldFailIfIsHaveLongLenghtInAthor()
    {
        var LongLenght = new string('B', 56);
        Assert.True(true); Assert.Throws<DomainExceptionValidation>(() =>
        {
            var acount = new AthorEntity(LongLenght, LongLenght, ValidPhoto);
        });
    }
    #endregion </LongLenght>

    #region <Create>
    [Theory]
    [InlineData(ValidFisrtName, ValidLastName, ValidPhoto)]
    public void ShouldCreateAthor(string firstName, string lastName, string photo)
    {
        var count = new AthorEntity(firstName, lastName, photo);
        Assert.NotNull(count);
    }
    #endregion <Create>

    #region <Update>
    [Theory]
    [InlineData(ValidFisrtName, ValidLastName, ValidPhoto)]
    public void ShouldEditAthor(string firstName, string lastName, string photo)
    {
        var count = new AthorEntity(firstName, lastName, photo);
        count.Update("Test", "Test", "Test");
        Assert.Equal("Test", count.FirstName);
        Assert.Equal("Test", count.LastName);
        Assert.Equal("Test", count.Photo);
    }
    #endregion </Update>
}
