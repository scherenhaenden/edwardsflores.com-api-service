#!/bin/bash
# Build and run the service
# Path: EdwardSFlores.Service/build-and-run.sh


# Set variable name for the container
CONTAINER_NAME=edwardflores/service-beta

# Set variable name for output directory
RELEASE_DIRECTORY=release
OUTPUT_DIRECTORY=output

# check if container is running
if [ "$(docker ps -a |grep ${CONTAINER_NAME} )" ]; then
    # stop container
    echo "stop container"
    docker ps -a |grep ${CONTAINER_NAME} | awk '{print $1}' | xargs docker stop 
    docker ps -a|grep ${CONTAINER_NAME} | awk '{print $1}' | xargs docker rm
fi

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

# check if container is running
if [ "$(docker ps name=${CONTAINER_NAME})" ]; then
    # stop container
    echo "stop container"
    docker ps |grep ${CONTAINER_NAME} | awk '{print $1}' | xargs docker stop
fi
 #docker ps |grep ${CONTAINER_NAME} | awk '{print $1}' | xargs docker stop
 # docker ps |grep 15009 | awk '{print $1}' | xargs docker stop



#cd ${RELEASE_DIRECTORY}
#docker images | grep ${CONTAINER_NAME}
#docker stop $(docker ps -a -q --filter name='${CONTAINER_NAME}' --format="{{.ID}}")
# Get if the image exists in docker and if exists stop it 
#docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' #| xargs docker stop 
#docker images | grep ${CONTAINER_NAME}  | awk '{print $3}' | xargs docker rmi -f
#cat ./release/output/appsettings.json

# Build the docker image
#docker build -t ${CONTAINER_NAME} .

# Run the docker image
#docker run -it -d -p 15009:80 -p 15008:443 --add-host=host.docker.internal:host-gateway ${CONTAINER_NAME}


#docker images | grep edwardflores/service-beta  | awk '{print $3}'| xargs docker stop 

#docker ps -q -f name=edwardflores/service-beta


#docker ps -a -q --filter name='edwardflores/service-beta' --format="{{.ID}}"

#docker ps |grep edwardflores/service-beta | awk '{print $1}' | xargs docker stop

echo $(pwd)

#docker ps |grep edwardsfloresservice-web| awk '{print $3}'| xargs docker inspect 
cp ../appsettings.json ${OUTPUT_DIRECTORY}/appsettings.json 
cp ../appsettings.json ./appsettings.json 

docker-compose -f docker-compose.Beta.yml build --no-cache
docker-compose -f docker-compose.Beta.yml up -d --force-recreate

#docker build -t ${CONTAINER_NAME} . -f Dockerfile.Beta
#docker run -it -d -p 15009:80 -p 15008:443 --add-host=host.docker.internal:host-gateway ${CONTAINER_NAME} -f Dockerfile.Beta