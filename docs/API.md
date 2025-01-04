# API - LeiaJa

## Visão Geral

A API do **LeiaJa** é construída utilizando **ASP.NET Core** com **Controllers** e utiliza **JWT Bearer** para autenticação. A API permite a interação com o sistema para realizar operações de **empréstimo**, **devolução** de itens e **gerenciamento** de dados.

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
