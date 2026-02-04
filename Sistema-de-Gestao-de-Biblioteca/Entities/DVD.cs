using Program.Entities.Interfaces;

namespace Program.Entities;

public class DVD : ItemBiblioteca, IEmprestavel
{
    public bool EstaEmprestado { get; set; }
    public DateTime? DataDevolucao { get; private set; }
    
    public DVD(string titulo, string id) : base(titulo, id) { }

    public override int ObterPrazoEmprestimo() => 3;
    
    public void Emprestar(int dias)
    { 
        EstaEmprestado = true;
        DataDevolucao = DateTime.Now.AddDays(dias);
    }
    public void Devolver() => EstaEmprestado = false;
}