#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Gateways/Aggregators/Web.HttpAggregator.Api/Web.HttpAggregator.Api.csproj", "src/Gateways/Aggregators/Web.HttpAggregator.Api/"]
COPY ["src/HelperService/Microservice.Api/Microservice.Api.csproj", "src/HelperService/Microservice.Api/"]
COPY ["src/Gateways/Aggregators/Web.HttpAggregator.Abstraction/Web.HttpAggregator.Abstraction.csproj", "src/Gateways/Aggregators/Web.HttpAggregator.Abstraction/"]
COPY ["src/Gateways/Aggregators/Web.HttpAggregator.Application/Web.HttpAggregator.Application.csproj", "src/Gateways/Aggregators/Web.HttpAggregator.Application/"]
RUN dotnet restore "src/Gateways/Aggregators/Web.HttpAggregator.Api/Web.HttpAggregator.Api.csproj"
COPY . .
WORKDIR "/src/src/Gateways/Aggregators/Web.HttpAggregator.Api"
RUN dotnet build "Web.HttpAggregator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.HttpAggregator.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.HttpAggregator.Api.dll"]