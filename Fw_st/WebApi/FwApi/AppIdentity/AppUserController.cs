using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using FwCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FwApi.AppIdentity
{
   
    public class AppUserController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public AppUserController(AppIdentityDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("api/AppUser/users")]
        [HttpGet]

        //[Route("users")]
        //[Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            var users = _userManager.Users.ToList();

            var userWithRole = _context.UserRoles.ToList();

            var roles = _roleManager.Roles.ToList();


            var result = from u in users
                         join ur in userWithRole
                         on u.Id equals ur.UserId
                         join r in roles
                         on ur.RoleId equals r.Id into rGroup
                         select new
                         {
                             user = u,
                             role=rGroup
                         };

            return Ok(result);

        }


        [Route("api/AppUser/employees")]
        [HttpGet]
        public IActionResult GetEmp()
        {
            var users = _userManager.Users.ToList();

            var userWithRole = _context.UserRoles.ToList();

            var roles = _roleManager.Roles.ToList();


            var result = from u in users
                         join ur in userWithRole
                         on u.Id equals ur.UserId
                         join r in roles
                         on ur.RoleId equals r.Id
                         where r.Name != "User" 
                         select new
                         {
                             users = u,
                             roles = r
                         };




            return Ok(result);

        }

        [Route("api/AppUser/managers")]
        [HttpGet]
        public IActionResult GetEmp1()
        {
            var users = _userManager.Users.ToList();

            var userWithRole = _context.UserRoles.ToList();

            var roles = _roleManager.Roles.ToList();


            var result = from u in users
                         join ur in userWithRole
                         on u.Id equals ur.UserId
                         join r in roles
                         on ur.RoleId equals r.Id
                         where r.Name == "Manager"
                         select new
                         {
                             users=u,
                             roles=r
                         };
                         
            


            return Ok(result);

        }

        [Route("api/AppUser/admins")]
        [HttpGet]
        public IActionResult GetEmp2()
        {
            var users = _userManager.Users.ToList();

            var userWithRole = _context.UserRoles.ToList();

            var roles = _roleManager.Roles.ToList();


            var result = from u in users
                         join ur in userWithRole
                         on u.Id equals ur.UserId
                         join r in roles
                         on ur.RoleId equals r.Id
                         where r.Name == "Admin"
                         select new
                         {
                             users = u,
                             roles = r
                         };




            return Ok(result);

        }





        [HttpGet]
        [Route("api/AppUser/changeRole")]
        public async Task<IActionResult> Get(string role, string id)
        {
           var user= await _userManager.FindByIdAsync(id);
           var userRole = await _userManager.GetRolesAsync(user);
           await _userManager.RemoveFromRolesAsync(user,userRole);
           var updateRole=await _userManager.AddToRoleAsync(user,role);
            
            return Ok(updateRole);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] UserVM model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, City = model.City, Street = model.Street, Country = model.Country, PostalCode = model.PostalCode};
                var user = _userManager.CreateAsync(newUser, model.Password).Result;
                if (user.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "user");
                }

                return Ok();
            }


            return NoContent();
        }

        [HttpPut("{id}")]
        [Route("update")]
        public async Task<IActionResult> Edit(UserVM updateUser, string id)
        {
            var model = await _userManager.FindByIdAsync(updateUser.Id);
            if (model != null)
            {


                if (User.IsInRole("admin") == true)
                {
                    await _userManager.AddToRolesAsync(model, updateUser.Roles);

                }
                else
                {
                    model.UserName = updateUser.UserName;
                    model.PhoneNumber = updateUser.PhoneNumber;
                    model.Email = updateUser.Email;
                    model.FirstName = updateUser.FirstName;
                    model.LastName = updateUser.LastName;
                    model.PasswordHash = updateUser.Password;
                    model.PhoneNumber = updateUser.PhoneNumber;
                    model.City = updateUser.City;
                    model.Street = updateUser.Street;
                    model.PostalCode = updateUser.PostalCode;
                    model.Country = updateUser.Country;
                    model.PasswordHash = updateUser.Password;
                    model.SecurityStamp = Guid.NewGuid().ToString();

                }


                var Update = await _userManager.UpdateAsync(model);

                return Ok(updateUser);
            }

            return NoContent();
        }


        //Delete User
        [Route("api/AppUser/delete")]
        
        [HttpDelete("{id}")]
        
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);
                var delete = await _userManager.DeleteAsync(user);
               

                return Ok();
            }
            return Ok();
        }

    }//c
}//ns