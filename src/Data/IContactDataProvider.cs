using restlessmedia.Module.Data;
using System;

namespace restlessmedia.Module.Contact.Data
{
  public interface IContactDataProvider : IDataProvider
  {
    void SaveContact(ContactEntity contact);

    void SaveEnquiry(EnquiryEntity enquiry);

    ModelCollection<EnquiryEntity> GetEnquiries(EnquiryFlags flags, int year, int month, int day);

    DateTime[] GetDates(EnquiryFlags flags);
  }
}