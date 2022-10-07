#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Billing.Authentication.Api/Billing.Authentication.Api.csproj", "Billing.Authentication.Api/"]
COPY ["Billing.Authentication.Business/Billing.Authentication.Business.csproj", "Billing.Authentication.Business/"]
COPY ["Billing.Authentication.Domains/Billing.Authentication.Domains.csproj", "Billing.Authentication.Domains/"]
COPY ["Billing.Authentication.Infrastructure/Billing.Authentication.Infrastructure.csproj", "Billing.Authentication.Infrastructure/"]
RUN dotnet restore "Billing.Authentication.Api/Billing.Authentication.Api.csproj"
COPY . .
WORKDIR "/src/Billing.Authentication.Api"
RUN dotnet build "Billing.Authentication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Billing.Authentication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Billing.Authentication.Api.dll"]