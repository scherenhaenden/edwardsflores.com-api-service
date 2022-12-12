FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install ping
RUN apt-get -qq clean  
RUN apt-get -qq update
RUN apt-get -qq -y install apt-utils
RUN apt-get -qq -y install dialog
RUN apt-get -qq update
RUN apt-get -qq -y install bash-completion --fix-missing
RUN apt-get -qq -y install inetutils-ping net-tools 

FROM base AS final
WORKDIR /app
COPY ./release/output/ /app/publish/ 
ENTRYPOINT ["dotnet", "/app/publish/EdwardSFlores.Service.dll"]
