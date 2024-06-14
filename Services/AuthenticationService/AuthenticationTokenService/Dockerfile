# Sử dụng hình ảnh .NET Core SDK để xây dựng ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AuthenticationService/AuthenticationTokenService/AuthenticationTokenService.csproj", "AuthenticationService/AuthenticationTokenService/"]
COPY ["AuthenticationService/LibraryAuthentication/LibraryAuthentication/LibraryAuthentication.csproj", "AuthenticationService/LibraryAuthentication/LibraryAuthentication/"]
RUN dotnet restore "AuthenticationService/AuthenticationTokenService/AuthenticationTokenService.csproj"
COPY . .
WORKDIR "/src/AuthenticationService/AuthenticationTokenService"
RUN dotnet build "AuthenticationTokenService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationTokenService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationTokenService.dll"]




