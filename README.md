# 📌 Controle de Tarefas

API REST desenvolvida em **.NET 8** para gerenciamento de tarefas, seguindo princípios de separação de camadas (API, Application, Domain e Infrastructure) e boas práticas de arquitetura.

O sistema permite:

- Criar tarefas  
- Listar todas as tarefas  
- Buscar tarefa por ID  
- Atualizar tarefa  
- Excluir tarefa  

O frontend deverá consumir os mesmos endpoints para realizar as mesmas operações.

---

# 🏗️ Arquitetura

O projeto foi estruturado em camadas:

- **API** → Controllers e configuração da aplicação  
- **Application** → Services (regras de aplicação)  
- **Domain (Model)** → Entidades, DTOs e Enums  
- **Infrastructure (Data)** → DbContext e Repositories  

Banco de dados: **PostgreSQL**  
ORM: **Entity Framework Core 8**

# Query utilizada para criacao da tabela de tarefas. 

CREATE TABLE tarefas (
    id SERIAL PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    descricao TEXT NOT NULL,
    prioridade INTEGER NOT NULL,
    status INTEGER NOT NULL,
    data_criacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
