using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using DATA;

namespace Manager.CustomUserStore
{
    public class SoftTehnicaUserStore : 
        IUserStore<SoftTehnicaUser, int>, 
        IUserPasswordStore<SoftTehnicaUser,int>,
        IUserRoleStore<SoftTehnicaUser, int>,
        IUserEmailStore<SoftTehnicaUser, int>,
        IUserLockoutStore<SoftTehnicaUser, int>,
        IUserTwoFactorStore<SoftTehnicaUser, int>
    {
        private DATA.softtehnicaEntities Repository = new DATA.softtehnicaEntities();

        public Task AddToRoleAsync(SoftTehnicaUser user, string roleName)
        {
            var dbUser = Repository.users.FirstOrDefault(u => u.id == user.Id);
            role dbRole = null;
            switch(roleName)
            {
                case "Management":
                    dbRole = Repository.roles.First(r => r.role_name == roleName);
                    break;
                case "Operator":
                    dbRole = Repository.roles.First(r => r.role_name == roleName);
                    break;
            }
            dbUser.role = dbRole;
            Repository.SaveChanges();
            // throw new NotImplementedException();
            return Task.FromResult<object>(null);
        }

        public Task CreateAsync(SoftTehnicaUser user)
        {
            var newUser = Mapper.Map<DATA.user>(user);
            newUser.role = Repository.roles.Where(r => r.role_name == "Management").First();
            newUser.name = "not implemented yet";
            newUser.password = user.PasswordHash;
            Repository.users.Add(newUser);
            Repository.SaveChanges();
            user.Id = newUser.id;

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(SoftTehnicaUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        { 
            //throw new NotImplementedException();
        }

        public Task<SoftTehnicaUser> FindByEmailAsync(string email)
        {
            var dbUser = Repository.users.Where(u => u.email == email).FirstOrDefault();
            SoftTehnicaUser stu = null;
            if (dbUser != null)
                stu = Mapper.Map<SoftTehnicaUser>(dbUser);
            
            return Task.FromResult<SoftTehnicaUser>(stu);
        }

        public Task<SoftTehnicaUser> FindByIdAsync(int userId)
        {
            var dbUser = Repository.users.Where(u => u.id == userId).FirstOrDefault();
            SoftTehnicaUser stu = null;
            if (dbUser != null)
                stu = Mapper.Map<SoftTehnicaUser>(dbUser);

            return Task.FromResult<SoftTehnicaUser>(stu);
        }

        public Task<SoftTehnicaUser> FindByNameAsync(string userName)
        {
            var dbUser = Repository.users.Where(u => u.username == userName).FirstOrDefault();
            SoftTehnicaUser stu = null;
            if (dbUser != null)
                stu = Mapper.Map<SoftTehnicaUser>(dbUser);

            return Task.FromResult<SoftTehnicaUser>(stu);
        }

        public Task<int> GetAccessFailedCountAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<int>(0);
        }

        public Task<string> GetEmailAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<string>(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> GetLockoutEnabledAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(SoftTehnicaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(SoftTehnicaUser user)
        {
            var passowrdHash = "";
            var dbUser = Repository.users.FirstOrDefault(u=>u.id == user.Id);
            if(dbUser != null)
            {
                passowrdHash = dbUser.password;
            }
            return Task.FromResult<string>(passowrdHash);
        }

        public Task<IList<string>> GetRolesAsync(SoftTehnicaUser user)
        {
            var role = Repository.users.Where(u => u.id == user.Id).FirstOrDefault().role;

            var RoleList = new List<string>();
            RoleList.Add(role.role_name);
            return Task.FromResult<IList<string>>(RoleList);
        }

        public Task<bool> GetTwoFactorEnabledAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task<bool> HasPasswordAsync(SoftTehnicaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(SoftTehnicaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(SoftTehnicaUser user, string roleName)
        {
            bool isInRole = false;

            if(Repository.users.Where(u => u.id == user.Id).FirstOrDefault().role.role_name == roleName)
            { 
                isInRole = true;
            }

            return Task.FromResult<bool>(isInRole);
        }

        public Task RemoveFromRoleAsync(SoftTehnicaUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(SoftTehnicaUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(SoftTehnicaUser user, string email)
        {
            user.Email = email;
            return Task.FromResult<object>(null);
        }

        public Task SetEmailConfirmedAsync(SoftTehnicaUser user, bool confirmed)
        {
            return Task.FromResult<object>(null);
        }

        public Task SetLockoutEnabledAsync(SoftTehnicaUser user, bool enabled)
        {
            return Task.FromResult<object>(null);
        }

        public Task SetLockoutEndDateAsync(SoftTehnicaUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(SoftTehnicaUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task SetTwoFactorEnabledAsync(SoftTehnicaUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SoftTehnicaUser user)
        {
            return Task.FromResult<object>(null);
        }
    }
}