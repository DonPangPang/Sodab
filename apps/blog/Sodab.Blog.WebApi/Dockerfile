#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["apps/blog/Sodab.Blog.WebApi/Sodab.Blog.WebApi.csproj", "apps/blog/Sodab.Blog.WebApi/"]
RUN dotnet restore "apps/blog/Sodab.Blog.WebApi/Sodab.Blog.WebApi.csproj"
COPY . .
WORKDIR "/src/apps/blog/Sodab.Blog.WebApi"
RUN dotnet build "Sodab.Blog.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sodab.Blog.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sodab.Blog.WebApi.dll"]