using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using QL_Phonghoc.Models;

[assembly: OwinStartupAttribute(typeof(QL_Phonghoc.Startup))]
namespace QL_Phonghoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
 


            // creating Creating Manager role    
            if (!roleManager.RoleExists("CanBo"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "CanBo";
                roleManager.Create(role);
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("SinhVien"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SinhVien";
                roleManager.Create(role);
            }
            var chkUser = UserManager.FindByName("Admin");

            //Add default User to Role Admin
            if (chkUser != null)
            {
                var result1 = UserManager.AddToRole(chkUser.Id, "CanBo");

            }

            var chkUser1 = UserManager.FindByName("Admin");
            if (chkUser1 != null)
            {
                var result1 = UserManager.AddToRole(chkUser1.Id, "SinhVien");

            }

        }
    }
}
