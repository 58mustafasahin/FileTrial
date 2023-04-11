FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
COPY ./output /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "FileWebAPI.dll"]
