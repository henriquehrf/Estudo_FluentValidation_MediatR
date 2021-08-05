#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FluentValidation_Estudo/FluentValidation_Estudo.csproj", "FluentValidation_Estudo/"]
RUN dotnet restore "FluentValidation_Estudo/FluentValidation_Estudo.csproj"
COPY . .
WORKDIR "/src/FluentValidation_Estudo"
RUN dotnet build "FluentValidation_Estudo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentValidation_Estudo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentValidation_Estudo.dll"]