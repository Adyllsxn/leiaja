# LeiaJa

LeiaJa é um sistema de biblioteca online desenvolvido para facilitar o gerenciamento de livros, categorias, autores e usuários, permitindo a interação através de funcionalidades como favoritos, listas de leitura e recomendações personalizadas.

---

## Funcionalidades

- Autenticação e Perfis de Acesso: Usuários podem criar contas e acessar com diferentes permissões  (**Administrador** e **Leitor**).
- Cadastro e Gerenciamento:
    - Livros, autores e categorias.
    - Associação de livros a múltiplos autores e categorias.
- Listas de Leitura: Usuários podem criar e gerenciar listas personalizadas como "Quero Ler", "Lendo" e "Lidos".
- Favoritos: Usuários podem marcar livros como favoritos.
- Recomendações Inteligentes: Sugestão de livros baseada nos favoritos e histórico de leitura, utilizando ML.NET.
- Sistema de Avaliações e Comentários: Leitores podem avaliar e comentar sobre livros.
- Busca Avançada: Pesquisa de livros por título, autor, categoria ou palavras-chave.
- Funcionalidades adicionais a serem desenvolvidas ao longo do projeto.

---

## Tecnologias Utilizadas

### Backend
1. **.NET Core**: Framework principal para o backend.
2. **ASP.NET Core**: Para desenvolvimento da API RESTful.
3. **Entity Framework Core**: Para mapeamento objeto-relacional (ORM).
   - Providers: `InMemory`, `SQL Server`, `Design`.
4. **JWT Bearer**: Para autenticação e autorização via tokens JWT.
5. **ML.NET**: Para implementar recomendações baseadas em machine learning.

### Frontend
1. **Blazor**: Framework para desenvolvimento do frontend interativo e moderno.
2. **MudBlazor**: Biblioteca de componentes para Blazor.
3. **JavaScript**: Para integração com bibliotecas e funcionalidades adicionais.
4. **HTML**: Para a estrutura das páginas.
5. **CSS**: Para estilização e personalização da interface.
6. **Google Fonts**: Para incorporar fontes customizadas ao design.
7. **Bootstrap Icons**: Conjunto de ícones para usar na interface.

### Testes
1. **xUnit**: Framework para criação de testes de unidade e integração.
2. **Moq**: Para criação de mocks e stubs durante os testes.
3. **EntityFrameworkCore.InMemory**: Banco de dados em memória utilizado nos testes.

### Ferramentas e Bibliotecas Adicionais
1. **AutoMapper**: Para mapeamento entre objetos.
2. **Swashbuckle**: Para documentação da API com Swagger.
3. **EF Tools**: Para gerenciamento de migrações de banco de dados.

### Banco de Dados
1. **SQL Server**: Banco relacional para armazenamento dos dados do sistema.

> **Nota**: Outros frameworks e bibliotecas podem ser adicionados conforme o progresso do projeto.

---

## Configuração do Ambiente

### Requisitos

#### SDKs e Ferramentas
1. **.NET SDK 6.0** ou superior.
2. **SQL Server**.
3. **Visual Studio** ou **Visual Studio Code** (com extensão C#).

#### Pacotes NuGet
1. `Microsoft.EntityFrameworkCore` (InMemory, SQL Server, Design).
2. `AutoMapper`.
3. `Swashbuckle.AspNetCore`.
4. `Moq`.
5. `Microsoft.AspNetCore.Authentication.JwtBearer`.
6. `MudBlazor`.

---

## Funcionalidades Futuras

- Notificações automáticas para lembretes de leitura.
- Relatórios personalizados para usuários e administradores.
- Implementação de um sistema de gamificação para incentivar a leitura.
- Integração com serviços de e-mail para recomendações personalizadas.

---

## Gamificação no LeiaJá

- ***✅ Sistema de Estrelas**: Usuários ganham estrelas por atividades como:

   - Ler um livro até o fim 📖 ⭐
   - Avaliar e comentar livros 📝 ⭐
   - Compartilhar recomendações 📢 ⭐
   - Participar de desafios de leitura 🏆 ⭐

**🎁 Recompensas**: As estrelas podem ser trocadas por:

   - Cursos gratuitos sobre literatura, escrita ou temas variados 📚🎓
   - Acesso antecipado a novos livros 📕
   - Cupons de desconto em livrarias ou e-books 🏷️

---

## Estrutura do Projeto

A estrutura do projeto segue uma organização modular e de fácil manutenção:

```plaintext
LeiaJa/
├── src/                      # Código-fonte principal
│   ├── backend/              # Código do backend
│   │   ├── LeiaJa.Presentation/   # Camada de apresentação (API)
│   │   ├── LeiaJa.Application/    # Regras de negócios e serviços
│   │   ├── LeiaJa.Domain/         # Entidades de domínio e validações
│   │   ├── LeiaJa.Infrastructure/ # Acesso a dados e integração com o banco de dados
│   │   ├── LeiaJa.IoC/            # Configuração de injeção de dependências
│   ├── frontend/              # Código do frontend
│   │   ├── LeiaJa.Web/         # Interface do usuário (Blazor)
├── test/                      # Projetos de testes
│   ├── LeiaJa.UnitTest/        # Testes de unidade
│   ├── LeiaJa.IntegrationTest/        # Testes de integração
├── docs/                      # Documentação adicional do projeto
│   ├── Arquitetura.md          # Detalhes sobre a arquitetura do projeto
│   ├── API.md                  # Documentação da API (endpoints, contratos)
│   ├── GuiaDeInstalação.md     # Instruções de configuração do ambiente
│   ├── ROADMAP.md              # Planejamento de funcionalidades futuras
├── .github/                   # Configuração para GitHub Actions e workflows
│   ├── workflows/              # Automatização (ex: GitHub Pages, CI/CD)
├── README.md                  # Documentação principal do projeto
├── LeiaJa.sln                 # Solução do projeto


---



## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](./LICENSE) para mais detalhes.
