using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using QL_Phonghoc.Models;

namespace QL_Phonghoc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private ApplicationSignInManager _signInManager;
        ApplicationDbContext context;
        //
        public LoginController()
        {
            context = new ApplicationDbContext();
        }
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            //ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl, model.UserName);
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Mật khẩu không chính xác.");
                        return View(model);
                }
            }
            ModelState.AddModelError("", "Tài khoản không tồn tại.");
            return View(model);
        }
        private ActionResult RedirectToLocal(string returnUrl, string email)
        {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindByNameAsync(email);
            var s = UserManager.GetRoles(user.Result.Id);
            //if (s[0] == "GiaoVien")
            //    return RedirectToAction("Index", "Lop_Hoc_Phan", new { area = "GV" });
            //if (s[0] == "SinhVien")
            //    return RedirectToAction("Index", "LopHP", new { area = "SV" });
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("XemLichHoc", "tbLich_Hoc");
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
    }
}