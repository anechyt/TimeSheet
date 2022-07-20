#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api/TimeSheet.Api/TimeSheet.Api.csproj", "src/Api/TimeSheet.Api/"]
COPY ["src/Application/TimeSheet.Application/TimeSheet.Application.csproj", "src/Application/TimeSheet.Application/"]
COPY ["src/Domain/TimeSheet.Domain/TimeSheet.Domain.csproj", "src/Domain/TimeSheet.Domain/"]
COPY ["src/Infrastructure/TimeSheet.Infrastructure/TimeSheet.Infrastructure.csproj", "src/Infrastructure/TimeSheet.Infrastructure/"]
RUN dotnet restore "src/Api/TimeSheet.Api/TimeSheet.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/TimeSheet.Api"
RUN dotnet build "TimeSheet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeSheet.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeSheet.Api.dll"]
