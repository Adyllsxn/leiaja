namespace LeiaJa.Domain.Entities
{
    public sealed class MunicipioEntity : EntityBase
    {
        public string Municipio { get; private set; } = null!;
        public int ProvinciaId { get; private set; }

        [JsonIgnore]
        public ProvinciaEntity Provincia { get; set; } = null!;

        [JsonIgnore]
        public ICollection<UsuarioEntity> Usuarios { get; set; } = null!;

        [JsonConstructor]
        public MunicipioEntity(){}
        public MunicipioEntity(int id, string municipio, int provinciaId)
        {
            DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Municipio Não Deve Ser Negativo.");
            DomainExceptionValidation.When(id <= 0, "O ID do Municipio Deve Ser Maior Que Zero.");
            Id = id;
            ValidationDomain(municipio, provinciaId);
        }
        public MunicipioEntity(string municipio, int provinciaId)
        {
            ValidationDomain(municipio, provinciaId);
        }
        public void Update(string municipio, int provinciaId)
        {
            ValidationDomain(municipio, provinciaId);
        }
        public void ValidationDomain(string municipio, int provinciaId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(municipio), "O Municipio É Obrigatório.");
            DomainExceptionValidation.When(municipio.Length > 30, "O Municipio Não Pode Ter Mais De 30 Caracteres.");

            DomainExceptionValidation.When(int.IsNegative(provinciaId), "Provincia Não Deve Ser Negativa.");
            DomainExceptionValidation.When(provinciaId <= 0, "O Provincia Deve Ser Maior Que Zero.");

            Municipio = municipio;
            ProvinciaId = provinciaId;
        }
    }
}