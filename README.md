# 🎨 projetoStudio

![.NET](https://img.shields.io/badge/Backend-.NET_9.0-blue) ![EntityFramework](https://img.shields.io/badge/ORM-EF_Core-brightgreen) ![JWT](https://img.shields.io/badge/Auth-JWT-orange) ![React](https://img.shields.io/badge/Frontend-React-skyblue) ![Tailwind](https://img.shields.io/badge/CSS-Tailwind-green)

## 📃 Descrição

projetoStudio é uma aplicação full-stack para gerenciamento de sessões de serviço, endereços e usuários, com autenticação via JWT e UI responsiva em React + Tailwind CSS. O backend, construído em C# e .NET 9.0, utiliza Entity Framework Core para persistência em PostgreSQL. O frontend, com Vite e React 19, oferece navegação dinâmica e componentes estilizados.

## 📑 Tabela de Conteúdos

1. [Funcionalidades](#funcionalidades)
2. [Tecnologias](#tecnologias)
3. [Requisitos](#requisitos)
4. [Instalação](#instalação)
5. [Configuração de Ambiente](#configuração-de-ambiente)
6. [Estrutura do Projeto](#estrutura-do-projeto)
7. [API Reference](#api-reference)
8. [Modelo de Dados](#modelo-de-dados)
9. [Contribuição](#contribuição)
10. [Licença](#licença)
11. [Autor](#autor)

## 🚀 Funcionalidades

* **Autenticação**: JWT bearer tokens com validação de claims de issuer e audience
* **CRUD completo** para Users, Addresses, Neighborhoods, Streets, Services e Sessions
* **Relacionamentos**: Serviços vinculados a sessões (ServiceSessionModel)
* **Filtros e estados**: Sessões podem ter estado ativo/inativo e data/hora registradas
* **Interface responsiva** com React + Tailwind CSS

## 🛠️ Tecnologias

### Backend

* [.NET 9.0](https://dotnet.microsoft.com/)
* [Entity Framework Core](https://docs.microsoft.com/ef/) (PostgreSQL)
* [FluentValidation.AspNetCore](https://docs.fluentvalidation.net/)
* [Isopoh.Cryptography.Argon2](https://github.com/kunaltyagi/Isopoh.Cryptography.Argon2)
* [Microsoft.AspNetCore.Authentication.JwtBearer](https://docs.microsoft.com/aspnet/core/security/authentication/jwt)

### Frontend

* [React 19](https://reactjs.org/)
* [Vite](https://vitejs.dev/)
* [Tailwind CSS](https://tailwindcss.com/)
* [React Router DOM](https://reactrouter.com/)
* [React Icons](https://react-icons.github.io/react-icons/)
* [React Slick](https://react-slick.neostack.com/)

## 🔧 Requisitos

* [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Node.js v16+ e npm/yarn
* PostgreSQL
* Git

## ⚙️ Instalação

### Backend

```bash
# clone o repositório
git clone https://github.com/seu-usuario/projetoStudio.git
cd projetoStudio/backend

# restaure pacotes e migre o DB
dotnet restore
dotnet ef database update

# execute a API
dotnet run
```

A API estará disponível em `https://localhost:5001`.

### Frontend

```bash
cd projetoStudio/frontend
npm install
npm run dev
```

O frontend rodará em `http://localhost:5173`.

## 🔒 Configuração de Ambiente

### backend/appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=xxxxx;Username=xxxxx;Password=xxxxx"
  },
  "Jwt": {
    "Issuer": "projetoStudioAuth",
    "Audience": "projetoStudioClient",
    "Key": "SUA_CHAVE_SECRETA_LONGA"  
  }
}
```

## 📜 API Reference

### Users

| Método | Rota               | Descrição                  |
| ------ | ------------------ | -------------------------- |
| GET    | `/api/users`       | Listar usuários            |
| GET    | `/api/users/{cpf}` | Buscar usuário por CPF     |
| POST   | `/api/users`       | Criar novo usuário         |
| PUT    | `/api/users/{cpf}` | Atualizar dados do usuário |
| DELETE | `/api/users/{cpf}` | Remover usuário            |

### Addresses

| Método | Rota                  | Descrição          |
| ------ | --------------------- | ------------------ |
| GET    | `/api/addresses`      | Listar endereços   |
| POST   | `/api/addresses`      | Criar endereço     |
| PUT    | `/api/addresses/{id}` | Atualizar endereço |
| DELETE | `/api/addresses/{id}` | Remover endereço   |

### Sessions & Services

| Método | Rota                       | Descrição                 |
| ------ | -------------------------- | ------------------------- |
| GET    | `/api/sessions`            | Listar todas sessões      |
| POST   | `/api/sessions`            | Criar nova sessão         |
| PATCH  | `/api/sessions/{id}/state` | Alterar estado da sessão  |
| DELETE | `/api/sessions/{id}`       | Remover sessão            |
| GET    | `/api/services`            | Listar serviços           |
| POST   | `/api/services`            | Criar serviço             |
| POST   | `/api/service-sessions`    | Vincular serviço a sessão |

## 🗄️ Modelo de Dados

```csharp
public class UserModel { /* ... */ }
public class AddressModel { /* ... */ }
public class NeighborhoodModel { /* ... */ }
public class StreetModel { /* ... */ }
public class ServiceModel { /* ... */ }
public class SessionModel { /* ... */ }
public class ServiceSessionModel { /* ... */ }
public class AddressUserModel { /* ... */ }
```

## 🤝 Contribuição

1. Faça um fork deste repositório
2. Crie uma branch: `git checkout -b feature/nome-funcionalidade`
3. Commit suas alterações: `git commit -m 'Descrição da mudança'`
4. Envie para a branch: `git push origin feature/nome-funcionalidade`
5. Abra um Pull Request



## 👨‍💻 Autor

Desenvolvido por **Douglas Gemir(backend) e Eric Leite(frontend)**
