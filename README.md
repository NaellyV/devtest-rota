## E-commerce System

Este repositório contém uma solução para um **teste técnico** de E-commerce, incluindo uma **API em .NET 8.0** e um **Frontend em Next.js com TailwindCSS**.

> ⚠️ **Observação:**  
> Este projeto foi desenvolvido como parte de um **teste técnico** e não contempla todas as funcionalidades em sua versão final.  
> Atualmente, a **filtragem de dados** e a **integração completa entre Frontend e Backend** ainda **não estão implementadas**. Essas melhorias estão listadas nas seções futuras.

---

## Funcionalidades

- **Clientes**: Cadastro, edição, exclusão e listagem de clientes.
- **Produtos**: Cadastro, edição, exclusão e listagem de produtos.
- **Vendas**: Realização e gerenciamento de vendas associadas a clientes e produtos.
- **Autenticação**: Sistema de login com **JWT Tokens**, considerando diferentes cargos de usuários (admin, vendedor, etc).
- **Interface Web**: Frontend moderno e responsivo feito em Next.js + TailwindCSS.

---

## Tecnologias Utilizadas

### Backend (.NET 8.0)

- .NET 8.0 Web API
- Entity Framework Core
- JWT Authentication
- xUnit (Testes)
- Swagger
- Docker

### Frontend (Next.js)

- Next.js 14
- TailwindCSS

---

## Como rodar o projeto

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js 20+](https://nodejs.org/en)
- [Docker](https://www.docker.com/) (opcional)
- [Yarn](https://yarnpkg.com/) ou [pnpm](https://pnpm.io/) (opcional)

---

## Documentação da API

Acesse o Swagger:

- [http://localhost:5087/swagger/index.html](http://localhost:5087/swagger/index.html)

## Melhorias Futuras

- Implementar filtragem de dados (backend e frontend)
- Finalizar a integração completa entre frontend e backend
- Deploy automático com CI/CD
- Melhorar cobertura de testes (unitários e integração)
- Suporte a múltiplos idiomas
- Otimizar queries com Dapper
- Ajustes gerais de responsividade e experiência do usuário