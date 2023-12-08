FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder 
WORKDIR /Application
EXPOSE 8080
EXPOSE 443

# Скопируем все файлы из проекта в файловую систему контейнера
COPY . ./
# Запустим restore для загрузки зависимостей
RUN dotnet restore
# Опубликуем собранный dll в папку "output"
RUN dotnet publish -c Release -o output

# Теперь соберём образ, в котором наше приложение 
# будет запущено. Для запуска приложения достаточно
# среды выполнения aspnet, без sdk
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Application
# Скопируем файлы приложения из предыдущего образа 
COPY --from=builder /Application/output .
ENV ASPNETCORE_ENVIRONMENT=Development
# укажем команду, которая будет запускать приложение
ENTRYPOINT ["dotnet", "WebApplication1.dll"]