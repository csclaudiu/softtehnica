using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace API.CustomIdentityFramework
{
    // http://www.asp.net/identity/overview/extensibility/overview-of-custom-storage-providers-for-aspnet-identity
    // http://www.asp.net/identity/overview/extensibility/change-primary-key-for-users-in-aspnet-identity

    public class OperatorStore : 
        IUserStore<SoftTehnicaOperator, int>, 
        IUserPasswordStore<SoftTehnicaOperator, int>,
        IUserEmailStore<SoftTehnicaOperator, int>
    {
        private DATA.softtehnicaEntities Repository = new DATA.softtehnicaEntities();
        public Task CreateAsync(SoftTehnicaOperator user)
        {
            var newOperator = new DATA.user()
            {
                email = user.Email,
                name = user.Name,
                password = user.PasswordHash,
                username = user.UserName,
                role = Repository.roles.Where(r => r.role_name == "Operator").FirstOrDefault()
            };
            Repository.users.Add(newOperator);
            Repository.SaveChanges();
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(SoftTehnicaOperator user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public Task<SoftTehnicaOperator> FindByEmailAsync(string email)
        {
            var op = Repository.users.FirstOrDefault(o => o.email == email);
            SoftTehnicaOperator stop = null;
            if (op != null)
            {
                stop = new SoftTehnicaOperator()
                {
                    Id = op.id,
                    Email = op.email,
                    UserName = op.username
                };
            }
            return Task.FromResult<SoftTehnicaOperator>(stop);
        }

        public Task<SoftTehnicaOperator> FindByIdAsync(int userId)
        {
            var op = Repository.users.FirstOrDefault(o => o.id == userId);
            SoftTehnicaOperator stop = null;
            if(op!=null)
            {
                stop = new SoftTehnicaOperator()
                {
                    Id = op.id,
                    Email = op.email,
                    UserName = op.username,
                    PasswordHash = op.password
                };
            }
            return Task.FromResult<SoftTehnicaOperator>(stop);
        }

        public Task<SoftTehnicaOperator> FindByNameAsync(string userName)
        {

            var op = Repository.users.FirstOrDefault(o => o.email == userName || o.username == userName);
            SoftTehnicaOperator stop = null;
            if (op != null)
            {
                stop = new SoftTehnicaOperator()
                {
                    Id = op.id,
                    Email = op.email,
                    UserName = op.username,
                    PasswordHash = op.password
                };
            }
            return Task.FromResult<SoftTehnicaOperator>(stop);
        }

        public Task<string> GetEmailAsync(SoftTehnicaOperator user)
        {

                return Task.FromResult<string>(user.Email);

        }

        public Task<bool> GetEmailConfirmedAsync(SoftTehnicaOperator user)
        {

            return Task.FromResult<bool>(true);

        }

        public Task<string> GetPasswordHashAsync(SoftTehnicaOperator user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(SoftTehnicaOperator user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(SoftTehnicaOperator user, string email)
        {
            user.Email = email;
            return Task.FromResult<object>(null);
        }

        public Task SetEmailConfirmedAsync(SoftTehnicaOperator user, bool confirmed)
        {
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(SoftTehnicaOperator user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(SoftTehnicaOperator user)
        {
            throw new NotImplementedException();
        }
    }
}