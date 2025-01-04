# Arquitetura do Projeto LeiaJa

## Introdução

Este projeto segue uma arquitetura **Clean Architecture** para o backend, visando separar as responsabilidades e facilitar a manutenção e evolução do sistema. O frontend utiliza a arquitetura **Vertical Slice Architecture** com o Blazor WebAssembly (BlazorWASM), garantindo uma interação mais fluída e modular.

### Backend - Clean Architecture

A estrutura do backend é organizada em várias camadas, com o objetivo de desacoplar as responsabilidades, permitindo maior escalabilidade e testabilidade. A organização segue o padrão da **Clean Architecture** e é dividida da seguinte forma:

#### Camadas do Backend:

1. **LeiaJa.Presentation**:
   - Camada responsável pela apresentação da API. Contém os **Controllers** que gerenciam as requisições HTTP e retornam as respostas. Os controllers interagem com a camada de **Application** para aplicar a lógica de negócios.
   
2. **LeiaJa.Application**:
   - Contém a lógica de negócios do sistema. Aqui são implementados os casos de uso da aplicação. Ela depende das camadas **Domain** e **Infrastructure**, mas não deve depender diretamente da camada de apresentação (API).

3. **LeiaJa.Domain**:
   - Representa o domínio do sistema, com entidades e regras de negócio. Não deve depender de outras camadas e deve ser o núcleo da aplicação.

4. **LeiaJa.Infrastructure**:
   - Responsável pela implementação dos serviços de acesso a dados, como repositórios e integrações com bancos de dados e outros sistemas externos. É a camada que se comunica diretamente com o banco de dados e realiza as operações de leitura e escrita.

5. **LeiaJa.IoC**:
   - Contém a configuração de **Injeção de Dependência** (DI). É aqui que os serviços e repositórios são registrados e injetados nas camadas correspondentes.

### Frontend - Vertical Slice Architecture com Blazor

O frontend é desenvolvido utilizando **Blazor WebAssembly (BlazorWASM)**, com uma arquitetura orientada por *Slices*, onde cada funcionalidade do sistema é tratada como uma unidade independente. Cada slice pode conter componentes de UI, lógica de negócios e acesso a dados necessários para aquela funcionalidade.

### Comunicação entre Backend e Frontend

A comunicação entre o frontend e o backend é realizada via **API RESTful**. O backend expõe endpoints através dos **Controllers** e o frontend consome esses endpoints para exibir os dados para o usuário.

---

### API.md

```markdown
# API - LeiaJa

## Visão Geral

A API do LeiaJa é construída utilizando **ASP.NET Core** com **Controllers**. A API permite a interação com o sistema para realizar operações de **empréstimo**, **devolução** de itens e **gerenciamento** de dados. 

### Endpoints Principais

#### 1. Autenticação

- **POST /api/auth/login**  
  Realiza o login e retorna um token JWT.

  **Exemplo de Request Body**:
  ```json
  {
    "username": "user1",
    "password": "senha123"
  }
