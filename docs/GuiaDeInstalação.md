# Guia de Instalação - LeiaJa

## Pré-requisitos

Antes de começar, é necessário ter os seguintes componentes instalados:

1. **.NET SDK 6.0 ou superior**
2. **SQL Server** (utilizando Docker)
3. **Visual Studio ou Visual Studio Code** com a extensão C# instalada
4. **Docker** (para rodar o SQL Server)

### Passos para Configuração

#### 1. Clonar o Repositório

Clone o repositório do GitHub:

```bash
git clone https://github.com/Adyllson/LeiaJa
cd LeiaJa

2. Configurar o Banco de Dados

O banco de dados SQL Server está configurado para ser executado no Docker. Para iniciar o container Docker do SQL Server, execute o seguinte comando:
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Adyllsxn@sa#2003' -p 1433:1433 --name sqlserver-container -d mcr.microsoft.com/mssql/server:2022-latest

3. Configurar a String de Conexão

No arquivo appsettings.json, a string de conexão do banco de dados já está configurada para o Docker:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=DB_LeiaJa;User Id=sa;Password=Adyllsxn@sa#2003;Encrypt=false;"
}


4. Rodar o Projeto

Execute o seguinte comando para restaurar as dependências e rodar o projeto:
dotnet restore
dotnet run

5. Testar a API

Use o Postman ou qualquer outro cliente HTTP para interagir com a API, utilizando os endpoints descritos em API.md.