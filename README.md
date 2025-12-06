
# encender el docker mac #
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssw0rd2025!'    -p 8308:1433    --platform linux/amd64    -d mcr.microsoft.com/mssql/server:2022-latest

# encender el docker windows #
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssw0rd2025!" -p 8308:1433 --platform linux/amd64 -d mcr.microsoft.com/mssql/server:2022-latest



# base de datos en sqlserver #
localhost 
8308
sa
P@ssw0rd2025!


# encerder el dotnet #
dotnet restore 
dotnet build
dotnet run


# levantar el docker #
docker build -t annii009/essencia-api:1.0 .

docker compose up -d


# para subirla he utilizado #
docker login
docker push annii009/essencia-api:1.0


# para el front #

# dentro de essenciafront\frontend #
docker build -t annii009/essencia-front:1.0 .

# dentro de essenciabackend #
docker compose down

docker compose up -d


# pagina front #
http://localhost:8080/html/index.html



# git donde he estado subiendo los commits del back hasta juntarlo con el front #

https://github.com/Annii009/EssenciaBackend.git

# docker hub #

https://hub.docker.com/repository/docker/annii009/essencia-api/general

# postman #

https://anaheralmudi-8976383.postman.co/workspace/Ana-Hernandez's-Workspace~52058e76-8724-401b-87bf-5ab51c447bc0/collection/49401958-1aea7b5e-cd30-48d6-95d4-fde8127edd95?action=share&creator=49401958

