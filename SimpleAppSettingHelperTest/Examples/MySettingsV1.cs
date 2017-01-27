using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAppSettingHelper;

namespace AppSettingHelperTest
{
    internal interface IEmailSettingsV1
    {
        string EmailUserName { get; }
        string EmailPassword { get; }
    }

    /// <summary>
    /// Demo of using an instance class so that when
    /// used in an application the settings can be DI with the interface which allows them
    /// to be mocked for unit testing.
    /// 
    /// Mocking this logic means you won't have to try and change app.config during runtime
    /// which is problematic for MSTest that will run concurrently.
    /// </summary>
    class MySettingsV1 : IEmailSettingsV1
    {

        public string EmailUserName
        {
            get { return CurrentAppSettings.Get("email:user"); }
        }

        public string EmailPassword
        {
            get { return CurrentAppSettings.Get("email:pswd"); }
        }

    }
}
