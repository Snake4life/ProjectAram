namespace LeagueConnector.Api
{
    public class BaseApi
    {
        protected readonly Connection _connection;

        public BaseApi(Connection connection)
        {
            _connection = connection;
        }
    }
}