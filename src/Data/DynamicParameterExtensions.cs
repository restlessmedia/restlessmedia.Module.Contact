using Dapper;

namespace restlessmedia.Module.Contact
{
  public static class DynamicParameterExtensions
  {
    public static void Add(this DynamicParameters parameters, ContactEntity contact)
    {
      parameters.Add("userName", contact.Username);
      parameters.Add("firstName", contact.FirstName);
      parameters.Add("surname", contact.Surname);
      parameters.Add("email", contact.Email);
      parameters.Add("contactNumber", contact.ContactNumber);
      parameters.Add("companyName", contact.CompanyName);
      parameters.Add("url", contact.Url);
      parameters.Add("contactFlags", (byte)contact.ContactFlags);
    }
  }
}