#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./TheMusicStore/TheMusicStore.csproj" --disable-parallel
RUN dotnet publish "./TheMusicStore/TheMusicStore.csproj" -c relase -o /app --no-restore
#Server stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "TheMusicStore.dll"]