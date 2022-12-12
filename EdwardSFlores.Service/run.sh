#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh


# Set variable name for the container
CONTAINER_NAME=edwardflores/service-beta

# Set variable name for output directory
RELEASE_DIRECTORY=release
OUTPUT_DIRECTORY=output

# check if container is running
if [ "$(docker ps -q -f name=${CONTAINER_NAME})" ]; then
    # stop container
    echo "stop container"
    docker stop ${CONTAINER_NAME}    
fi

# check if container exists
if [ "$(docker ps -aq -f name=${CONTAINER_NAME})" ]; then
    # remove container
    echo "remove container"
    docker rm ${CONTAINER_NAME}
fi

#cd ${RELEASE_DIRECTORY}
#docker images | grep ${CONTAINER_NAME}
#docker stop $(docker ps -a -q --filter name='${CONTAINER_NAME}' --format="{{.ID}}")
# Get if the image exists in docker and if exists stop it 
#docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' #| xargs docker stop 
#docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker rmi -f

# Build the docker image
docker build -t ${CONTAINER_NAME} .

# Run the docker image
docker run -d -p 15009:80 --add-host=host.docker.internal:host-gateway ${CONTAINER_NAME}