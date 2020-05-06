using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GameScore.BL.Interfaces
{
    public interface IAccountBusiness
    {
        User CreateNewUser(string username, string password);
        User GetUserByUsernameAndPassword(string username, string password);
        ClaimsPrincipal CreateClaimsPrincipal(User user, string scheme);
    }
}
