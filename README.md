# SimpleAppSettingHelper
A simple tool to allow you to quickly pull an application setting from your web or console app, while specifying its return type.

##Basic Usage
```xml
<!-- Example of supported types -->
<appSettings>
    <add key="my:String" value="HelloWorld" />
    <add key="my:Int" value="12345" />
    <add key="my:Guid" value="00000000-0000-0000-0000-000000000000" />
    <add key="my:Bool" value="true" />
    <add key="my:DateTime" value="1/1/2016" />
  </appSettings>
```

```csharp
using SimpleAppSettingHelper;
  ...
  //get a string if it doesn't exist an error will be thrown.
  var aString = CurrentAppSettings.Get("my:String");
  
  //get a string set a default if the value has not been specified.
  var aString2 = CurrentAppSettings.Get("my:String",false,"default");
  
  //getting value and specifying the type.
  var anInt = CurrentAppSettings.Get<int>("my:Int");
  var aGuid = CurrentAppSettings.Get<Guid>("my:Guid");
  var aBool = CurrentAppSettings.Get<bool>("my:Bool");
  var aDate = CurrentAppSettings.Get<DateTime>("my:DateTime");
```
