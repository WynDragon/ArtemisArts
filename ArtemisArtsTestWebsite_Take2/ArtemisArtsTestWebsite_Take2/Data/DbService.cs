using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ArtemisArtsTestWebsite_Take2.Data.Models;

namespace ArtemisArtsTestWebsite_Take2.Data
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _configuration;
        private const string CONN_STR_RW = ""; //read write
        private const string CONN_STR_RO = ""; //read only

        #region Account Queries
        public async Task<bool> AddAccountAsync(Account acc)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RW));
            db.Open();
            var added = await db.ExecuteAsync("INSERT INTO Accounts (UserId, FirstName, LastName, DisplayName, Email, ProfilePictureUri, CreateDate) " +
               "VALUES(@UserId, @FirstName, @LastName, @DisplayName, @Email, @ProfilePictureUri, @CreateDate)", acc) > 0;
            return added;
        }

        public async Task<List<Account>> GetAccountListAsync()
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RO));
            db.Open();
            var result = await db.QueryAsync<Account>("SELECT * FROM Accounts;");
            return result.ToList();
        }

        public async Task<Account> GetAccountAsync(string usrId)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RO));
            db.Open();
            var result = await db.QueryAsync<Account>("SELECT * FROM Accounts WHERE UserId=@UserId;", new { UserId = usrId });
            var account = result.FirstOrDefault();
            return account;
        }

        public async Task<Account> GetAccountAsync(int accId)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RO));
            db.Open();
            var result = await db.QueryAsync<Account>("SELECT * FROM Accounts WHERE AccountId=@AccountId;", new { AccountId = accId });
            var account = result.FirstOrDefault();
            return account;
        }

        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RO));
            db.Open();
            var result = await db.QueryAsync<Account>("SELECT * FROM Accounts WHERE Email=@Email;", new { Email = email });
            var account = result.FirstOrDefault();
            return account;
        }

        public async Task<bool> UpdateAccountAsync(Account acc)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RW));
            db.Open();
            var updated = await db.ExecuteAsync("UPDATE Accounts SET FirstName=@FirstName, LastName=@LastName, DisplayName=@DisplayName, Email=@Email, " +
                "ProfilePictureUri=@ProfilePictureUri, RegisterDate=@RegisterDate, UpdateDate=@UpdateDate, DeleteDate=@DeleteDate WHERE AccountId=@AccountId", acc) > 0;
            return updated;
        }

        public async Task RemoveAccountAsync(int accId)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RW));
            db.Open();
            var deleted = await db.ExecuteAsync("DELETE FROM Accounts WHERE AccountId=@AccountId", new { AccountId = accId }) > 0;
        }
        #endregion

        #region Pages Queries
        //similar to Images, but is for comic pages only
        public async Task<bool> AddPageAsync(Comics comic)
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RW));
            db.Open();
            var added = await db.ExecuteAsync("INSERT INTO Pages (AccountId, Url, DraftId, CreateDate, Notes) " +
                "VALUES(@AccountId, @Url, @DraftId, @CreateDate, @Notes)", comic) > 0;
            return added;
        }

        /*
        public async Task<List<Comics>> GetPagesListAsync()
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RO));
            db.Open();
            var history = await db.ExecuteAsync("SELECT * FROM Comics;");
            return history.ToList(); //TO DO: define an IEnumerable called ToList for Comics
        }*/


        #endregion


        public async Task<bool> CleanUpDb()
        {
            using var db = new SqlConnection(_configuration.GetConnectionString(CONN_STR_RW));
            var sql = "exec [clean_up_deleted_accounts]"; //stored procedure to remove deleted accounts
            try
            {
                db.Query(sql, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
