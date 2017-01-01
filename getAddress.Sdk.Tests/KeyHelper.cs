using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    static class KeyHelper
    {
        public static string GetAdminKey()
        {
            var adminKey = Environment.GetEnvironmentVariable("getaddress_adminkey", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(adminKey)) throw new Exception("Add your admin key to your Environmental Variables");

            return adminKey;
        }
    }
}
