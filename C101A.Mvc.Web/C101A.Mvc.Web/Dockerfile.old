#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "C101A.Mvc.Web.csproj" .
RUN dotnet restore C101A.Mvc.Web.csproj
COPY . .
RUN dotnet build C101A.Mvc.Web.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C101A.Mvc.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C101A.Mvc.Web.dll"]
