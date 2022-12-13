#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh

# Set variable name for the container
CONTAINER_NAME=edwardflores/service-release

# Restore the application dependencies
dotnet restore

# Build the application .net core with output in directory "output" for development
#dotnet build -c Debug -o output

# Build the application .net core with output in directory "output"
dotnet publish -c Release -o output

# Get if the image exists in docker and if exists stop it 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker stop 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker rmi -f

# Build the docker image
docker build -t edwardflores/service-beta .

# Run the docker image
docker run -d -p 15003:80 edwardflores/service