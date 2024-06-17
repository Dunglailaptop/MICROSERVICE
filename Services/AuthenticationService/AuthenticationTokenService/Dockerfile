# Sử dụng image .NET SDK để build project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Thiết lập thư mục làm việc
WORKDIR /src

# Sao chép file .csproj của project chính và thư viện bên ngoài
COPY ["Services/AuthenticationService/AuthenticationTokenService/AuthenticationTokenService.csproj", "AuthenticationService/AuthenticationTokenService/"]
COPY ["Services/AuthenticationService/LibraryAuthentication/LibraryAuthentication/LibraryAuthentication.csproj", "AuthenticationService/LibraryAuthentication/LibraryAuthentication/"]

# Restore các dependencies
RUN dotnet restore "AuthenticationService/AuthenticationTokenService/AuthenticationTokenService.csproj"

# Sao chép toàn bộ project và thư viện bên ngoài
COPY Services/AuthenticationService/AuthenticationTokenService/ "AuthenticationService/AuthenticationTokenService/"
COPY Services/AuthenticationService/LibraryAuthentication/LibraryAuthentication "AuthenticationService/LibraryAuthentication/LibraryAuthentication/"

# Build project
WORKDIR "/src/AuthenticationService/AuthenticationTokenService"
RUN dotnet build "AuthenticationTokenService.csproj" -c Release -o /app/build

# Publish project
FROM build AS publish
RUN dotnet publish "AuthenticationTokenService.csproj" -c Release -o /app/publish

# Sử dụng image ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Thiết lập thư mục làm việc cho giai đoạn cuối
WORKDIR /app

# Sao chép các file đã publish từ giai đoạn build
COPY --from=publish /app/publish .

EXPOSE 5216

# Thiết lập entry point cho ứng dụng
ENTRYPOINT ["dotnet", "AuthenticationTokenService.dll"]
