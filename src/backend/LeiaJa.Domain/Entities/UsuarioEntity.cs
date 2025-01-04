namespace LeiaJa.Domain.Entities;
public sealed class UsuarioEntity : EntityBase
{

        public string Nome { get; private set; } = null!;
        public string SobreNome { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public byte[] PasswordHash { get; private set; } = null!;
        public byte[] PasswordSalt { get; private set; } = null!;
        public int GeneroId { get; private set; }
        public int TipoUsuarioId { get; private set; }
        public int MunicipioId { get; private set; }

        [JsonIgnore]
        public ICollection<TelefoneEntity> Telefones { get; set; } = null!;

        [JsonIgnore]
        public ICollection<EmprestimoEntity> Emprestimos { get; set; } = null!;

        [JsonIgnore]
        public GeneroEntity Genero { get; set; } = null!;

        [JsonIgnore]
        public TipoUsuarioEntity TipoUsuario { get; set; } = null!;

        [JsonIgnore]
        public MunicipioEntity Municipio { get; set; } = null!;

        [JsonConstructor]
        public UsuarioEntity(){}

        public UsuarioEntity(int id, string nome, string sobreNome, string emial, int generoId, int tipoUsuarioId, int municipioId)
        {
                DomainExceptionValidation.When(int.IsNegative(id), "O ID da Provincia Não Deve Ser Negativo.");
                DomainExceptionValidation.When(id <= 0, "O ID da Provincia Deve Ser Maior Que Zero.");
                Id = id;
                ValidationDomain(nome, sobreNome, emial, generoId, tipoUsuarioId, municipioId);
        }
        public UsuarioEntity(string nome, string sobreNome, string emial, int generoId, int tipoUsuarioId, int municipioId)
        {
                ValidationDomain(nome, sobreNome, emial, generoId, tipoUsuarioId, municipioId);
        }
        public void Update(string nome, string sobreNome, string emial, int generoId, int tipoUsuarioId, int municipioId)
        {
                ValidationDomain(nome, sobreNome, emial, generoId, tipoUsuarioId, municipioId);
        }
        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
                PasswordHash = passwordHash;
                PasswordSalt = passwordSalt;
        }
        public void ValidationDomain(string nome, string sobreNome, string emial, int generoId, int tipoUsuarioId, int municipioId)
        {
                DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O Nome É Obrigatório.");
                DomainExceptionValidation.When(nome.Length > 50, "O Nome Não Pode Ter Mais De 50 Caracteres.");

                DomainExceptionValidation.When(string.IsNullOrEmpty(sobreNome), "O SobreNome É Obrigatório.");
                DomainExceptionValidation.When(sobreNome.Length > 50, "O SobreNome Não Pode Ter Mais De 50 Caracteres.");

                DomainExceptionValidation.When(string.IsNullOrEmpty(emial), "O Email É Obrigatório.");
                DomainExceptionValidation.When(nome.Length > 200, "O Email Não Pode Ter Mais De 200 Caracteres.");

                DomainExceptionValidation.When(int.IsNegative(generoId), "O Genero Não Deve Ser Negativo.");
                DomainExceptionValidation.When(generoId <=0 , "O Genero Deve Ser Maior Que Zero.");

                DomainExceptionValidation.When(int.IsNegative(tipoUsuarioId), "O Tipo De Usuário Não Deve Ser Negativo.");
                DomainExceptionValidation.When(generoId <=0 , "O Tipo De Usuário Deve Ser Maior Que Zero.");

                DomainExceptionValidation.When(int.IsNegative(municipioId), "O Municipio Não Deve Ser Negativo.");
                DomainExceptionValidation.When(generoId <=0 , "O Municipio Deve Ser Maior Que Zero.");
        }
}
