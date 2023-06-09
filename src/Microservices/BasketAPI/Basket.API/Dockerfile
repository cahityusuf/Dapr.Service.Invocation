#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/BasketAPI/Basket.API/Basket.API.csproj", "src/Microservices/BasketAPI/Basket.API/"]
COPY ["src/HelperService/Microservice.Api/Microservice.Api.csproj", "src/HelperService/Microservice.Api/"]
COPY ["src/Microservices/BasketAPI/Basket.Application/Basket.Application.csproj", "src/Microservices/BasketAPI/Basket.Application/"]
COPY ["src/Microservices/BasketAPI/Basket.Abstraction/Basket.Abstraction.csproj", "src/Microservices/BasketAPI/Basket.Abstraction/"]
COPY ["src/Microservices/BasketAPI/Basket.Domain/Basket.Domain.csproj", "src/Microservices/BasketAPI/Basket.Domain/"]
COPY ["src/Microservices/BasketAPI/Basket.Infrastructure/Basket.Infrastructure.csproj", "src/Microservices/BasketAPI/Basket.Infrastructure/"]
RUN dotnet restore "src/Microservices/BasketAPI/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/BasketAPI/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]