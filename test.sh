#!/bin/bash
# read arguments from outside named: $environment, $container_name, $release_directory, $output_directory, $dockerfile, $run_sh
# $production, $development, $test

# read the container_name


for i in "$@"; do
  case $i in
    -cn=*|--container-name=*)
      CONTAINER_NAME="${i#*=}"
      shift # past argument=value
      ;;   
    -be=*|--build-environment=*)
      BUILD_ENVIRONMENT="${i#*=}"
      shift # past argument=value
    ;;   
    --default)
      DEFAULT=YES
      shift # past argument with no value
      ;;
    -*|--*)
      echo "Unknown option $i"
      exit 1
      ;;
    *)
      ;;
  esac
done

# check if the container_name is empty
if [ -z "$CONTAINER_NAME" ]; then
  echo "Container name is empty"
  exit 1
fi

# check if the development environment is empty
if [ -z "$BUILD_ENVIRONMENT" ]; then
  echo "Build environment is empty"
  echo "Build will be set to release"
  BUILD_ENVIRONMENT="release"
fi

# check if the development environment is production or development
if [ "$BUILD_ENVIRONMENT" != "release" ] && [ "$BUILD_ENVIRONMENT" != "debug" ]; then
  echo "Build environment is not release or debug"
  echo "Build will be set to release"
  BUILD_ENVIRONMENT="production"
fi

# print container_name
echo "Container Name: $CONTAINER_NAME"
