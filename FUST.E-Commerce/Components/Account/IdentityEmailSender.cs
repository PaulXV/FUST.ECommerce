using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using FUST.E_Commerce.Data;

namespace FUST.E_Commerce.Components.Account;

// Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
internal sealed class IdentityEmailSender : IEmailSender<ApplicationUser>
{
    private readonly IEmailSender emailSender;

    public IdentityEmailSender(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
        emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
 
    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
 
    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
}
