#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WorkflowR.Notifications.Presentation/WorkflowR.Notifications.Presentation.csproj", "WorkflowR.Notifications.Presentation/"]
RUN dotnet restore "WorkflowR.Notifications.Presentation/WorkflowR.Notifications.Presentation.csproj"
COPY . .
WORKDIR "/src/WorkflowR.Notifications.Presentation"
RUN dotnet build "WorkflowR.Notifications.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkflowR.Notifications.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkflowR.Notifications.Presentation.dll"]