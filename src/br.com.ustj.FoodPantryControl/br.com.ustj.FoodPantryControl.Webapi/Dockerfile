#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["br.com.ustj.FoodPantryControl.Webapi/br.com.ustj.FoodPantryControl.Webapi.csproj", "br.com.ustj.FoodPantryControl.Webapi/"]
COPY ["br.com.ustj.FoodPantryControl.Application/br.com.ustj.FoodPantryControl.Application.csproj", "br.com.ustj.FoodPantryControl.Application/"]
COPY ["br.com.ustj.FoodPantryControl.Domain/br.com.ustj.FoodPantryControl.Domain.csproj", "br.com.ustj.FoodPantryControl.Domain/"]
COPY ["br.com.ustj.FoodPantryControl.Infrastructure/br.com.ustj.FoodPantryControl.Infrastructure.csproj", "br.com.ustj.FoodPantryControl.Infrastructure/"]
RUN dotnet restore "br.com.ustj.FoodPantryControl.Webapi/br.com.ustj.FoodPantryControl.Webapi.csproj"
COPY . .
WORKDIR "/src/br.com.ustj.FoodPantryControl.Webapi"
RUN dotnet build "br.com.ustj.FoodPantryControl.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "br.com.ustj.FoodPantryControl.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "br.com.ustj.FoodPantryControl.Webapi.dll"]