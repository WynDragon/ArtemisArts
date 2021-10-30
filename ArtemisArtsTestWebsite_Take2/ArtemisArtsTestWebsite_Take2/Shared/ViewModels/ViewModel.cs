using ArtemisArtsTestWebsite_Take2.Data;
using ArtemisArtsTestWebsite_Take2.Data.Models;

namespace ArtemisArtsTestWebsite_Take2.Shared.ViewModels
{
    /// <summary>
    /// All other ViewModels will draw off this ViewModel
    /// </summary>
    public abstract class ViewModel
    {

        public bool Loading { get; set; } = true;
        public bool UserAuthenticated { get; set; } = false;

        //public Account Account {get; set;}
        //public Session Session {get; set;}
    }
}
