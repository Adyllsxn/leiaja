namespace LeiaJa.Domain.Interfaces;
public interface ISistemaRepository
{
    Task<QuantidadeEntity> GetQtdItems();
}
