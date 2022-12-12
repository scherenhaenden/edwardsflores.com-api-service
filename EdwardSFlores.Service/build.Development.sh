#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh

#get current directory
CURRENT_DIRECTORY=$(pwd)

# Set variable name for the container
CONTAINER_NAME=edwardflores/service-release

# Set variable name for output directory
RELEASE_DIRECTORY=release
OUTPUT_DIRECTORY=output

# Restore the application dependencies
dotnet restore 

# Build the application .net core with output in directory "output" for development
#dotnet build -c Debug -o output

# Build the application .net core with output in directory "output"
dotnet publish -c Debug -o ${CURRENT_DIRECTORY}/${RELEASE_DIRECTORY}/${OUTPUT_DIRECTORY}

# Copy Dockerfile to output directory
echo "copy Dockerfile"
ls -ali
cd EdwardSFlores.Service
cp Dockerfile.Development ${CURRENT_DIRECTORY}/${RELEASE_DIRECTORY}
cp docker-compose.Development.yml ${CURRENT_DIRECTORY}/${RELEASE_DIRECTORY}
cp run.sh ${CURRENT_DIRECTORY}/${RELEASE_DIRECTORY}
cp run-dc.sh ${CURRENT_DIRECTORY}/${RELEASE_DIRECTORY}