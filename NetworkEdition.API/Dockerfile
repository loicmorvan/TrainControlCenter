#---------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src

COPY . .
RUN dotnet publish -c Release -o /publish "NetworkEdition.API/NetworkEdition.API.csproj"

#--------------------
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0 AS final
WORKDIR /app

COPY --from=publish /publish .

ENTRYPOINT NetworkEdition.API
