FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Finate.Web/Finate.Web.csproj", "Finate.Web/"]
COPY ["Finate.Application/Finate.Application.csproj", "Finate.Application/"]
COPY ["Finate.Domain/Finate.Domain.csproj", "Finate.Domain/"]
COPY ["Finate.Shared/Finate.Shared.csproj", "Finate.Shared/"]
COPY ["Finate.Persistence/Finate.Persistence.csproj", "Finate.Persistence/"]
COPY ["Finate.Services/Finate.Services.csproj", "Finate.Services/"]
RUN dotnet restore "Finate.Web/Finate.Web.csproj"
COPY . .
WORKDIR "/src/Finate.Web"
RUN dotnet build "Finate.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Finate.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finate.Web.dll"]
