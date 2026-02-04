namespace Program.Entities;

public abstract class ItemBiblioteca
{
    public string Titulo { get; set; }
    public string Id { get; set; }

    public ItemBiblioteca(string titulo, string id)
    {
        Titulo = titulo;
        Id = Id;
    }
    public abstract int ObterPrazoEmprestimo();

    public virtual void ExibirDetalhes()
    {
        Console.WriteLine($"ID: {Id} | Titulo: {Titulo} | Prazo: {ObterPrazoEmprestimo()} dias");
    }
}