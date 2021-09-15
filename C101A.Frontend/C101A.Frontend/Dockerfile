FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY C101A.Frontend.csproj .
RUN dotnet restore "C101A.Frontend.csproj"
COPY . .
RUN dotnet build "C101A.Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C101A.Frontend.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html


COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

# Add bash
RUN apk add --no-cache bash

# Make our shell script executable
RUN chmod +x "/usr/share/nginx/html/build.sh"

# Start Nginx server
CMD ["/bin/bash", "-c", "/usr/share/nginx/html/build.sh && nginx -g \"daemon off;\""]

EXPOSE 80
EXPOSE 443
