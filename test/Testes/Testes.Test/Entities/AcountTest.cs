using System.ComponentModel;
using Testes.Domain.Entities;

namespace Testes.Test.Entities;
public class AcountTest
{
    private const string ValidName = "Test";
    private const string ValidEmail = "test@gmail.com";
    private const string ValidDocument = "123456789";

    [Theory]
    [InlineData(null,ValidEmail, ValidDocument)]
    [InlineData("",ValidEmail, ValidDocument)]
    [InlineData(" ",ValidEmail, ValidDocument)]
    public void ShouldFailIfNameIsNullOrEmptyAndWhiteSpace(string name, string email, string document)
    {
        Assert.Throws<Exception>(()=>
        {
            var acount = new AcountEntity(name, email, document);
        });
    }

    [Theory]
    [InlineData("test","","12343")]
    [InlineData("te", null,"12343")]
    [InlineData("tt"," ","12343")]
    public void ShouldFailIfEmailIsNullOrEmptyAndWhiteSpace(string name, string email, string document)
    {
        Assert.Throws<Exception>(()=>
        {
            var acount = new AcountEntity(name, email, document);
        });
    }

    [Theory]
    [InlineData("test","teste"," ")]
    [InlineData("teste", "teste","")]
    [InlineData("tt","teste",null)]
    public void ShouldFailIfDocumentIsNullOrEmptyAndWhiteSpace(string name, string email, string document)
    {
        Assert.Throws<Exception>(()=>
        {
            var acount = new AcountEntity(name, email, document);
        });
    }


    
}
