using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace restlessmedia.Module.Contact.UnitTest
{
  [TestClass]
  public class ContactModelTests
  {
    [TestMethod]
    public void DataProtection_sets_ContactFlags()
    {
      new ContactModel
      {
        DataProtection = true,
      }.ContactFlags.HasFlag(ContactFlags.DataProtection).MustBeTrue();

      new ContactModel
      {
        DataProtection = false,
      }.ContactFlags.HasFlag(ContactFlags.DataProtection).MustBeFalse();
    }
  }
}
