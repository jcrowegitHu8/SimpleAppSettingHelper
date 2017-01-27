using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAppSettingHelper;

namespace AppSettingHelperTest
{
    /// <summary>
    /// Showing use case in which you have a single static class to hold
    /// all of your settings used.  It makes refactoring easier as all
    /// usages are easier to track down and you don't have string literals all over your application.
    /// </summary>
    internal class MySettingStatic 
    {
        public static string GetAString
        {
            get{
                return CurrentAppSettings.Get("validKey");
            }
        }

        public static string GetAStringThatDoesntExist
        {
            get
            {
                return CurrentAppSettings.Get("keyWithMissingValue");
            }
        }

        public static string GetAStringThatIsWhiteSpacet
        {
            get
            {
                return CurrentAppSettings.Get("keyWithWhiteSpaceValue");
            }
        }

        public static string GetAStringThatDoesntExistWithDefault
        {
            get
            {
                return CurrentAppSettings.Get("keyWithMissingValue",false,"default");
            }
        }

        public static string GetAGenericType_String
        {
            get
            {
                return CurrentAppSettings.Get("genericString");
            }
        }

        public static int GetAGenericType_Int
        {
            get
            {
                return CurrentAppSettings.Get<int>("genericInt");
            }
        }

        public static Guid GetAGenericType_Guid
        {
            get
            {
                return CurrentAppSettings.Get<Guid>("genericGuid");
            }
        }

        public static bool GetAGenericType_Bool
        {
            get
            {
                return CurrentAppSettings.Get<bool>("genericBool");
            }
        }

        public static DateTime GetAGenericType_DateTime
        {
            get
            {
                return CurrentAppSettings.Get<DateTime>("genericDateTime");
            }
        }

        public static bool GetAGenericThatThrowsAnException
        {
            get
            {
                return CurrentAppSettings.Get<bool>("keyWithMissingValue");
            }
        }
    }
}
