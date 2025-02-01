# API - LeiaJa

## Visão Geral

A API do **LeiaJá** é desenvolvida utilizando **ASP.NET Core** com **Controllers**, oferecendo funcionalidades para gerenciamento de livros, interações entre usuários, favoritos, listas de leitura, avaliações e comentários. A API utiliza JWT Bearer para autenticação e segurança.

### Endpoints Principais

#### 1. **Autenticação**

- **POST /api/auth/login**  
  Realiza o login e retorna um token JWT.

  **Exemplo de Request Body**:
  ```json
  {
    "username": "user1",
    "password": "senha123"
  }

- **POST /api/auth/register**  
  Registra um novo usuário no sistema, permitindo a criação de uma conta.

  **Exemplo de Request Body**:
  ```json
  {
    "username": "novoUsuario",
    "password": "senhaSegura123",
    "email": "usuario@exemplo.com"
  }


### Tecnologias Utilizadas

  - ASP.NET Core: Framework para o backend.
  - JWT Bearer: Para autenticação e autorização de usuários.
  - Entity Framework Core: ORM para interação com o banco de dados.
  - SQL Server: Banco de dados relacional para persistência dos dados.

### Como Usar

  - Realize o login com suas credenciais usando o endpoint /api/auth/login.
  - Use o token JWT para autenticar as requisições subsequentes, incluindo operações de favoritos, listas de leitura, avaliações e mais.
  - Realize operações CRUD sobre os livros, avaliações e listas de leitura para gerenciar a plataforma conforme necessário.
