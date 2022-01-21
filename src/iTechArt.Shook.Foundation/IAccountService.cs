﻿using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterAsync(User user, string password);
        public Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe = false);
        public Task<SignInResult> SignInAsync(User user, string password, bool rememberMe = false);
        public Task SignOutAsync();
    }
}