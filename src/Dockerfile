# First build phase: We work in a temporary container. Based on the .NET Core
# SDK image, do the following:
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# We work with the app folder (if it is not there, it will create).
WORKDIR /app

# Copy absolutely everything that lies at the level of this file into the
# folder in which we are now (app).
COPY . .

# Assembly and deployment of the project.
RUN dotnet restore docker-mongodb/src/app/Learning.DockerMongoDB.App.csproj
RUN dotnet publish -c Release -o out

# Second build phase: Another temporary container is created. Based on this
# image, prepare for runtime.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

# We work with the app folder (if it is not there, it will create).
WORKDIR /app

# Copy from the temporary container created at the build stage, all files from
# the app/out folder to the one in which we are now (app).
COPY --from=build /app/out ./

# After starting the container created on the basis of this image, execute the
# dotnet command with the Learning.DockerMongoDB.App.dll parameter
# (which will launch our application). Removing temporary containers.
ENTRYPOINT [ "dotnet", "Learning.DockerMongoDB.App.dll" ]