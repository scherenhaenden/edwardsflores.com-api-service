#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh


# Set variable name for the container
CONTAINER_NAME=edwardflores/service-beta

# Set variable name for output directory
RELEASE_DIRECTORY=release
OUTPUT_DIRECTORY=output

#cd ${RELEASE_DIRECTORY}


# Get if the image exists in docker and if exists stop it 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker stop 
docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker rmi -f

# Build the docker image
docker build -t ${CONTAINER_NAME} .

# Run the docker image
docker run -d -p 15003:80 --network=host ${CONTAINER_NAME}