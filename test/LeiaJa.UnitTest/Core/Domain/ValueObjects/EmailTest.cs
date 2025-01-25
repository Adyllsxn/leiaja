namespace LeiaJa.UnitTest.Core.Domain.ValueObjects;
public class EmailTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailIfValueObjectNameIsNullOrEmptyAndWhiteSpace(string email)
    {
        Assert.Throws<DomainExceptionValidation>(()=>
        {
            var acount = new Email(email);
        });
        
    }
}
