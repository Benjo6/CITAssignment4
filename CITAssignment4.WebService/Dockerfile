FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CITAssignment4.WebService/CITAssignment4.WebService.csproj", "CITAssignment4.WebService/"]
RUN dotnet restore "CITAssignment4.WebService/CITAssignment4.WebService.csproj"
COPY . .
WORKDIR "/src/CITAssignment4.WebService"
RUN dotnet build "CITAssignment4.WebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CITAssignment4.WebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CITAssignment4.WebService.dll"]
