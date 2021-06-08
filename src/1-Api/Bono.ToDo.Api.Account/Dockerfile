
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src/1-Api/Bono.ToDo.Api.Account/
COPY ["Bono.ToDo.Api.Account.csproj", "1-Api/Bono.ToDo.Api.Account/"]
RUN dotnet restore "1-Api/Bono.ToDo.Api.Account/Bono.ToDo.Api.Account.csproj"
COPY . .
WORKDIR "/src/1-Api/Bono.ToDo.Api.Account"
RUN dotnet build "Bono.ToDo.Api.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bono.ToDo.Api.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bono.ToDo.Api.Account.dll"]