FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install ping
RUN apt-get update && apt-get install -y inetutils-ping net-tools

FROM base AS final
WORKDIR /app
COPY ./output/ /app/publish/ 
ENTRYPOINT ["dotnet", "/app/publish/EdwardSFlores.Service.dll"]
