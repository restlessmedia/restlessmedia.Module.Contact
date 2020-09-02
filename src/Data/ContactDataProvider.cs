using restlessmedia.Module.Data;
using SqlBuilder.DataServices;

namespace restlessmedia.Module.Contact.Data
{
  internal class ContactDataProvider : ContactSqlDataProvider, IContactDataProvider
  {
    public ContactDataProvider(IDataContext context, IModelDataService<DataModel.VContact> contactModelDataService, IModelDataService<DataModel.VEnquiry> enquiryModelDataService)
      : base(context, contactModelDataService, enquiryModelDataService) { }
  }
}