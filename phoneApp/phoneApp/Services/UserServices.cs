using phoneApp.Model;
using phoneApp.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace phoneApp.Services
{
    public class UserServices
    {
        public async Task<List<UsersFromApi>> GetUsersAsync()
        {
            RestClient<UsersFromApi> restclient = new RestClient<UsersFromApi>();

            var userlist = await restclient.GetAsync();

            return userlist;
        }
    }
}
