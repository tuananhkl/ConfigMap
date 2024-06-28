FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
COPY ConfigMap.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT ["dotnet", "ConfigMap.dll"]

