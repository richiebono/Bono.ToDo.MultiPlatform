#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["0-Test/Bono.ToDo.Application.Tests/Bono.ToDo.Application.Tests.csproj", "0-Test/Bono.ToDo.Application.Tests/"]
RUN dotnet restore "0-Test/Bono.ToDo.Application.Tests/Bono.ToDo.Application.Tests.csproj"
COPY . .
WORKDIR "/src/0-Test/Bono.ToDo.Application.Tests"
RUN dotnet build "Bono.ToDo.Application.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bono.ToDo.Application.Tests.csproj" -c Release -o /app/publish

RUN dotnet test "Bono.ToDo.Application.Tests.csproj"
