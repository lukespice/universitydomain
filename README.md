# Lantern Pay University Test #

## Changes would use for real world ##

* Use View models / DTOs
* Services to get logic out of Controllers
* Return correct status codes e.g. 404 when item not found
* Versioning of endpoints
* Swagger (or other documentation)
* Integration tests
* Use real Visual Studio with ReSharper

## Requirements ##

.NET Core 2

## Test ##

```
dotnet test test/LanternUniversity.UnitTests/LanternUniversity.UnitTests.csproj
```

## Run ##

```
dotnet run --project LanternUniversity/LanternUniversity.csproj
```