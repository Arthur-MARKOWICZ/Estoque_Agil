# Estoque Ágil 

![GitHub repo size](https://img.shields.io/github/repo-size/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge) 
![GitHub language count](https://img.shields.io/github/languages/count/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge) 
![GitHub top language](https://img.shields.io/github/languages/top/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge) 
![GitHub last commit](https://img.shields.io/github/last-commit/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge)
![GitHub issues](https://img.shields.io/github/issues/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/Arthur-MARKOWICZ/Estoque_Agil?style=for-the-badge)

**API de Controle de Estoque** desenvolvida em **ASP.NET Core**, com foco em boas práticas de desenvolvimento, testes automatizados, arquitetura limpa e documentação profissional.  

---
##  Objetivo do Projeto

O **Estoque Ágil** foi desenvolvido com o objetivo de **praticar e consolidar conhecimentos em desenvolvimento de APIs e back-end em C#**.  

Este projeto é um ambiente de aprendizado prático, onde foi possível:

- Aplicar conceitos de **arquitetura limpa** e boas práticas de desenvolvimento.  
- Criar endpoints RESTful utilizando **ASP.NET Core**.  
- Integrar a aplicação com **banco de dados relacional MySQL**.  
- Implementar **testes automatizados** para garantir qualidade do código.  
- Documentar a API usando **Swagger/OpenAPI**, facilitando testes e integrações futuras.

O foco principal não é apenas entregar um produto final, mas sim **aprender na prática como desenvolver o back-end de um sistema completo em C#**.



## 🛠 Tecnologias e Motivos

- **ASP.NET Core**: framework robusto para criar APIs RESTful de alto desempenho.
- **Entity Framework Core**: ORM que facilita o mapeamento entre banco relacional e objetos C#.
- **MySQL**: banco de dados relacional confiável, fácil de versionar e integrar via Docker.
- **Swagger/OpenAPI**: documentação interativa que facilita testes e integração com front-end.
- **xUnit**: framework de testes moderno e eficiente para unitários e integração.
- **Docker**: permite criar ambientes consistentes e isolados para o banco de dados.


![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-239120?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-239120?style=for-the-badge&logo=mysql&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-239120?style=for-the-badge&logo=entityframework&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-239120?style=for-the-badge&logo=swagger&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-239120?style=for-the-badge&logo=docker&logoColor=white)

---

## 🛠 Funcionalidades

### Produtos
- Cadastro de produtos  
- Consulta de estoque  
- Atualização de produtos  
- Remoção de produtos  

### Usuários
- Cadastro de usuário  
- Login  
- Atualização de usuário  
- Consulta de usuário  
- Remoção de usuário  

---

## 📊 Diagrama de Banco de Dados

```mermaid
erDiagram
    Usuario {
        int Id PK
        string Email
        string Senha
        string Nome
    }

    Produto {
        int Id PK
        string nome
        int UsuarioId FK
    }

    Usuario ||--o{ Produto : possui
```
## Skills Demonstradas

Back-End: ASP.NET Core, Entity Framework Core

Banco de Dados: MySQL, modelagem de dados, relacionamento

Boas Práticas: arquitetura limpa, versionamento, organização de commits

Testes(Em andamento): planejamento para testes unitários e de integração 

Documentação: Swagger/OpenAPI
##  Como Executar

Siga os passos abaixo para rodar a API **Estoque Ágil** localmente:

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/Arthur-MARKOWICZ/Estoque_Agil.git
cd Estoque_Agil
```
###2️⃣ Restaurar dependências

No diretório do projeto, execute:
```bash
dotnet restore
```

Isso irá baixar todas as bibliotecas e pacotes necessários para compilar a aplicação.

###3️⃣ Configurar e atualizar o banco de dados

O projeto utiliza MySQL, que pode ser executado via Docker ou localmente.
Depois de configurar o banco, rode:
```bash
dotnet ef database update

```
Isso aplicará todas as migrations e criará as tabelas necessárias.

###4️⃣ Executar a API

Para iniciar a API, execute:
```bash
dotnet run
```

A API estará disponível em:
```bash
https://localhost:5165/swagger
```

Abra este link no navegador para acessar a documentação interativa via Swagger, onde você pode testar todos os endpoints.

###5️⃣ Executar testes automatizados

O projeto possui testes planejados para unidade e integração. Para executá-los:
```bash
dotnet test
```

Isso irá rodar todos os testes e mostrar os resultados no terminal.

### 6️⃣ Observações importantes

Certifique-se de ter .NET SDK instalado (versão 9).

Caso utilize Docker, garanta que o container do MySQL esteja ativo.

Para problemas com certificados HTTPS, você pode rodar a API em HTTP temporariamente ajustando o arquivo launchSettings.json.
