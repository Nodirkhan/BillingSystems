namespace Billing.UserApi.Domains
{
    public static class ConnectionSetting
    {
        public const string ConnectionString = "mongodb://host.docker.internal:27017";
        public const string DataBase = "BillingUserDatabase";
        public const string UserCollection = "User";
    }
}
