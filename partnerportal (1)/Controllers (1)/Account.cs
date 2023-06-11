using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partnerportal.Models;
using partnerportal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace partnerportal.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<ClmPartner> _userManager;
        private readonly IEmailService _emailService;
        public Account(UserManager<ClmPartner> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            // display error message in login page in case Other controller login failed and redirect to Login included error message
            ViewBag.message = TempData["message"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(string username, string password)
        {
            var Url = "https://toolkit.corsivalab.com/token";
            var accessToken = string.Empty;
            var message = (Object)null;
            try
            {
                var keyValuePairs = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("email", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),

                };
                var request = new HttpRequestMessage(HttpMethod.Post, Url);
            
                request.Content = new FormUrlEncodedContent(keyValuePairs);
     
                
                var client = new HttpClient();
                // response the access_token : then check for login
                var response = client.SendAsync(request).Result;

                using(HttpContent content = response.Content)
                {
                    // connect toolkit api by accesstoken in order corsiva lab can login by toolkit account
                    var json = content.ReadAsStringAsync();
                    JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(json.Result);
                    var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
                    accessToken = jwtDynamic.Value<string>("access_token");
                  
                    var AccessTokenExpirationDate = accessTokenExpiration;
                   
                    //Hash User Password before store in database
                    var bytes = new System.Text.UTF8Encoding().GetBytes(password);
                    var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
                    var staffPassword = Convert.ToBase64String(hashBytes);

                    // create TempData so others controller can call username, and hash password(staffPassword) value from login
                    // in order to find user by login info
                    TempData["Username"] = username;
                    TempData["Password"] = staffPassword;
                    var context = new toolkittpmpsandboxContext();


                    var user = await _userManager.FindByNameAsync(username);
                    //User is corsivalab staff then login by staff account
                    if (response.IsSuccessStatusCode)
                    {
                         TempData["UserRole"] = "Staff";
                         return RedirectToAction("Index", "Home", TempData["UserRole"]);
                    }
                    // else login by partner account
                    else if (!response.IsSuccessStatusCode && user != null)
                    {
                        if (user.NormalizedUserName.Equals(username) && user.PasswordHash.Equals(staffPassword))
                        {
                            TempData["UserRole"] = "Partner";
                            return RedirectToAction("Index", "Home", TempData["UserRole"]);
                        }
                        
                    }
                    else
                    {
                        message = "Login Failed – Incorrect username & password";
                        TempData["message"] = message;
                        return RedirectToAction("Login", "Account", TempData["message"]);
                    }
                   
                }    
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Login not success exception..........");
            }
            message = "Login Failed – Incorrect username & password";
            TempData["message"] = message;
            return RedirectToAction("Login", "Account", TempData["message"]);
        }

       

        /*Change new password*/

        [HttpGet]
        public IActionResult ChangeNewPassword()
        { 
            ViewBag.messageChangeNewPassword = TempData["messageChangeNewPassword"];
            return View();
        }

        [HttpPost]
        public IActionResult ChangeNewPasswordAction(string newPassword, string reTypeNewPassword)
        {
            var userNameLogin = TempData["Username"];
            var passwordLogin = TempData["Password"];

            var userNewPassword = newPassword;
            if (newPassword.Equals(reTypeNewPassword))
            {
                userNewPassword = newPassword;
            }
            else
            {
                var messageChangeNewPassword = "New Password Not Confirmed Correctly";
                TempData["messageChangeNewPassword"] = messageChangeNewPassword;
                return RedirectToAction("ChangeNewPassword", "Account", TempData["messageChangeNewPassword"]);
            }
            


            //Hash New Password
            var Newbytes = new System.Text.UTF8Encoding().GetBytes(userNewPassword);
            var NewhashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(Newbytes);
            var staffNewPassword = Convert.ToBase64String(NewhashBytes);

            var context = new toolkittpmpsandboxContext();

            List<ClmPartner> clmParners = context.ClmPartner.ToList();
            foreach (ClmPartner clmPartner in clmParners)
            {
                if (clmPartner.NormalizedUserName.Equals(userNameLogin) && clmPartner.PasswordHash.Equals(passwordLogin))
                {
                    // change password and update data into database by Update and SaveChangeAsync methods
                    clmPartner.PasswordHash = staffNewPassword;
                    context.ClmPartner.Update(clmPartner);
                    var result = context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Login", "Account");
        }

        /*End Change Password*/
        
        /*Register Partner*/
        [HttpGet]
        public IActionResult RegisterPartner()
        {
            ViewBag.message = TempData["RegisterMessage"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAction(string Username, string Password, string Email, 
                                                        string Phone, string Remarks, bool SoftDelete)
        {
          
            //Hash User Password before store in database
            var bytes = new System.Text.UTF8Encoding().GetBytes(Password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            var staffPassword = Convert.ToBase64String(hashBytes);

            string message = null;

            var existUser = await _userManager.FindByNameAsync(Username);
            // check if the staff already registed the with the username
            if (existUser != null)
            {
                message = "Account Already Registed";
                TempData["RegisterMessage"] = message;
                return RedirectToAction("RegisterPartner", "Account",TempData["RegisterMessage"]);
            }


            ClmPartner clmPartner = new ClmPartner();
            
            clmPartner.UserName = Username;
            clmPartner.NormalizedUserName = Username;
            clmPartner.PasswordHash = staffPassword;

            clmPartner.Email = Email;
            clmPartner.NormalizedEmail = Email;
            clmPartner.PhoneNumber = Phone;
            clmPartner.Remarks = Remarks;
            clmPartner.SoftDelete = SoftDelete;

            var context = new toolkittpmpsandboxContext();

            // Add clmPartner Obj into database
            await context.ClmPartner.AddAsync(clmPartner);
            var result = await context.SaveChangesAsync();
           
            if (result== null)
            {
                message = "Register not success, Please enter required input again";
                TempData["RegisterMessage"] = message;
                return RedirectToAction("RegisterPartner", "Account", TempData["RegisterMessage"]);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("RegisterPartner", "Account");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.message = TempData["mess"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPasswordAction(string currentEmail)
        {

            var user = await _userManager.FindByEmailAsync(currentEmail);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callback = Url.Action(nameof(ResetPassword), "Account", new { token, user.Email }, Request.Scheme);
                string EmailBody = "<a>Dear User,</a><br/><br/>";
                EmailBody += "<a>Please Click On link to reset your password.</a><br/><br/>";
                EmailBody += "<a>Thanks,</a><br/><br/>";
                EmailBody += "<a>Corsiva Lab Teams</a><br/><br/>";
                await _emailService.SendEmail(user.Email, EmailBody+callback, "Reset Password token");
            }
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
/*
            return RedirectToAction("ForgotPassword", "Account", TempData["mess"]);*/
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        static ClmResetPasswordModel model;
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            ViewBag.MessageReset = TempData["MessageReset"];
            if (string.IsNullOrEmpty(token) && string.IsNullOrEmpty(email))
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                model = new ClmResetPasswordModel()
                {
                    Token = token,
                    Email = email
                };
                
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordAction(ClmResetPasswordModel clmResetPasswordModel)
        {
           /* if (!ModelState.IsValid) return View(resetPasswordModel);*/

            var user = await _userManager.FindByEmailAsync(model.Email);

            var context = new toolkittpmpsandboxContext();
            //create new password
            var Newbytes = new System.Text.UTF8Encoding().GetBytes(clmResetPasswordModel.Password);
            var NewhashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(Newbytes);
            var staffNewPassword = Convert.ToBase64String(NewhashBytes);

            user.PasswordHash = staffNewPassword;
            context.ClmPartner.Update(user);
            var result = await context.SaveChangesAsync().ConfigureAwait(false);
            if (result != null)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            else
            {
                var message = "Reset Password Failed. Please try again";
                TempData["MessageReset"] = message;
                return RedirectToAction("ResetPassword", "Account", TempData["MessageReset"]);
            }   

        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }

        
}
