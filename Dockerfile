FROM mcr.microsoft.com/dotnet/sdk:9.0.201 AS build 
WORKDIR /app COPY test.sln ./ 
COPY src/ ./src/ 
RUN dotnet restore ./src/test.Web.Host/test.Web.Host.csproj 
RUN dotnet publish ./src/test.Web.Host/test.Web.Host.csproj -c Release -o /app/publish 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Docker
ENV ASPNETCORE_URLS=http://+:80 
EXPOSE 80 
ENTRYPOINT ["dotnet", "test.Web.Host.dll"]