# Imagem base do SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto
COPY . .

# Restaurar dependências
RUN dotnet restore

# Compilar a aplicação
RUN dotnet publish -c Release -o out

# Imagem base do runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/out .

# Expor a porta que a API usa
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "Bookstore.API.dll"]