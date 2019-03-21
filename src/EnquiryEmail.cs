using restlessmedia.Module.Configuration;
using restlessmedia.Module.Email;

namespace restlessmedia.Module.Contact
{
  public class EnquiryEmail : TemplateEmail<EnquiryEntity>
  {
    public EnquiryEmail(IEmailContext emailContext, EnquiryEntity enquiry, string to, string subject)
      : base(_resource, emailContext.EmailSettings.FromEmail, to, subject)
    {
      Model = enquiry;
    }

    public EnquiryEmail(IEmailContext emailContext, EnquiryEntity enquiry, string emailKey)
      : this(emailContext, enquiry, emailContext.EmailSettings.GetAddress(emailKey).EmailAddress, GetSubject(emailContext.LicenseSettings)) { }

    public override EnquiryEntity Model { get; set; }

    private const string _resource = "Enquiry";

    private static string GetSubject(ILicenseSettings licenseSettings)
    {
      return string.Concat(licenseSettings.CompanyName, ": enquiry");
    }
  }
}