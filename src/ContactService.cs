using restlessmedia.Module.Contact.Data;
using restlessmedia.Module.Email;
using System;

namespace restlessmedia.Module.Contact
{
  internal sealed class ContactService : IContactService
  {
    public ContactService(IEmailService emailService, IContactDataProvider contactDataProvider, IEmailContext emailContext)
    {
      _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
      _contactDataProvider = contactDataProvider ?? throw new ArgumentNullException(nameof(contactDataProvider));
      _emailContext = emailContext ?? throw new ArgumentNullException(nameof(emailContext));
    }

    public void NewEnquiry(EnquiryEntity enquiry, string emailKey)
    {
      NewEnquiry(enquiry, new EnquiryEmail(_emailContext, enquiry, emailKey));
    }

    public void NewEnquiry(EnquiryEntity enquiry, Email.Email email)
    {
      if (enquiry == null)
      {
        throw new ArgumentNullException(nameof(enquiry));
      }

      _emailService.Send(email);
      SaveEnquiry(enquiry);
    }

    public void SaveContact(ContactEntity contact)
    {
      if (contact == null)
      {
        throw new ArgumentNullException(nameof(contact));
      }

      _contactDataProvider.SaveContact(contact);
    }

    public void SaveEnquiry(EnquiryEntity enquiry)
    {
      if (enquiry == null)
      {
        throw new ArgumentNullException(nameof(enquiry));
      }

      _contactDataProvider.SaveEnquiry(enquiry);
    }

    public ModelCollection<EnquiryEntity> GetEnquiries(EnquiryFlags flags, int year, int month, int day)
    {
      return _contactDataProvider.GetEnquiries(flags, year, month, day);
    }

    public DateTime[] GetDates(EnquiryFlags flags)
    {
      return _contactDataProvider.GetDates(flags);
    }

    private readonly IEmailService _emailService;

    private readonly IContactDataProvider _contactDataProvider;

    private readonly IEmailContext _emailContext;
  }
}