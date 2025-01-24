using Testes.Domain.ValueObjects;

namespace Testes.Test.ValuesObjects;
public class NameTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailIfValueObjectNameIsNullOrEmptyAndWhiteSpace(string name)
    {
        Assert.Throws<Exception>(()=>
        {
            var acount = new Name(name);
        });
    }

}
