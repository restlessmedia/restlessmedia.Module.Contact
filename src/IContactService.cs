using System;

namespace restlessmedia.Module.Contact
{
  public interface IContactService : IService
  {
    void NewEnquiry(EnquiryEntity enquiry, string emailKey);

    void NewEnquiry(EnquiryEntity enquiry, Email.Email email);

    void SaveContact(ContactEntity contact);

    void SaveEnquiry(EnquiryEntity enquiry);

    ModelCollection<EnquiryEntity> GetEnquiries(EnquiryFlags flags, int year, int month, int day);

    DateTime[] GetDates(EnquiryFlags flags);
  }
}