FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
 
COPY ["Poc.DeliveryContinu.ServiceDemandes.csproj", "./"]
 
RUN dotnet restore "Poc.DeliveryContinu.ServiceDemandes.csproj"
 
COPY . .
 
RUN dotnet publish "Poc.DeliveryContinu.ServiceDemandes.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
FROM base AS final
WORKDIR /app
 
COPY --from=build /app/publish .
 
ENTRYPOINT ["dotnet", "Poc.DeliveryContinu.ServiceDemandes.dll"]