# 🔐 API Login

API REST desenvolvida com ASP.NET Core para autenticação de usuários utilizando JWT, seguindo Clean Architecture.

## 🚀 Tecnologias Utilizadas
- C# / .NET
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- xUnit + Moq + Bogus (testes unitários)
-  WebApplicationFactory + EF InMemory (testes de integração)

## 🧠 Arquitetura
Projeto estruturado em camadas:
- **Application** — Use Cases e regras de negócio
- **Domain** — Entidades e interfaces
- **Infraestrutura** — Repositórios e contexto do banco
- **Exception** — Tratamento de erros personalizado
- **Communication** — Request e Response

## 📌 Funcionalidades
- Cadastro de usuários com validação
- Login com geração de token JWT
- Criptografia de senha com BCrypt
- Rotas protegidas por autenticação
- Tratamento de erros padronizado

## 🧪 Testes
Projeto conta com testes unitários cobrindo:
- Cadastro com sucesso
- Validação de campos obrigatórios
- Email duplicado
- Login com sucesso
- Login com credenciais inválidas

- 🔗 Testes de Integração
- POST /api/Usuario com sucesso retorna 201
- Email duplicado retorna 400
- Campos vazios retorna 400
- POST /api/Login com sucesso retorna 200
- Login com credenciais inválidas retorna 401
