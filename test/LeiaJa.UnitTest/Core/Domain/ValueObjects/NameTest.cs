namespace LeiaJa.UnitTest.Core.Domain.ValueObjects;
public class NameTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailIfValueObjectNameIsNullOrEmptyAndWhiteSpace(string name)
    {
        Assert.Throws<DomainExceptionValidation>(()=>
        {
            var acount = new Name(name);
        });
        
    }
}
