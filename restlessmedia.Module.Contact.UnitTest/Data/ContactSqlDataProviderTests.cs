using System;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using restlessmedia.Module.Contact.Data;
using restlessmedia.Module.Contact.Data.DataModel;
using restlessmedia.Module.Data;
using SqlBuilder;
using SqlBuilder.DataServices;
using Xunit;

namespace restlessmedia.Module.Contact.UnitTest.Data
{
  public class ContactSqlDataProviderTests
  {
    [Fact]
    public void TestMethod1()
    {
      ContactSqlDataProvider dataProvider = CreateInstance(out IModelDataService<VContact> contactModelDataService, out IModelDataService<VEnquiry> enquiryModelDataService);
      ContactEntity contactEntity = new ContactEntity();
      dataProvider.SaveContact(contactEntity);
    }

    private ContactSqlDataProvider CreateInstance(out IModelDataService<VContact> contactModelDataService, out IModelDataService<VEnquiry> enquiryModelDataService)
    {
      IDataContext dataContext = A.Fake<IDataContext>();
      contactModelDataService = A.Fake<IModelDataService<VContact>>();
      enquiryModelDataService = A.Fake<IModelDataService<VEnquiry>>();
      return new ContactSqlDataProvider(dataContext, contactModelDataService, enquiryModelDataService);
    }
  }
}