# SpotifyScript2
1 - Clonar o Repositorio
2 - Ter o Dotnet 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0
3 - Usar o comando dentro da pasta do projeto
```
dotnet restore
```
4 - Mudar a senha do banco de dados no ``DataContext`` e no ``DataContextFactory``
5 - Instalar o tools para executar as migrations
```
dotnet tool install --global dotnet-ef
```
6 - Rodar as migrations
```
dotnet ef database update
```
7 - Executar o projeto
```
dotnet run
```
 
