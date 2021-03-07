# Build application code sources.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY console-example.csproj .
RUN dotnet restore console-example.csproj
COPY . .
RUN dotnet build -c Release --no-restore

# Publish building result.
FROM build as publish
RUN dotnet publish -c Release --no-build -o /app

# Create the target image.
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "console-example.dll"]