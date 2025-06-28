# Cidades Brasileiras

Projeto para gerenciar informações de municípios brasileiros.

## Funcionalidades

- Buscar municípios
- Listar capitais
- Mostrar população dos estados

# Tecnologias

- .net 9
- jquery
- bootstrap
- entity framework

# Para executar:

- No arquivo chamado "appsettings.json", na pasta "CidadesBrasileiras.Presentation", mude o campo Password na connection string para a informada externamente;

- Para criar tabelas, seguir o padrão no arquivo AppDbContext na pasta Data no projeto CidadesBrasileiras.Infrastructure;

- Para executar migrations é necessário instalar o dotnet ef globalmente na máquina. Depois você vai abrir o Console do Gerenciador de Pacotes em: (Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes) e rodar os códigos
  - dotnet ef migrations NomeDaMigracao --project CidadesBrasileiras.Infrastructure --startup-project CidadesBrasileiras.Presentation
  - e depois para sar update no Banco de Dados:
  - dotnet ef database update --project CidadesBrasileiras.Infrastructure --startup-project CidadesBrasileiras.Presentation
