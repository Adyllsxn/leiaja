namespace Testes.Domain.ValueObjects;
public record Document : ValueObject
{
    public string File { get;}
    public Document(string file)
    {
        if(string.IsNullOrWhiteSpace(file))
            throw new Exception("Document inválido");
        File = file;
    }
    public static implicit operator Document(string file) => new Document(file);
    public static implicit operator string(Document document) => document.File;
}
