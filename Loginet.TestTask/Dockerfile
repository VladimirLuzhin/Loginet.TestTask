FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Loginet.TestTask/Loginet.TestTask.csproj", "Loginet.TestTask/"]
COPY ["Loginet.TestTask.Core/Loginet.TestTask.Core.csproj", "Loginet.TestTask.Core/"]
RUN dotnet restore "Loginet.TestTask/Loginet.TestTask.csproj"
COPY . .
WORKDIR "/src/Loginet.TestTask"
RUN dotnet build "Loginet.TestTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loginet.TestTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loginet.TestTask.dll"]