using Dapper;
using FastMapper;
using restlessmedia.Module.Address;
using restlessmedia.Module.Address.Data;
using restlessmedia.Module.Data;
using restlessmedia.Module.Data.Sql;
using SqlBuilder;
using SqlBuilder.DataServices;
using System;
using System.Data;
using System.Linq;

namespace restlessmedia.Module.Contact.Data
{
  internal class ContactSqlDataProvider : SqlDataProviderBase
  {
    public ContactSqlDataProvider(IDataContext context, IModelDataService<DataModel.VContact> contactModelDataService, IModelDataService<DataModel.VEnquiry> enquiryModelDataService)
      : base(context)
    {
      _contactModelDataService = contactModelDataService ?? throw new ArgumentNullException(nameof(contactModelDataService));
      _enquiryModelDataService = enquiryModelDataService ?? throw new ArgumentNullException(nameof(enquiryModelDataService));
    }

    public void SaveContact(ContactEntity contact)
    {
      if (contact.ContactId.HasValue)
      {
        Update(contact);
      }
      else
      {
        Create(contact);
      }


      // how do we ensure the entity trigger works with the context?

      //DynamicParameters parameters = new DynamicParameters();

      //parameters.AddId("@contactId", contact.ContactId);
      //parameters.Add("@applicationName", DataContext.LicenseSettings.ApplicationName);
      //parameters.Add(contact);

      //Execute("dbo.SPSaveContact", parameters);

      //contact.ContactId = parameters.Get<int>("@contactId");
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
        return new ModelCollection<EnquiryEntity>(connection.Query<EnquiryEntity, AddressEntity, Marker, EnquiryEntity>("dbo.SPGetEnquiries", (e, a, m) =>
        {
          a = a ?? new AddressEntity();
          e.Address = a;
          a.Marker = m;
          return e;
        }, new { flags, year, month, day }, commandType: CommandType.StoredProcedure, splitOn: "AddressId,Latitude"));
      });
    }

    public DateTime[] GetDates(EnquiryFlags flags)
    {
       Select<DataModel.VEnquiry> select = _enquiryModelDataService.DataProvider.NewSelect();

      select
        .OrderBy(x => x.EnquiryDate, false)
        .Where(x => x.EnquiryFlags, flags);
        


      const string sql = "SELECT DISTINCT DATEADD(DAY, DATEDIFF(DAY, 0, EnquiryDate), 0) AS [EnquiryDate] FROM dbo.VEnquiry WHERE EnquiryFlags = @flags ORDER BY EnquiryDate DESC";
      return Query<DateTime>("dbo.SPGetEnquiryDates", new { flags }).ToArray();
    }

    private void Update(ContactEntity contact)
    {
      // do we need to handle context info for the entity trigger?

      DataModel.VContact dataModel = ObjectMapper.Map<ContactEntity, DataModel.VContact>(contact);
      // should we need this for update or be able to disable the changing of a field for an update
      dataModel.ApplicationName = DataContext.LicenseSettings.ApplicationName;
      _contactModelDataService.Update(contact.ContactId, dataModel);
    }

    private void Create(ContactEntity contact)
    {
      // how do we handle context info for the entity trigger?

      DataModel.VContact dataModel = ObjectMapper.Map<ContactEntity, DataModel.VContact>(contact);
      dataModel.ApplicationName = DataContext.LicenseSettings.ApplicationName;
      int? result = _contactModelDataService.Create(dataModel);
      contact.ContactId = result;
    }

    private readonly IModelDataService<DataModel.VContact> _contactModelDataService;

    private readonly IModelDataService<DataModel.VEnquiry> _enquiryModelDataService;
  }
}