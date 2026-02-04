using Program.Entities.Interfaces;

namespace Program.Entities;

public class Livro : ItemBiblioteca, IEmprestavel
{
    public string Autor { get; set; }
    public bool EstaEmprestado { get; private set; }
    public DateTime? DataDevolucao { get; private set; }

    public Livro(string titulo, string id, string autor) : base(titulo, id)
    {
        Titulo = titulo;
        Id = id;
        Autor = autor;
    }

    public override int ObterPrazoEmprestimo() => 14;
    
    public void Emprestar(int dias)
    { 
        EstaEmprestado = true;
        DataDevolucao = DateTime.Now.AddDays(dias);
    }

    public void Devolver()
    {
        EstaEmprestado = false;
        DataDevolucao = null;
    }
}