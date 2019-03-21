using Dapper;
using restlessmedia.Module.Address;
using restlessmedia.Module.Address.Data;
using restlessmedia.Module.Data;
using restlessmedia.Module.Data.Sql;
using System;
using System.Data;
using System.Linq;

namespace restlessmedia.Module.Contact.Data
{
  internal class ContactSqlDataProvider : SqlDataProviderBase
  {
    public ContactSqlDataProvider(IDataContext context)
      : base(context) { }

    public void SaveContact(ContactEntity contact)
    {
      DynamicParameters parameters = new DynamicParameters();

      parameters.AddId("@contactId", contact.ContactId);
      parameters.Add("@applicationName", DataContext.LicenseSettings.ApplicationName);
      parameters.Add(contact);

      Execute("dbo.SPSaveContact", parameters);

      contact.ContactId = parameters.Get<int>("@contactId");
    }

    public void SaveEnquiry(EnquiryEntity enquiry)
    {
      DynamicParameters parameters = new DynamicParameters();

      parameters.AddId("@contactId", enquiry.ContactId);
      parameters.Add("@applicationName", DataContext.LicenseSettings.ApplicationName);
      parameters.Add(enquiry);
      parameters.Add(enquiry.Address);
      parameters.Add("@categoryId", enquiry.CategoryId);
      parameters.Add("@enquiryFlags", enquiry.EnquiryFlags);
      parameters.Add("@comments", enquiry.Comments);

      Execute("dbo.SPSaveEnquiry", parameters);

      enquiry.ContactId = parameters.Get<int>("@contactId");
    }

    public ModelCollection<EnquiryEntity> GetEnquiries(EnquiryFlags flags, int year, int month, int day)
    {
      return Query((connection) =>
      {
        return new ModelCollection<EnquiryEntity>(connection.Query<EnquiryEntity, AddressEntity, Marker, EnquiryEntity>("dbo.SPGetEnquiries", (e, a, m) => {
          a = a ?? new AddressEntity();
          e.Address = a;
          a.Marker = m;
          return e;
        }, new { flags, year, month, day }, commandType: CommandType.StoredProcedure, splitOn: "AddressId,Latitude"));
      });
    }

    public DateTime[] GetDates(EnquiryFlags flags)
    {
      return Query<DateTime>("dbo.SPGetEnquiryDates", new { flags }).ToArray();
    }
  }
}
