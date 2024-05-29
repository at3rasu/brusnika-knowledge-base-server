#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BrusnikaKnowledgeBaseServer.API/BrusnikaKnowledgeBaseServer.API.csproj", "BrusnikaKnowledgeBaseServer.API/"]
COPY ["BrusnikaKnowledgeBaseServer.Application/BrusnikaKnowledgeBaseServer.Application.csproj", "BrusnikaKnowledgeBaseServer.Application/"]
COPY ["BrusnikaKnowledgeBaseServer.Core/BrusnikaKnowledgeBaseServer.Core.csproj", "BrusnikaKnowledgeBaseServer.Core/"]
COPY ["BrusnikaKnowledgeBaseServer.Infrastructure/BrusnikaKnowledgeBaseServer.Infrastructure.csproj", "BrusnikaKnowledgeBaseServer.Infrastructure/"]
RUN dotnet restore "BrusnikaKnowledgeBaseServer.API/BrusnikaKnowledgeBaseServer.API.csproj"
COPY . .
WORKDIR "/src/BrusnikaKnowledgeBaseServer.API"
RUN dotnet build "BrusnikaKnowledgeBaseServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrusnikaKnowledgeBaseServer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrusnikaKnowledgeBaseServer.API.dll"]