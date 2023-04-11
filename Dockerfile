FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FileWebAPI/FileWebAPI.csproj", "FileWebAPI/"]
RUN dotnet restore "FileWebAPI/FileWebAPI.csproj"
COPY . .
WORKDIR "/src/FileWebAPI"
RUN chmod -R 777 /app && \
    dotnet build "FileWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileWebAPI.dll"]
