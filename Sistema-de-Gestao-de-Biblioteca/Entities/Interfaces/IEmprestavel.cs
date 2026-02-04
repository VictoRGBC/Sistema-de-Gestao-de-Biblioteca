namespace Program.Entities.Interfaces;

public interface IEmprestavel
{
    bool EstaEmprestado { get; }
    DateTime? DataDevolucao { get; }
    void Emprestar(int dias);
    void Devolver();
}