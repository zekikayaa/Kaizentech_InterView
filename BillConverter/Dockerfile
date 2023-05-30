FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BillConverter/BillConverter.csproj", "BillConverter/"]
RUN dotnet restore "BillConverter/BillConverter.csproj"
COPY . .
WORKDIR "/src/BillConverter"
RUN dotnet build "BillConverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BillConverter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BillConverter.dll"]
