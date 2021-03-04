#---------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src

COPY Directory.Build.props .

COPY NetworkEdition.ViewModels/NetworkEdition.ViewModels.csproj NetworkEdition.ViewModels/
COPY Presentation/Presentation.csproj Presentation/
RUN dotnet restore "Presentation/Presentation.csproj"

COPY NetworkEdition.ViewModels/ NetworkEdition.ViewModels/
COPY Presentation/ Presentation/
RUN dotnet publish -c Release -o /publish "Presentation/Presentation.csproj"

#--------------------
FROM nginx:latest AS final

WORKDIR /usr/share/nginx/html

COPY --from=publish /publish/wwwroot /usr/local/webapp/nginx/html
COPY Presentation/nginx.conf /etc/nginx/nginx.conf
