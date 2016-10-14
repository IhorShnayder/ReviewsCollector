namespace ReviewsCollector.DataAccess.Migrations
{
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            string roleName = "Administrator";
            string userName = "Admin";
            string userPassword = "password";
            string userEmail = "ihorshnayder@outlook.com";

            var user = userManager.FindByName(userName);

            if (user == null)
            {
                userManager.Create(new ApplicationUser()
                {
                    UserName = userName,
                    Email = userEmail
                }, userPassword);
                user = userManager.FindByName(userName);
            }

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = roleName
                });
            }

            if (!userManager.IsInRole(user.Id, roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }
        }
    }
}
