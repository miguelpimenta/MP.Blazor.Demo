#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MP.Blazor.Demo/MP.Blazor.Demo.csproj", "MP.Blazor.Demo/"]
RUN dotnet restore "MP.Blazor.Demo/MP.Blazor.Demo.csproj"
COPY . .
WORKDIR "/src/MP.Blazor.Demo"
RUN dotnet build "MP.Blazor.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MP.Blazor.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MP.Blazor.Demo.dll"]