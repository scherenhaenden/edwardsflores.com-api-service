FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EdwardSFlores.Service/EdwardSFlores.Service.csproj", "EdwardSFlores.Service/"]
RUN dotnet restore "EdwardSFlores.Service/EdwardSFlores.Service.csproj"
COPY . .
WORKDIR "/src/EdwardSFlores.Service"
RUN dotnet build "EdwardSFlores.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EdwardSFlores.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EdwardSFlores.Service.dll"]
