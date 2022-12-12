#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh

# Set variable name for the container
CONTAINER_NAME=edwardflores/service-debug

# Restore the application dependencies
dotnet restore

# Build the application .net core with output in directory "output" for development
#dotnet build -c Debug -o output

# Build the application .net core with output in directory "output"
dotnet publish -c Debug -o output

# Get if the image exists in docker and if exists stop it 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker stop 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker rmi -f

# Build the docker image
docker build -t ${CONTAINER_NAME} .

# Run the docker image
docker run -d -p 15007:80 ${CONTAINER_NAME}