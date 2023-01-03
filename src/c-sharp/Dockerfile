FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# copy and publish app and libraries
COPY . ./
COPY ./Api/nuget.config /root/.nuget/NuGet/NuGet.Config

RUN dotnet publish ./Api/Api.csproj -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80/tcp
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "Api.dll"]