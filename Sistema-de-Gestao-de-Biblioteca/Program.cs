using Program.Entities;

class Sistema
{
    static void Main()
    {
        Biblioteca bib = new Biblioteca();
        Usuario user = new Usuario("Admin", "001");

        while (true)
        {
            Console.WriteLine("\n=== GESTÃO DE ACERVO (CRUD) ===");
            Console.WriteLine("1. [C] Cadastrar Item");
            Console.WriteLine("2. [R] Listar Acervo");
            Console.WriteLine("3. [U] Atualizar Item");
            Console.WriteLine("4. [D] Remover Item");
            Console.WriteLine("5. Realizar Empréstimo");
            Console.WriteLine("6. Realizar Devolução");
            Console.WriteLine("0. Sair");
            Console.Write("Seleção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao)) continue;

            switch (opcao)
            {
                case 1:
                    MenuCadastro(bib);
                    break;
                case 2:
                    bib.ListarAcervo();
                    break;
                case 3:
                    Console.Write("ID do item para editar: ");
                    bib.AtualizarItem(Console.ReadLine()?.ToUpper());
                    break;
                case 4:
                    Console.Write("ID do item para remover: ");
                    bib.RemoverItem(Console.ReadLine()?.ToUpper());
                    break;
                case 5:
                    Console.Write("ID para empréstimo: ");
                    bib.RealizarEmprestimo(Console.ReadLine()?.ToUpper(), user);
                    break;
                case 6:
                    Console.WriteLine("\n--- DEVOLUÇÃO DE ITEM ---");
                    Console.Write("Digite o ID do item que deseja devolver: ");
                    string idDevolucao = Console.ReadLine()?.ToUpper();
                    bib.RealizarDevolucao(idDevolucao, user);
                    break;
                case 0:
                    return;
            }
        }
    }
    static void MenuCadastro(Biblioteca bib)
    {
        Console.WriteLine("\n--- NOVO CADASTRO ---");
        Console.Write("ID: ");
        string id = Console.ReadLine()?.Trim();
    
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.WriteLine("Autor: ");
        string autor = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("[ERRO] ID e Título são obrigatórios.");
            return;
        }
        bib.CadastrarItem(new Livro(titulo, id, autor));
    }
}