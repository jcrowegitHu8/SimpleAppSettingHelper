# SimpleAppSettingHelper
A simple tool to allow you to quickly pull an application setting from your web or console app, while specifying its return type.

## Basic Usage
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
  
  //get a string and don't throw an error if it doesn't exist.
  var aString = CurrentAppSettings.Get("my:String",false);
  
  //get a string set a default if the value has not been specified.
  var aString3 = CurrentAppSettings.Get("my:String",false,"default");
  
  //getting value and specifying the type.
  var anInt = CurrentAppSettings.Get<int>("my:Int");
  var aGuid = CurrentAppSettings.Get<Guid>("my:Guid");
  var aBool = CurrentAppSettings.Get<bool>("my:Bool");
  var aDate = CurrentAppSettings.Get<DateTime>("my:DateTime");
```
## Default Values returned from generic method when an exception will not be thrown.
```csharp
  //Default of 0
  var anInt = CurrentAppSettings.Get<int>("my:Int", false);
  
  //Default of Guid.Empty
  var aGuid = CurrentAppSettings.Get<Guid>("my:Guid", false);
  
  //Default of false
  var aBool = CurrentAppSettings.Get<bool>("my:Bool", false);
  
  //Default of DateTime.Min
  var aDate = CurrentAppSettings.Get<DateTime>("my:DateTime", false);
```

Version History:

1.0.0.17
* Fix that generic get method was not returning default value of expected type.
* Added image and details to .nuspec for improved gallery experience.

1.0.0.14
* Added support for Enums ex: GetEnum<T>(keyName, (Optional)defaultValue)
* Added method Get(keyName, defaultValue)
