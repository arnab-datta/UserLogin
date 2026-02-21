using MySqlConnector;
using System.Data;
using UserLogin.Models.Api;

namespace UserLogin.Services
{
    public class DbService
    {
        public readonly IConfiguration _configuration;
        public readonly string _connectionString;
        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public async Task<DataTable> AddInfoToDb(UserDataModel us)
        {
            DataTable dt = new DataTable();

            using var sqlConnection = new MySqlConnection(_connectionString);
            await sqlConnection.OpenAsync();

            using var sqlCommand = new MySqlCommand("sp_InsertUserData", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = 180;
            sqlCommand.Parameters.AddWithValue("@par_first_name", us.first_name);
            sqlCommand.Parameters.AddWithValue("@par_last_name", us.last_name);
            sqlCommand.Parameters.AddWithValue("@par_user_email", us.user_email);
            sqlCommand.Parameters.AddWithValue("@par_phone_no", us.phone_no);
            sqlCommand.Parameters.AddWithValue("@par_line_1", us.user_address.line_1);
            sqlCommand.Parameters.AddWithValue("@par_line_2", us.user_address.line_2);
            sqlCommand.Parameters.AddWithValue("@par_city", us.user_address.city);
            sqlCommand.Parameters.AddWithValue("@par_state", us.user_address.state);
            sqlCommand.Parameters.AddWithValue("@par_pincode", us.user_address.pincode);
            sqlCommand.Parameters.AddWithValue("@par_landmark", us.user_address.landmark);
            using var reader = await sqlCommand.ExecuteReaderAsync();
            dt.Load(reader);
            return dt;
        }

        public async Task<DataTable> EditUserBasicInfoToDb(UserDataModel us, int userId)
        {
            DataTable dt = new DataTable();

            using var sqlConnection = new MySqlConnection(_connectionString);
            await sqlConnection.OpenAsync();

            using var sqlCommand = new MySqlCommand("sp_UpdateUserBasicInfo", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = 180;
            sqlCommand.Parameters.AddWithValue("@par_user_id", userId);
            sqlCommand.Parameters.AddWithValue("@par_first_name", us.first_name);
            sqlCommand.Parameters.AddWithValue("@par_last_name", us.last_name);
            sqlCommand.Parameters.AddWithValue("@par_user_email", us.user_email);
            sqlCommand.Parameters.AddWithValue("@par_phone_no", us.phone_no);
            using var reader = await sqlCommand.ExecuteReaderAsync();
            dt.Load(reader);
            return dt;
        }

        public async Task<DataTable> EditUserAddressInfoToDb(UserDataModel us, int userId, int addressId)
        {
            DataTable dt = new DataTable();

            using var sqlConnection = new MySqlConnection(_connectionString);
            await sqlConnection.OpenAsync();

            using var sqlCommand = new MySqlCommand("sp_UpdateUserAddress", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = 180;
            sqlCommand.Parameters.AddWithValue("@par_user_id", userId);
            sqlCommand.Parameters.AddWithValue("@par_address_id", addressId);
            sqlCommand.Parameters.AddWithValue("@par_line_1", us.user_address.line_1);
            sqlCommand.Parameters.AddWithValue("@par_line_2", us.user_address.line_2);
            sqlCommand.Parameters.AddWithValue("@par_city", us.user_address.city);
            sqlCommand.Parameters.AddWithValue("@par_state", us.user_address.state);
            sqlCommand.Parameters.AddWithValue("@par_pincode", us.user_address.pincode);
            sqlCommand.Parameters.AddWithValue("@par_landmark", us.user_address.landmark);
            using var reader = await sqlCommand.ExecuteReaderAsync();
            dt.Load(reader);
            return dt;
        }


    }
}
