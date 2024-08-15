#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Sales.API/Sales.API.csproj", "src/Sales.API/"]
COPY ["src/Sales.Application/Sales.Application.csproj", "src/Sales.Application/"]
COPY ["src/Sales.Infra.Data/Sales.Infra.Data.csproj", "src/Sales.Infra.Data/"]
COPY ["src/Sales.Domain/Sales.Domain.csproj", "src/Sales.Domain/"]
RUN dotnet restore "src/Sales.API/Sales.API.csproj"
COPY . .
WORKDIR "/src/src/Sales.API"
RUN dotnet build "Sales.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.API.dll"]
