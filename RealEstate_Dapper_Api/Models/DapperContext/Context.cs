using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    /// <summary>
    /// Veritabanı bağlantılarını yönetmek için kullanılır.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// appsettings.json dosyasındaki ayarları okumak için
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// appsettings.json dosyasında bulunan "connection" içindeki stringi tutmak için. 
        /// Bu dizin veritabanına bağlanmak için gerekli
        /// </summary>
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }

        /// <summary>
        /// Veritabanı bağlantısı oluşturur
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);

    }
}