FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Carbon.Sample.Masstransit/Carbon.Sample.Masstransit.csproj", "Carbon.Sample.Masstransit/"]
RUN dotnet restore "Carbon.Sample.Masstransit/Carbon.Sample.Masstransit.csproj"
COPY . .
WORKDIR "/src/Carbon.Sample.Masstransit"
RUN dotnet build "Carbon.Sample.Masstransit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carbon.Sample.Masstransit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carbon.Sample.Masstransit.dll"]
