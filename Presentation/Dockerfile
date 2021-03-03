#---------------------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src

COPY Presentation/Presentation.csrpoj Presentation/
RUN dotnet restore "Presentation/Presentation.csproj"

COPY . .
RUN dotnet publish -c Release -o /publish "Presentation/Presentation.csproj"

#--------------------
FROM nginx:latest AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /publish/wwwroot /usr/local/webapp/nginx/html
COPY --from=publish /publish/wwwroot/nginx.conf /etc/nginx/nginx.conf
