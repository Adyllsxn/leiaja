namespace LeiaJa.Domain.ValueObjects;
public class Email
{
    #region <Propriety>
        private const short MinLenght = 3;
        public string Address { get;}

    #endregion </Propriety >
    
    #region <Method>
        public Email(string address)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(address), "Email Inválido.");
            DomainExceptionValidation.When(address.Length < MinLenght, "Email Inválido."); 
            
            Address = address;
        } 
    #endregion </Method>

    #region <Convertor>
        public static implicit operator string(Email email) => email.Address;
        public static implicit operator Email(string address) => new Email(address);
    #endregion
}
