using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace DokumenWebApps.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //!(await _userManager.IsEmailConfirmedAsync(user))
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                    //return Content("Tidak Ditemukan ");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(
                //    Input.Email,
                //    "Reset Password",
                //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                await KirimNotifikasi(HtmlEncoder.Default.Encode(callbackUrl), Input.Email);

                //return Content(Input.Email);
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }

        public async Task KirimNotifikasi(string callbackUrl,string email)
        {
            var apiKey = "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"; //EmailHelpers.SendridAPI;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("admin@yakkum.or.id", "Admin Yakkum");
            List<EmailAddress> tos = new List<EmailAddress>() {
                new EmailAddress{ Email=email},
            };


            var subject = "Reset Password";
            var htmlContent = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
