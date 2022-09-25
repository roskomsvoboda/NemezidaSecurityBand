FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecurityBand.Demhack5.Daemon/SecurityBand.Demhack5.Daemon.csproj", "SecurityBand.Demhack5.Daemon/"]
RUN dotnet restore "SecurityBand.Demhack5.Daemon/SecurityBand.Demhack5.Daemon.csproj"
COPY . .
WORKDIR "/src/SecurityBand.Demhack5.Daemon"
RUN dotnet build "SecurityBand.Demhack5.Daemon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecurityBand.Demhack5.Daemon.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecurityBand.Demhack5.Daemon.dll"]
