#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["../Services/SanPham.API/SanPham.API/SanPham.API.csproj", "../Services/SanPham.API/SanPham.API/"]
RUN dotnet restore "../Services/SanPham.API/SanPham.API/SanPham.API.csproj"
COPY . .
WORKDIR "/src/../Services/SanPham.API/SanPham.API"
RUN dotnet build "SanPham.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SanPham.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SanPham.API.dll"]