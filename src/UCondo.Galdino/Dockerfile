#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80/tcp
#EXPOSE 443/tcp
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["UCondo.Galdino/UCondo.Galdino.csproj", "UCondoAPI/"]
##COPY ["./src/uCondo.Galdino.Application/uCondo.Galdino.Application.csproj", "uCondo.Galdino.Application/"]
##COPY ["./src/uCondo.Galdino.BootStrapper/uCondo.Galdino.BootStrapper.csproj", "uCondo.Galdino.BootStrapper/"]
##COPY ["./src/uCondo.Galdino.Domain/uCondo.Galdino.Domain.csproj", "uCondo.Galdino.Domain/"]
##COPY ["./src/uCondo.Galdino.Repository/uCondo.Galdino.Repository.csproj", "uCondo.Galdino.Repository/"]
#RUN dotnet restore "./UCondoAPI/UCondo.Galdino.csproj"
#COPY . .
## WORKDIR "/src"
#RUN dotnet build "UCondo.Galdino.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "UCondo.Galdino.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "UCondo.Galdino.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UCondo.Galdino.csproj", "UCondo.Galdino/"]
RUN dotnet restore "./UCondo.Galdino/UCondo.Galdino.csproj"
COPY . .
WORKDIR "/src/UCondo.Galdino"
RUN dotnet build "./UCondo.Galdino.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UCondo.Galdino.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UCondo.Galdino.dll"]