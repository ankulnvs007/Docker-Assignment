﻿# Project Setup: Docker and Docker Compose with .NET Core 8

## Overview

This project demonstrates how to set up and run two simple web applications, **Product.API** and **User.API**, using Docker and Docker Compose. This guide will walk you through the steps needed to containerize the applications and orchestrate them effectively.

## Prerequisites

- .NET Core 8 SDK installed
- Docker and Docker Compose installed
- A code editor (e.g., Visual Studio, VS Code)

## Steps to Follow

### 1. ProductAPI: Create a new .NET Core Web API project for Product data.
- dotnet new webapi -n Product.API
- UserAPI: Create another .NET Core Web API project for User data.
- dotnet new webapi -n User.API

### 2. Dockerize ProductAPI and UserAPI
- To Dockerize the Product.API and User.API projects, you need to create a Dockerfile for each project. A Dockerfile is a text file that contains instructions for building a Docker image.

### 3. Add Docker Compose using Orchestration Support
- To add Docker Compose using orchestration support, you need to create a docker-compose.yml file in the root directory of your project. This file defines the services, networks, and volumes for your application.

### 4. Build the Docker compose using command : docker-compose build
- To build the Docker Compose configuration, you need to run the "docker-compose build" command in the terminal. This command builds the Docker images for each service defined in the docker-compose.yml file.

### 5. Run the service using command : Docker-compose up -d
- To start the containers, you need to run the docker-compose up -d command in the terminal. This command starts the containers in detached mode, which means they run in the background.

### 6. Access the APIs
    - After starting the services, you can access the APIs:
    - ProductAPI: http://localhost:5001
    - UserAPI: http://localhost:5002

### 7. Monitor Logs
    - View logs for the running services: docker-compose logs

### 8. Stopping the Services
    - To stop and remove the containers, use: docker-compose down
