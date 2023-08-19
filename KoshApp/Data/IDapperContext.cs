using System.Data;

namespace KoshApp.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
