using CogentCms.Core.Sql;

namespace CogentCms.Core.Auth
{
    public class AppUserService : IAppUserService
    {
        private readonly SqlConnectionFactory sqlConnectionFactory;

        public AppUserService(SqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool DoesAppUserExist(string idProvider, string subjectId)
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select count(AppUserId) from AppUser where IdProvider = @IdProvider and SubjectId = @SubjectId";
                cmd.Parameters.AddWithValue("IdProvider", idProvider);
                cmd.Parameters.AddWithValue("SubjectId", subjectId);

                return ((int)cmd.ExecuteScalar()) == 1;
            }
        }
    }
}
