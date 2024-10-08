# Project Setup

## Prerequisites
- Docker
- .NET SDK

## Setup Instructions

1. Create Docker volumes:
    ```sh
    docker volume create mq_nats_1
    docker volume create mq_nats_2
    ```

2. Build and start the Docker containers:
    ```sh
    docker compose up --build
    ```

3. Run the .NET projects:
    ```sh
    dotnet run --project ./reciever/reciever.csproj
    dotnet run --project ./publisher/publisher.csproj
    ```

4. Run the .NET projects jetstream supported(inside jetstream folder):
    ```sh
    dotnet run --project ./reciever/reciever.csproj 
    dotnet run --project ./publisher/publisher.csproj
    ```

## Description

This project involves setting up Docker containers and running .NET applications. Follow the steps above to get started.

