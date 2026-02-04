using Program.Entities;
using Program.Entities.Interfaces;

public class Biblioteca
{
    private List<ItemBiblioteca> _acervo = new List<ItemBiblioteca>();

    public void AdicionarItem(ItemBiblioteca item)
    {
        _acervo.Add(item);
        Console.WriteLine($"[INFO] {item.Titulo} adicionado ao acervo.");
    }
    
    public void CadastrarItem(ItemBiblioteca novoItem)
    {
        bool idJaExiste = _acervo.Any(i => i.Id.Equals(novoItem.Id, StringComparison.OrdinalIgnoreCase));

        if (idJaExiste)
        {
            Console.WriteLine($"\n[ERRO] Não foi possível cadastrar: O ID '{novoItem.Id}' já está em uso!");
            return;
        }

        _acervo.Add(novoItem);
        Console.WriteLine($"\n[SUCESSO] '{novoItem.Titulo}' cadastrado com o ID: {novoItem.Id}");
    }

    public void RemoverItem(string id)
    {
        var item = _acervo.FirstOrDefault(i => i.Id == id);
        if (item == null) 
        {
            Console.WriteLine("[ERRO] Item não encontrado.");
            return;
        }
    
        if (item is IEmprestavel e && e.EstaEmprestado)
        {
            Console.WriteLine("[ERRO] Não é possível remover um item que está emprestado.");
            return;
        }

        _acervo.Remove(item);
        Console.WriteLine("[SUCESSO] Item removido do acervo.");
    }
    
    public void AtualizarItem(string id)
    {
        var item = _acervo.FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            Console.WriteLine("[ERRO] Item não localizado para atualização.");
            return;
        }

        Console.WriteLine($"Editando: {item.Titulo}");
        Console.Write("Novo Título (deixe em branco para manter): ");
        string novoTitulo = Console.ReadLine();
    
        if (!string.IsNullOrWhiteSpace(novoTitulo))
            item.Titulo = novoTitulo;
        
        if (item is Livro livro)
        {
            Console.Write($"Novo Autor [{livro.Autor}]: ");
            string novoAutor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoAutor))
                livro.Autor = novoAutor;
        }

        Console.WriteLine("[SUCESSO] Dados atualizados!");
    }

    public void RealizarEmprestimo(string idItem, Usuario usuario)
    {
        var item = _acervo.FirstOrDefault(i => i.Id == idItem);

        if (item is IEmprestavel emprestavel && !emprestavel.EstaEmprestado)
        {
            if (usuario.PodePegarEmprestado())
            {
                emprestavel.Emprestar(item.ObterPrazoEmprestimo());
            
                usuario.AdicionarItem(emprestavel);
            
                Console.WriteLine($"[SUCESSO] {item.Titulo} emprestado para {usuario.Nome}!");
            }
            else
            {
                Console.WriteLine($"[LIMITE] {usuario.Nome} já possui o máximo de itens.");
            }
        }
    }

    public void ListarAcervo()
    {
        Console.WriteLine("\n--- ACERVO DA BIBLIOTECA ---");
        if (_acervo.Count == 0)
        {
            Console.WriteLine("O acervo está vazio.");
            return;
        }

        foreach (var item in _acervo)
        {
            string status = "Disponível";
            string dataDev = "";

            if (item is IEmprestavel e)
            {
                if (e.EstaEmprestado)
                {
                    status = "Emprestado";
                    dataDev = $" (Devolução: {e.DataDevolucao?.ToShortDateString()})";
                }
            }
            Console.WriteLine($"[ID: {item.Id}] - {item.Titulo} | Status: {status}{dataDev}");
        }
        Console.WriteLine("----------------------------");
    }
    
    public void RealizarDevolucao(string id, Usuario usuario)
    {
        var item = _acervo.FirstOrDefault(i => i.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        if (item == null) {
            Console.WriteLine("[ERRO] Item não encontrado.");
            return;
        }

        if (item is IEmprestavel emprestavel && emprestavel.EstaEmprestado)
        {
            DateTime dataHoje = DateTime.Now;

            if (dataHoje > emprestavel.DataDevolucao)
            {
                TimeSpan atraso = dataHoje - emprestavel.DataDevolucao.Value;
                int diasDeAtraso = atraso.Days;
                double multa = diasDeAtraso * 2.00;

                Console.WriteLine($"\n[ATENÇÃO] Item devolvido com {diasDeAtraso} dias de atraso!");
                Console.WriteLine($"[MULTA] Valor a pagar: R$ {multa:F2}");
            }
            else
            {
                Console.WriteLine("\n[SUCESSO] Item devolvido dentro do prazo. Parabéns!");
            }
            emprestavel.Devolver();
            usuario.RemoverItem(emprestavel);
        }
        else
        {
            Console.WriteLine("[ERRO] Este item não consta como emprestado.");
        }
    }
}