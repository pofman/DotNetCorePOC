FROM microsoft/dotnet:latest

RUN curl -sL https://deb.nodesource.com/setup_7.x | bash -
RUN apt-get update && apt-get install build-essential nodejs -y

WORKDIR /app

COPY DotNetCorePOC.Web.csproj /app

RUN ["dotnet", "restore", "DotNetCorePOC.Web.csproj"]

COPY package.json /app

RUN ["npm", "install"]

COPY . /app
ENV ASPNETCORE_ENVIRONMENT "Development"

RUN ["dotnet", "build"]
RUN ["node_modules/.bin/gulp", "bundle"]

EXPOSE 5000/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000"]
