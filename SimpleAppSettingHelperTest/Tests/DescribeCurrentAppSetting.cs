using System;
using AppSettingHelperTest.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppSettingHelperTest
{
    public class DescribeCurrentAppSetting
    {
        [TestClass]
        public class EnsureGenericsWork
        {
            [TestMethod]
            public void when_its_a_string()
            {
                var result = MySettingStatic.GetAGenericType_String;
                Assert.AreEqual(typeof(String), result.GetType());
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
                Assert.AreEqual("HelloWorld", result);
            }

            [TestMethod]
            public void when_its_an_int()
            {
                var result = MySettingStatic.GetAGenericType_Int;
                Assert.AreEqual(typeof(int), result.GetType());
                Assert.AreEqual(12345, result);

            }

            [TestMethod]
            public void when_its_a_guid()
            {
                var result = MySettingStatic.GetAGenericType_Guid;
                Assert.AreEqual(typeof(Guid), result.GetType());
                Assert.AreEqual(Guid.Empty, result);
            }

            [TestMethod]
            public void when_its_a_bool()
            {
                var result = MySettingStatic.GetAGenericType_Bool;
                Assert.AreEqual(typeof(bool), result.GetType());

            }

            [TestMethod]
            public void when_its_a_datetime()
            {
                var result = MySettingStatic.GetAGenericType_DateTime;
                Assert.AreEqual(typeof(DateTime), result.GetType());

            }

        }

        [TestClass]
        public class EnsureStringIsReturned
        {
            [TestMethod]
            public void when_key_and_value_exists()
            {
                var result = MySettingStatic.GetAString;
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            }

            [TestMethod]
            public void when_default_is_specified()
            {
                var result = MySettingStatic.GetAStringThatDoesntExistWithDefault;
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            }
        }

        [TestClass]
        public class EnsureAnExceptionIsReturned
        {
            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void when_its_a_key_doesnt_exist()
            {
                var result = MySettingStatic.GetAStringThatDoesntExist;
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void when_value_is_empty()
            {
                var result = MySettingStatic.GetAStringThatDoesntExist;
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void when_value_is_whitespace()
            {
                var result = MySettingStatic.GetAStringThatDoesntExist;
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void when_value_is_empty_for_a_generic()
            {
                var result = MySettingStatic.GetAGenericThatThrowsAnException;
            }
        }

	    [TestClass]
	    public class EnsureBasicGetWorks
	    {
		    [TestMethod]
		    public void when_value_is_empty_and_default_is_specified()
		    {
			    var defaultString = "123";
			    var result = SimpleAppSettingHelper.CurrentAppSettings.Get("keyWithMissingValue", defaultString);
				Assert.AreEqual(result,defaultString);
		    }
		}

	    [TestClass]
	    public class EnsureEnumGetWorks
	    {
		    [TestMethod]
		    public void when_value_is_empty_and_default_is_specified()
		    {
			    var result = SimpleAppSettingHelper.CurrentAppSettings.GetEnum("keyWithMissingValue", StorageTypes.TSQL);
			    Assert.AreEqual(result, StorageTypes.TSQL);
		    }

		    [TestMethod]
		    public void when_value_is_valid_enum_string()
		    {
			    var result = SimpleAppSettingHelper.CurrentAppSettings.GetEnum("enumWithValidString", StorageTypes.TSQL);
			    Assert.AreEqual(result, StorageTypes.Redis);
		    }

		    [TestMethod]
		    public void when_value_is_valid_enum_int()
		    {
			    var result = SimpleAppSettingHelper.CurrentAppSettings.GetEnum("enumWithValidInt", StorageTypes.TSQL);
			    Assert.AreEqual(result, StorageTypes.Redis);
		    }
		}
	}
}
