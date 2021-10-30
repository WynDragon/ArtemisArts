using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ArtemisArtsTestWebsite_Take2.Data.Models;

namespace ArtemisArtsTestWebsite_Take2.Data
{
    public class DbService
    {
        private readonly _configuration;

        #region WebcomicPage Queries
        public async Task<List<Image>> GetPagesListAsync()
        {
            using var db = new SqlConnection(_configuration.GetConnectionString());
            db.Open();
            var history = await db.ExecuteAsync("Query goes here");
            return history;
        }
        #endregion

    }
}
