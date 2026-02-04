using Program.Entities.Interfaces;

public class Usuario
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    
    public List<IEmprestavel> ItensEmprestados { get; private set; }
    private const int LIMITE_EMPRESTIMO = 3;

    public Usuario(string nome, string matricula)
    {
        Nome = nome;
        Matricula = matricula;
        ItensEmprestados = new List<IEmprestavel>();
    }

    public bool PodePegarEmprestado()
    {
        return ItensEmprestados.Count < LIMITE_EMPRESTIMO;
    }

    public void AdicionarItem(IEmprestavel item)
    {
        if (PodePegarEmprestado())
        {
            ItensEmprestados.Add(item);
        }
    }

    public void RemoverItem(IEmprestavel item)
    {
        if (ItensEmprestados.Contains(item))
        {
            ItensEmprestados.Remove(item);
        }
    }
}