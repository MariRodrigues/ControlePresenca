#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+8000;http://+80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ControlePresenca/ControlePresenca.csproj", "ControlePresenca/"]
COPY ["ControlePresenca.Application/ControlePresenca.Application.csproj", "ControlePresenca.Application/"]
COPY ["ControlePresenca.Domain/ControlePresenca.Domain.csproj", "ControlePresenca.Domain/"]
COPY ["ControlePresenca.Infra/ControlePresenca.Infra.csproj", "ControlePresenca.Infra/"]
RUN dotnet restore "ControlePresenca/ControlePresenca.csproj"
COPY . .
WORKDIR "/src/ControlePresenca"
RUN dotnet build "ControlePresenca.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControlePresenca.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControlePresenca.dll"]