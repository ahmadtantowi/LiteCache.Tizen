# LiteCache.Tizen
Easely cache any data structure for specific amount of time in Tizen<span>.NET app, which powered by LiteDB.

[![NuGet](https://img.shields.io/nuget/v/LiteCache.Tizen.svg?label=NuGet)](https://www.nuget.org/packages/LiteCache.Tizen/)

## Platform Support
|Platform|Version|
|--------|:-----:|
|Tizen|4.0+|

## Setup
Install LiteCache.Tizen package on your Tizen<span>.NET project.

It's required to set a cache directory for your application, which will create specific folder with the application on disk. This can be done by assign value to static string on Cotton before calling other COTTON method:

```csharp
Cotton.CacheDirectory = "Your cache directory";
```
e.g:
```csharp
Cotton.CacheDirectory = Current.DirectoryInfo.Cache;
```

### Encryption
LiteDB offers built in encryption support (https://github.com/mbdavid/LiteDB/wiki/Connection-String), which can be enabled with a static string on Barrel before calling ANY method. You must choose this up front before saving any data.

```csharp
Cotton.EncryptionKey = "Your encryption key";
```

And you ready to cache any data structure.

&nbsp;
## Version history

### 0.2.0
+ Add function to read any existing key that stored on disk, both active or expired

### 0.1.0
+ Create, Read, Delete cache data with key to storage
+ Check if key is expired
+ Check if key is exist