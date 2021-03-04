#---------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src

COPY Directory.Build.props .

COPY Foundation/*.csproj Foundation/
COPY NetworkEdition.Application/*.csproj NetworkEdition.Application/
COPY NetworkEdition.Domain/*.csproj NetworkEdition.Domain/
COPY NetworkEdition.Infrastructure/*.csproj NetworkEdition.Infrastructure/
COPY NetworkEdition.ViewModels/*.csproj NetworkEdition.ViewModels/
COPY NetworkEdition.API/*.csproj NetworkEdition.API/
RUN dotnet restore "NetworkEdition.API/NetworkEdition.API.csproj"

COPY Foundation/ Foundation/
COPY NetworkEdition.Application/ NetworkEdition.Application/
COPY NetworkEdition.Domain/ NetworkEdition.Domain/
COPY NetworkEdition.Infrastructure/ NetworkEdition.Infrastructure/
COPY NetworkEdition.ViewModels/ NetworkEdition.ViewModels/
COPY NetworkEdition.API/ NetworkEdition.API/
RUN dotnet publish -c Release -o /publish -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true "NetworkEdition.API/NetworkEdition.API.csproj"

#--------------------
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0 AS final
WORKDIR /app

COPY --from=publish /publish .

ENTRYPOINT ./NetworkEdition.API
