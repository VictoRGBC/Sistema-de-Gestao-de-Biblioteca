---

# 📚 Sistema de Gestão de Biblioteca (POO em C#)

Este projeto é uma aplicação de console desenvolvida em **C#** focada em demonstrar os pilares da **Orientação a Objetos**. O sistema gerencia o acervo de uma biblioteca, permitindo o controle de empréstimos, devoluções e cálculo automático de multas.

## 🚀 Funcionalidades (CRUD + Business Logic)

O sistema oferece um gerenciamento completo de itens:

* **Create**: Cadastro de Livros e DVDs com validação de ID único.
* **Read**: Listagem detalhada do acervo, exibindo status de disponibilidade.
* **Update**: Edição de títulos e autores de itens existentes.
* **Delete**: Remoção de itens (com trava de segurança para itens emprestados).
* **Regras de Negócio**:
* Cálculo de **Data de Devolução** automática (Livro: 14 dias | DVD: 3 dias).
* Controle de **Limite de Empréstimos** por usuário (máximo 3 itens).
* Cálculo de **Multa por Atraso** (R$ 2,00 por dia).



---

## 🏗️ Conceitos de POO Aplicados

Para garantir um código limpo e escalável, foram utilizados:

| Conceito | Aplicação no Projeto |
| --- | --- |
| **Abstração** | Classe `ItemBiblioteca` define o molde essencial para qualquer item do acervo. |
| **Herança** | `Livro` e `DVD` herdam propriedades comuns e adicionam seus comportamentos específicos. |
| **Interface** | `IEmprestavel` define o contrato para itens que podem circular fora da biblioteca. |
| **Polimorfismo** | O método `ObterPrazoEmprestimo()` retorna valores diferentes dependendo do tipo do objeto. |
| **Encapsulamento** | Propriedades como `EstaEmprestado` possuem *setters* privados, protegendo o estado do objeto. |

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem**: C# (.NET 6.0 ou superior)
* **Paradigma**: Orientação a Objetos (OOP)
* **Coleções**: `List<T>` e consultas com **LINQ**.

---

## 📥 Como Executar

1. Certifique-se de ter o **SDK do .NET** instalado.
2. Clone este repositório:
```bash
git clone https://github.com/seu-usuario/sistema-biblioteca-csharp.git

```


3. Navegue até a pasta do projeto e execute:
```bash
dotnet run

```



---

## 📝 Exemplo de Uso

Ao listar o acervo após um empréstimo, o sistema exibe:
`[ID: L01] - Clean Code | Status: Emprestado (Devolução: 18/02/2026)`

Se o item for devolvido após a data, o sistema emite:
`[MULTA] R$ 10,00 por 5 dias de atraso.`

---

**Desenvolvido por Victor como projeto de estudo em C#.**

---
