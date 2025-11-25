
# encender el docker #
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssw0rd2025!'    -p 8308:1433    --platform linux/amd64    -d mcr.microsoft.com/mssql/server:2022-latest

# base de datos en sqlserver #
localhost 
8308
sa
P@ssw0rd2025!


# encerder el dotnet #
dotnet restore 
dotnet build
dotnet run
