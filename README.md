# 📌 Controle de Tarefas

Sistema completo para gerenciamento de tarefas, desenvolvido com:

- 🔹 **Backend:** .NET 8 (Web API)
- 🔹 **Frontend:** Angular 18
- 🔹 **Banco de Dados:** PostgreSQL
- 🔹 **ORM:** Entity Framework Core 8

O sistema permite realizar operações completas de CRUD:

- ✅ Criar tarefas  
- ✅ Listar todas as tarefas  
- ✅ Buscar tarefa por ID  
- ✅ Atualizar tarefa  
- ✅ Excluir tarefa  

O frontend consome os endpoints da API para executar todas as operações.

---

# 🏗️ Arquitetura

O backend foi estruturado seguindo princípios de separação de responsabilidades e organização em camadas:

## 🔹 API
- Controllers
- Configuração da aplicação
- Configuração de CORS

## 🔹 Application
- Services
- Regras de negócio
- Orquestração das operações

## 🔹 Domain (Model)
- Entidades
- DTOs
- Enums (Prioridade e Status)

## 🔹 Infrastructure (Data)
- DbContext
- Repositories
- Configuração do Entity Framework Core

Essa separação facilita manutenção, escalabilidade e testabilidade.

## 🔹 Para testar
- Configure a connection string no appsettings.json corretamente (removi a porta e o password por seguranca) 
- Mude a rota de recebimento no program.cs do backend, pois adicionei uma configuracao de CORS para poder receber requisicoes do meu front local (Mude para a porta que o front carregar em sua maquina)

---

# 🗄️ Banco de Dados

Banco utilizado: **PostgreSQL**

## 📄 Script de criação da tabela

```sql
CREATE TABLE tarefas (
    id SERIAL PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    descricao TEXT NOT NULL,
    prioridade INTEGER NOT NULL,
    status INTEGER NOT NULL,
    data_criacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
