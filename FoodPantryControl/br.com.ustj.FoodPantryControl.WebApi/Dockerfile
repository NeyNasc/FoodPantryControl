#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["br.com.ustj.FoodPantryControl.WebApi/br.com.ustj.FoodPantryControl.WebApi.csproj", "br.com.ustj.FoodPantryControl.WebApi/"]
RUN dotnet restore "br.com.ustj.FoodPantryControl.WebApi/br.com.ustj.FoodPantryControl.WebApi.csproj"
COPY . .
WORKDIR "/src/br.com.ustj.FoodPantryControl.WebApi"
RUN dotnet build "br.com.ustj.FoodPantryControl.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "br.com.ustj.FoodPantryControl.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "br.com.ustj.FoodPantryControl.WebApi.dll"]