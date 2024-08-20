
namespace CRUDAppUsingADO.Utility

{
    public class ConnectionString
    {
        private static string cs= "server=SOMESHPC\\SQLEXPRESS; DataBase=CrudADOdb; Trusted_Connection=True";

        public static string dbcs { get => cs; }
    }
}
