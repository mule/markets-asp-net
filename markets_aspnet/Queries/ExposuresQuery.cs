using System.Collections.Generic;
using System.Text;
using markets_aspnet.Models;
using Npgsql;

namespace markets_aspnet.Queries
{
    public class ExposuresQuery
    {
        public List<MarketExposure> Execute(string path)
        {
            var exposures = new List<MarketExposure>();

            var strBldr = new StringBuilder();
            if (string.IsNullOrEmpty(path))
            {
                strBldr.Append(
                    "SELECT name, exposure, ltree2text(path) FROM market_tree WHERE path ~ '*{1}'");
            }
            else
            {
                strBldr.AppendFormat(
                    "SELECT name, exposure, ltree2text(path) FROM market_tree WHERE path ~ '{0}.*{{1}}'", path);
            }

            using (
                var conn =
                    new NpgsqlConnection(
                        "Host=milltorq-dev.cloudapp.net;Username=postgres;Password=password;Database=markets_dev"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Retrieve all rows
                    cmd.CommandText = strBldr.ToString();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var exposure = new MarketExposure
                            {
                                Name = reader.GetString(0),
                                Exposure = reader.GetDouble(1),
                                Path = reader.GetString(2)
                            };

                            exposures.Add(exposure);
                        }
                    }
                }
            }

            return exposures;
        }
    }
}