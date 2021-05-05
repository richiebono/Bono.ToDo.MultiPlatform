#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["1-Web/Bono.ToDo.Web.Razor/Bono.ToDo.Web.Razor.csproj", "1-Web/Bono.ToDo.Web.Razor/"]
RUN dotnet restore "1-Web/Bono.ToDo.Web.Razor/Bono.ToDo.Web.Razor.csproj"
COPY . .
WORKDIR "/src/1-Web/Bono.ToDo.Web.Razor"
RUN dotnet build "Bono.ToDo.Web.Razor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bono.ToDo.Web.Razor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bono.ToDo.Web.Razor.dll"]