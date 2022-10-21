#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Billing.UserApi.Api/Billing.UserApi.Api.csproj", "Billing.UserApi.Api/"]
COPY ["Billing.UserApi.Infrstructure/Billing.UserApi.Infrstructure.csproj", "Billing.UserApi.Infrstructure/"]
COPY ["Billing.UserApi.Domains/Billing.UserApi.Domains.csproj", "Billing.UserApi.Domains/"]
COPY ["Billing.UserApi.Business/Billing.UserApi.Business.csproj", "Billing.UserApi.Business/"]
RUN dotnet restore "Billing.UserApi.Api/Billing.UserApi.Api.csproj"
COPY . .
WORKDIR "/src/Billing.UserApi.Api"
RUN dotnet build "Billing.UserApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Billing.UserApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Billing.UserApi.Api.dll"]