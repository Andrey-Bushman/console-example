FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY console-example.csproj .
RUN dotnet restore console-example.csproj
COPY . .
RUN dotnet build console-example.csproj -c Release --no-restore
RUN dotnet publish console-example.csproj -c Release --no-build -o /app

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "console-example.dll"]