using System;


namespace getAddress.Sdk.Api
{

    public abstract class AdminApiBase:ApiBase
    {
        public AdminKey AdminKey
        {
            get;
        }

        protected AdminApiBase(AdminKey adminKey, GetAddesssApi api):base(api)
        {
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey)); 

            AdminKey = adminKey;
        }
    }

     public abstract class ApiBase
    {
        protected readonly GetAddesssApi Api;

        protected ApiBase(GetAddesssApi api)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            Api = api;
        }


    }
}
