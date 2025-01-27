namespace LeiaJa.Domain.ValueObjects;
public sealed record Name : ValueObject
{
    #region <Propriety>
        private const short MaxLenght = 50;
        public string FirstName { get; }
    #endregion </Propriety>
    
    #region <Method>
        public Name(string firstname)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(firstname), "Nome Inválido.");
            DomainExceptionValidation.When(firstname.Length > MaxLenght, "Nome Inválido"); 
            
            FirstName = firstname;
        } 
    #endregion </Method>
    
    #region <Convertor>
        public static implicit operator string(Name name) => name.FirstName;
        public static implicit operator Name(string firstname) => new Name(firstname);
    #endregion <Convertor>

    }
