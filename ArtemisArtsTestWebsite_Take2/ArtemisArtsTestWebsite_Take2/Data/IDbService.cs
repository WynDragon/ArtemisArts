using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtemisArtsTestWebsite_Take2.Data.Models;

namespace ArtemisArtsTestWebsite_Take2.Data
{
    public interface IDbService
    {
        #region Account
        public Task<bool> AddAccountAsync(Account acc);
        public Task<List<Account>> GetAccountListAsync();
        public Task<Account> GetAccountAsync(string usrId);
        public Task<Account> GetAccountAsync(int accId);
        public Task<Account> GetAccountByEmailAsync(string email);
        public Task<bool> UpdateAccountAsync(Account acc);
        public Task RemoveAccountAsync(int accId);
        #endregion

        #region Pages
        public Task<bool> AddPageAsync(Pages page);
        public Task<List<Pages>> GetPagesListAsync();
        #endregion

        #region Draft

        #endregion

        #region Image

        #endregion

        #region News

        #endregion

        #region Settings

        #endregion

        #region Scripts
        public Task<bool> CleanUpDb();
        #endregion

    }
}
