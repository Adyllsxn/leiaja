namespace LeiaJa.Application.Error;
public class NonEmptyStringAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;
        return !string.IsNullOrWhiteSpace(value.ToString());
    }

    public override string FormatErrorMessage(string name)
    {
        return $"O Campo {name} Não Pode Ser Vazio Ou Conter Apenas Espaços Em Branco.";
    }
}
