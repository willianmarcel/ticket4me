#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ticket4me.Api/Ticket4me.Api.csproj", "Ticket4me.Api/"]
COPY ["Ticket4me.Application/Ticket4me.Application.csproj", "Ticket4me.Application/"]
COPY ["Ticket4me.Domain/Ticket4me.Domain.csproj", "Ticket4me.Domain/"]
COPY ["Ticket4me.Infra.Data.EF/Ticket4me.Infra.Data.EF.csproj", "Ticket4me.Infra.Data.EF/"]
RUN dotnet restore "Ticket4me.Api/Ticket4me.Api.csproj"
COPY . .
WORKDIR "/src/Ticket4me.Api"
RUN dotnet build "Ticket4me.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ticket4me.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticket4me.Api.dll"]