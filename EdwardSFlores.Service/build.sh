#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh

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
dotnet publish -c Debug -o ${RELEASE_DIRECTORY}/${OUTPUT_DIRECTORY}

# Copy Dockerfile to output directory
echo "copy Dockerfile"
ls -ali
cd EdwardSFlores.Service
cp Dockerfile ${RELEASE_DIRECTORY}
cp run.sh ${RELEASE_DIRECTORY}