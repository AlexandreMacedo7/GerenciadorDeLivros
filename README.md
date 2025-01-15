# Gerenciador de Livros

Este é um projeto de gerenciamento de livros para aprofundamento de conhecimento no ambiente CSharp, desenvolvido com Blazor, ASP.NET Core e MySQL. O sistema permite cadastrar, editar, listar e excluir livros.

Você pode visualizar a aplicação em funcionamento [aqui](http://3.147.68.100:5000/).

## Tecnologias Utilizadas

- **C#**
- **HTML**
- **CSS**
- **JavaScript**
- **.NET 8**
- **Blazor**
- **ASP.NET Core**
- **MySQL**
- **Entity Framework Core**
- **Bootstrap** (para estilização)
- **jQuery** (para manipulação de DOM)
- **DataTables** (para tabelas interativas)

## Requisitos

- .NET 8
- MySQL

## Configuração do Projeto

### 1. Clonar o Repositório
git clone https://github.com/AlexandreMacedo7/GerenciadorDeLivros.git cd gerenciador-de-livros

### 2. Configurar a String de Conexão

Atualize a string de conexão no arquivo `appsettings.json` com as credenciais do seu banco de dados MySQL:

`{"ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=Biblioteca;User=****;Password=****;" } }`

### 3. Configurar o Banco de Dados

Crie o banco de dados e a tabela necessária:

`CREATE DATABASE Biblioteca; USE Biblioteca;
CREATE TABLE Livros ( Id INT AUTO_INCREMENT PRIMARY KEY, Titulo VARCHAR(255) NOT NULL, Autor VARCHAR(255) NOT NULL, Editora VARCHAR(255) NOT NULL );`

-- Populando com alguns dados exemplo

`INSERT INTO Livros (Titulo, Autor, Editora) VALUES
('O Alquimista', 'Paulo Coelho', 'HarperOne'),
('1984', 'George Orwell', 'Secker & Warburg');`

### 4. Executar o Projeto

No diretório do projeto, execute o comando:

`dotnet run`

O projeto estará disponível em `http://localhost:5042` ou `http://localhost:13966` se estiver usando IIS Express.

## Estrutura do Projeto

- **Controllers**
  - `HomeController.cs`: Controlador para a página inicial e de privacidade.
  - `LivroController.cs`: Controlador para as operações de CRUD de livros.

- **Daos**
  - `LivroDao.cs`: Classe de acesso a dados para operações com a tabela de livros no MySQL.

- **Models**
  - `LivroModel.cs`: Modelo de dados para representar um livro.

- **Views**
  - `Home/Index.cshtml`: Página inicial.
  - `Livro/Index.cshtml`: Página de listagem de livros.
  - `Livro/Criar.cshtml`: Página para criar um novo livro.
  - `Livro/Editar.cshtml`: Página para editar um livro existente.
  - `Livro/ExcluirConfirmacao.cshtml`: Página para confirmar a exclusão de um livro.

- **wwwroot**
  - `css/site.css`: Arquivo de estilos CSS.
  - `js/site.js`: Arquivo de scripts JavaScript.

## Funcionalidades

- **Listagem de Livros**: Visualize todos os livros cadastrados.
- **Adicionar Livro**: Cadastre um novo livro.
- **Editar Livro**: Edite as informações de um livro existente.
- **Excluir Livro**: Exclua um livro do sistema.

## Configurações de Desenvolvimento

- **launchSettings.json**: Configurações de lançamento para o ambiente de desenvolvimento.

## Contribuição

Sinta-se à vontade para contribuir com o projeto. Faça um fork do repositório, crie uma branch para sua feature ou correção de bug, e envie um pull request.

## Licença

Este projeto está licenciado sob os termos da licença MIT.
