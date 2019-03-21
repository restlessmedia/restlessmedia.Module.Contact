using restlessmedia.Module.Data;

namespace restlessmedia.Module.Contact.Data
{
  internal class ContactDataProvider : ContactSqlDataProvider, IContactDataProvider
  {
    public ContactDataProvider(IDataContext context)
      : base(context) { }
  }
}