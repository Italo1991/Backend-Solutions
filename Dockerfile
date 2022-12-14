#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Italo.Customer.Api/Italo.Customer.Api.csproj", "Italo.Customer.Api/"]
RUN dotnet restore "Italo.Customer.Api/Italo.Customer.Api.csproj"
COPY . .
WORKDIR "/src/Italo.Customer.Api"
RUN dotnet build "Italo.Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Italo.Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Italo.Customer.Api.dll"]