FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV TZ="America/Bogota"

WORKDIR /app/publish

#Copiar los compilados
COPY ["Inventario.API/", "/app/publish"]

FROM base AS final
ENTRYPOINT ["dotnet", "Inventario.API.dll"]