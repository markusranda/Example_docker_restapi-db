FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore Supermarket.API.csproj
COPY . ./
RUN dotnet publish Supermarket.API.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Supermarket.API.dll"]
EXPOSE 5000