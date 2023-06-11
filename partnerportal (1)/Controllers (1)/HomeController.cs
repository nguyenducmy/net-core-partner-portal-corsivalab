using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using partnerportal.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;
using Xamarin.Forms.Internals;
using partnerportal.Service;

namespace partnerportal.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly UserManager<ClmPartner> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, 
            UserManager<ClmPartner> userManager, IEmailService emailService)
        {
            _env = env;
            _logger = logger;
            _userManager = userManager;
            _emailService = emailService;

        }

        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions();
            
            var Role = TempData["UserRole"];
            try
            {
                Response.Cookies.Append("UserRole", Role.ToString(), options);
            }
            catch(Exception e)
            {
                ViewBag.UserRole = Request.Cookies["UserRole"];
                return View();

            }
            ViewBag.UserRole = Request.Cookies["UserRole"];
            return View();
        }

        [HttpGet]
        public IActionResult PartnerInfomation()
        {

            var username = TempData["Username"];
            var password = TempData["Password"];

            ClmPartner partnerInfo = new ClmPartner();
            var context = new toolkittpmpsandboxContext();
            List<ClmPartner> partners = context.ClmPartner.ToList();
            bool isPartner = false;
            foreach (ClmPartner partner in partners)
            {
                if (partner.NormalizedUserName.Equals(username) && partner.PasswordHash.Equals(password))
                {
                    partnerInfo.UserName = partner.NormalizedUserName;
                    partnerInfo.Email = partner.Email;
                    partnerInfo.PhoneNumber = partner.PhoneNumber;
                    partnerInfo.Remarks = partner.Remarks;
                    partnerInfo.SoftDelete = partner.SoftDelete;
                    isPartner = true;
                }
            }
            string usernameCookie = partnerInfo.UserName;
            string emailCookie = partnerInfo.Email;
            string phoneCookie = partnerInfo.PhoneNumber;
            string remarksCookie = partnerInfo.Remarks;

            // create cookies
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            try
            {
                Response.Cookies.Append("UsernameCookie", usernameCookie, options);
                Response.Cookies.Append("EmailCookie", emailCookie, options);
                Response.Cookies.Append("PhoneCookie", phoneCookie, options);
                Response.Cookies.Append("RemarksCookie", remarksCookie, options);
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine("Refreshpage");
            }
            // use cookies to show info prevent miss data after refresh page
            if (username != null)
            {
                ViewBag.Username = partnerInfo.UserName;
                ViewBag.Email = partnerInfo.Email;
                ViewBag.Phone = partnerInfo.PhoneNumber;
                ViewBag.Remarks = partnerInfo.Remarks;
                if (!partners.Select(i => i.PasswordHash).Contains(password))
                {
                    Response.Cookies.Delete("UsernameCookie");
                    Response.Cookies.Delete("EmailCookie");
                    Response.Cookies.Delete("PhoneCookie");
                    Response.Cookies.Delete("RemarksCookie");

                }
            }
            else
            {

                ViewBag.Username = Request.Cookies["UsernameCookie"];
                ViewBag.Email = Request.Cookies["EmailCookie"];
                ViewBag.Phone = Request.Cookies["PhoneCookie"];
                ViewBag.Remarks = Request.Cookies["RemarksCookie"];
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignAgreementRepo()
        {

            return View();
        }
        // show SignAgreementRepo
        [HttpGet]
        public IActionResult ShowSignAgreementRepo()
        {

            ViewBag.File = TempData["SignAgreementRepo"];

            return View();
        }
        // read file and store in server folder
        [HttpPost]
        public async Task<IActionResult> SignAgreementRepoAction(IFormFile file, int TypeOfAgreement, bool SoftDelete)
        {
            TypeOfAgreement = (int)TypeOfAgreement;
            // read file 
            System.Diagnostics.Debug.WriteLine("file" + file);
            System.Diagnostics.Debug.WriteLine("Type" + TypeOfAgreement);

            DateTime DateOfAgreement = DateTime.Now;
            string sqlDateOfAgreement = DateOfAgreement.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            // 
            string id = null;
            var context = new toolkittpmpsandboxContext();
            ClmPartnerSignedAgreements clmPartnerSignedAgreements = new ClmPartnerSignedAgreements();
            List<ClmPartner> clmParners = context.ClmPartner.ToList();

            // verify partner id 
            var username = TempData["Username"];
            var password = TempData["Password"];
            foreach (ClmPartner clmPartner in clmParners)
            {
                if (clmPartner.UserName.Equals(username) && clmPartner.PasswordHash.Equals(password))
                {
                    id = clmPartner.Id;
                }
            }

            if (file.Length != null)
            {
                string folder = "SignAgreementRepo/";
                folder += Guid.NewGuid().ToString() + "_" + file.FileName;
                string serverfolder = Path.Combine(_env.WebRootPath, folder);
                // copy to server folder
                await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                // generate SignedAgreementsURL and set clmPartnerSignedAgreements
                clmPartnerSignedAgreements.FkPartnerId = id;
                clmPartnerSignedAgreements.SignedAgreementsURL = "/" + folder;
                clmPartnerSignedAgreements.TypeOfAgreement = TypeOfAgreement;
                clmPartnerSignedAgreements.DateOfAgreement = DateOfAgreement;
                clmPartnerSignedAgreements.SoftDelete = SoftDelete;

                context.ClmPartnerSignedAgreements.Add(clmPartnerSignedAgreements);
                var result = context.SaveChangesAsync();
            }

            TempData["SignAgreementRepo"] = clmPartnerSignedAgreements.SignedAgreementsURL;
            return RedirectToAction("ShowSignAgreementRepo", "Home");
        }
        // Staff send Leads out by add Lead into Leads from corsiva
        [HttpGet]
        public IActionResult LeadFromCorsiva()
        {
            // get partner list
            var context = new toolkittpmpsandboxContext();
            
            string[] partnerList;

            List<string> partnerArrayList = new List<string>();

            List<ClmPartner> clmPartners = context.ClmPartner.ToList();
            
            foreach (ClmPartner i in clmPartners)
            {
                partnerArrayList.Add(i.UserName);
            }

            partnerList = partnerArrayList.ToArray();

            ViewBag.SuccessfullyAddLeads = TempData["SuccessfullyAddLeads"];
            ViewBag.PartnerList = partnerList;
            ViewBag.UserRole = TempData["UserRole"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LeadFromCorsivaAction(string CustomerName, string CustomerEmail, string CustomerPhone, string AdditionalRemarks,
                                                    DateTime DateAdded, string Remarks, string ServiceRequired, string selectPartner)
        {
            var context = new toolkittpmpsandboxContext();
            ClmLeadsFromCorsiva clmLeadsFromCorsiva = new ClmLeadsFromCorsiva();
            clmLeadsFromCorsiva.CustomerName = CustomerName;
            clmLeadsFromCorsiva.CustomerEmail = CustomerEmail;
            clmLeadsFromCorsiva.CustomerPhone = CustomerPhone;
            clmLeadsFromCorsiva.AdditionalRemarks = AdditionalRemarks;
            clmLeadsFromCorsiva.DateAdded = DateAdded;
            clmLeadsFromCorsiva.Remarks = Remarks;
            clmLeadsFromCorsiva.ServiceRequired = ServiceRequired;

            context.ClmLeadsFromCorsiva.Add(clmLeadsFromCorsiva);
            var result = context.SaveChangesAsync();
            try
            {
                if (result != null)
                {
                    string EmailBody = "<a>Dear Partner,</a><br/><br/>";
                    EmailBody += "<a>Leads with this Email Address has been added into Leads From Corsiva Lab Successfully.</a><br/><br/>";
                    EmailBody += "<a>Thanks,</a><br/><br/>";
                    EmailBody += "<a>Corsiva Lab Teams</a><br/><br/>";
                    await _emailService.SendEmail(selectPartner, EmailBody, "Staff Add Leads into Leads From Corsiva Lab Succfully.");
                }
            }
            catch (Exception e)
            {
                TempData["SuccessfullyAddLeads"] = "Add Leads Not Successfully !";
                return RedirectToAction("LeadFromCorsiva", "Home", TempData["SuccessfullyAddLeads"]);
            }
            TempData["SuccessfullyAddLeads"] = "Add Leads Successfully !";

            return RedirectToAction("LeadFromCorsiva", "Home", TempData["SuccessfullyAddLeads"]);
        }

        // Staff upload latest brochure to show or show the available one
        [HttpGet]
        public IActionResult SolutionBrochures()
        {    //get the latest brochure by latest date and show
            var context = new toolkittpmpsandboxContext();
            List<ClmSolutionBrochures> clmSolutionBrochures = context.ClmSolutionBrochures.ToList();
            string isSelected = null;
            string[] brochureList;
            List<string> brochureArrayList = new List<string>();
            ViewBag.BrochureList = clmSolutionBrochures.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult ShowSelectedSolutionBrochures()
        {
            ViewBag.File = TempData["SolutionBrochureUrlSelected"].ToString();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SelectedSolutionBrochureAction(string id, string idstaff)
        {/*
            int intValue = int.Parse(id);
            intValue += 1;*/
            var context = new toolkittpmpsandboxContext();
            List<ClmSolutionBrochures> clmSolutionBrochures = context.ClmSolutionBrochures.ToList();
            try
            {
                foreach (ClmSolutionBrochures o in clmSolutionBrochures)
                {
                    if (idstaff.Equals(o.Id))
                    {
                        TempData["SolutionBrochureUrlSelected"] = o.BrochureURL;
                    }
                }
            }catch(Exception e)
            {
                e.ToString();
            }
            return RedirectToAction("ShowSelectedSolutionBrochures", "Home", TempData["SolutionBrochureUrlSelected"]);
        }

        [HttpGet]
        public IActionResult UploadSolutionBrochures()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadSolutionBrochuresAction(IFormFile file, string TitleOfBrochure, int TypeOfBrochure, double VersionNumber, bool SoftDelete)
        {
            //Upload SolutionBrochures into database and return file to action SolutionBrochures
            TypeOfBrochure = (int)TypeOfBrochure;

            DateTime DateOfBrochure = DateTime.Now;
            string sqlDateOfBrochure = DateOfBrochure.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            var context = new toolkittpmpsandboxContext();
            ClmSolutionBrochures clmSolutionBrochures = new ClmSolutionBrochures();

            // read file 
            if (file.Length != null)
            {
                string folder = "Solution Brochures/";
                folder += Guid.NewGuid().ToString() + "_" + file.FileName;
                string serverfolder = Path.Combine(_env.WebRootPath, folder);
                // copy to server folder
                await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                // generate SignedAgreementsURL and set clmPartnerSignedAgreements

                clmSolutionBrochures.BrochureURL = "/" + folder;

                clmSolutionBrochures.TitleOfBrochure = TitleOfBrochure;
                clmSolutionBrochures.TypeOfBrochure = TypeOfBrochure;
                clmSolutionBrochures.VersionNumber = VersionNumber;
                clmSolutionBrochures.DateOfBrochure = DateOfBrochure;
                clmSolutionBrochures.SoftDelete = SoftDelete;

                context.ClmSolutionBrochures.Add(clmSolutionBrochures);
                var result = context.SaveChangesAsync();
            }
            TempData["SolutionBrochuresURL"] = clmSolutionBrochures.BrochureURL;

            return RedirectToAction("SolutionBrochures", "Home");
        }
        [HttpGet]
        public IActionResult UpdateLeadStatus()
        {

            ViewBag.UpdateStatus = TempData["messUpdate"];
            return View();
        }
        // update Leads status from Leads From Corsiva tab
        [HttpPost]
        public async Task<IActionResult> UpdateLeadStatusAction(string LeadEmail, string StatusCode, string Message)
        {
            var context = new toolkittpmpsandboxContext();
            List<ClmLeadsFromCorsiva> clmLeadsFromCorsivas = context.ClmLeadsFromCorsiva.ToList();
            ClmLeadsStatusLogsToCorsiva clmLeadsStatusLogsToCorsiva = new ClmLeadsStatusLogsToCorsiva();
            DateTime DateTimeOfChange = DateTime.Now;
            var isUpdate = false;
            foreach (ClmLeadsFromCorsiva i in clmLeadsFromCorsivas)
            {
                
                if (LeadEmail.Equals(i.CustomerEmail))
                {
                    clmLeadsStatusLogsToCorsiva.DateTimeOfChange = DateTimeOfChange;
                    clmLeadsStatusLogsToCorsiva.FkLeadsId = i.Id;
                    clmLeadsStatusLogsToCorsiva.StatusCode = StatusCode;
                    clmLeadsStatusLogsToCorsiva.Message = Message;
                    //Update into database
                    context.ClmLeadsStatusLogsToCorsiva.Add(clmLeadsStatusLogsToCorsiva);
                    var result = context.SaveChangesAsync();
                    isUpdate = true;
                }
               
            }
            if(isUpdate == true)
            {

                var messUpdate = "Update Status Successfully";
                TempData["messUpdate"] = messUpdate;
                
                return RedirectToAction("UpdateLeadStatus", "Home", TempData["messUpdate"]);
            }
             else
            {
                var messUpdate = "Leads Not Found";
                TempData["messUpdate"] = messUpdate;
                return RedirectToAction("UpdateLeadStatus", "Home", TempData["messUpdate"]);
            }

            return RedirectToAction("UpdateLeadStatus", "Home");
        }
        // Staff upload Leads to Corsiva Lab
        [HttpGet]
        public IActionResult LeadsToCorsiva()
        {
            ViewBag.SuccessfullyAddLeadsToCorsiva = TempData["SuccessfullyAddLeadsToCorsiva"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LeadsToCorsivaAction(string CustomerName, string CustomerEmail, string CustomerPhone, string AdditionalRemarks, DateTime DateAdded, string Remarks, string ServiceRequired)
        {
            string userTemp = TempData["Username"].ToString();
            var user = await _userManager.FindByNameAsync(userTemp);

            var context = new toolkittpmpsandboxContext();
            ClmLeadsToCorsiva clmLeadsToCorsiva = new ClmLeadsToCorsiva();
            clmLeadsToCorsiva.CustomerName = CustomerName;
            clmLeadsToCorsiva.CustomerEmail = CustomerEmail;
            clmLeadsToCorsiva.CustomerPhone = CustomerPhone;
            clmLeadsToCorsiva.AdditionalRemarks = AdditionalRemarks;
            clmLeadsToCorsiva.DateAdded = DateAdded;
            clmLeadsToCorsiva.Remarks = Remarks;
            clmLeadsToCorsiva.ServiceRequired = ServiceRequired;
            clmLeadsToCorsiva.FkCorsivaStaffId = user.Id;

            context.ClmLeadsToCorsiva.Add(clmLeadsToCorsiva);
            var result = context.SaveChangesAsync();
            
            TempData["SuccessfullyAddLeadsToCorsiva"] = "Add Leads Successfully !";
            return RedirectToAction("LeadsToCorsiva", "Home", TempData["SuccessfullyAddLeadsToCorsiva"]);
        }
    }
}
