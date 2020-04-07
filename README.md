# MobileDeliveryLogger ![MobileDeliveryLogger Nuget Versions (UMDNuget Artifacts)][logo]
## [v1.4.1](https://dev.azure.com/unitedwindowmfg/United%20Mobile%20Delivery/_packaging?_a=package&feed=UMDNuget&package=MobileDeliveryGeneral&protocolType=NuGet&version=1.4.4&view=versions)
[logo]: https://github.com/vergaraunited/Docs/blob/master/imgs/png/logger_icon.png (http://www.google.com)

### Mobile Delivery Logger shared amongts all projects for standardized logging.

## NuGet Package References
![NuGet Package Model](https://github.com/vergaraunited/Docs/blob/master/imgs/MobileDeliveryModel.jpg)


#### UMDNuGet - Azure Artifact Repository
##### nuget.config file
```xml
<configuration>
  <packageSources>
    <clear />
    <add key="UMDNuget" value="https://pkgs.dev.azure.com/unitedwindowmfg/1e4fcdac-b7c9-4478-823a-109475434848/_packaging/UMDNuget/nuget/v3/index.json" />
  </packageSources>
</configuration>
```
    
## Configuration
#### Configuration is built into the docker image based on the settings in the app.config

```xml
<appSettings>
    <add key="LogPath" value="C:\app\logs\" />
    <add key="LogLevel" value="Info" />
    <add key="Url" value="localhost" />
    <add key="Port" value="81" />
    <add key="WinsysUrl" value="localhost" />
    <add key="WinsysPort" value="8181" />
    <add key="WinsysSrcFilePath" value="\\Fs01\vol1\Winsys32\DATA" />
    <!-- If left empty WinsysDestFilePath defaults to Environment.GetFolderPath(Environment.SpecialFolder.Desktop)-->
    <add key="WinsysDstFilePath" value="" />
    <add key="ClientSettingsProvider.ServiceUri" value="" />
</appSettings>`
```

## NuGet

#### Initialize the project
`nuget restore`

#### Don't need to run spec, only once to generate the nuspec file which is already checked into git
`nuget spec`

#### BuGet pack - don't checkin nupkg file, (.ignore git)
`nuget pack`
`nuget pack -IncludeReferencedProjects -Build -Symbols -Properties Configuration=Release`

#### Push Artifact to Repository (Azure/DevOps)
`find -name *.nupkg | xargs -i nuget push {} -Source "UMDNuget" -ApiKey az`

## Docker

#### Build
`docker build -t mpbiledeliverylogger .`

#### Run
`docker run -d -p 81:81 --name mobiledeliverylogger --mount source=logs,destination=/app/logs  mobiledeliverymanager`

#### Interactive shell into mobiledeliverymanager container
`winpty docker exec -it 03f8ba004e11 cmd`

#### MSSQL
** `docker exec -it mobiledeliverylogger`

#### Log Volume for persisting and exposing the logs outside of the container and on localhost's filesystem
##### In order access log files and not issue docker commands to enter the interactive shell within the running container, volumes (and mounts) offer the ability to expose and persist across restarts and rebuilds on the localhost's file system.
`docker service create 
    --mount 'type=volume,src=<VOLUME-NAME>,dst=<CONTAINER-PATH>,volume-driver=local,volume-opt=type=nfs,volume-opt=device=<nfs-server>:<nfs-path>,"volume-opt=o=addr=<nfs-address>,vers=4,soft,timeo=180,bg,tcp,rw"' 
    --name myservice 
    <IMAGE>`
`docker volume create logs`
`docker volume ls`
`docker volume inspect logs`
