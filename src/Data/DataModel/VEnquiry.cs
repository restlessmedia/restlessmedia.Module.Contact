using SqlBuilder;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace restlessmedia.Module.Contact.Data.DataModel
{
  [Table("_VEnquiry", Schema = "dbo")]
  public class VEnquiry  : DataModel<VEnquiry, ContactEntity>
  {
    public int? EnquiryId { get; set; }

    public int? CategoryId { get; set; }

    public DateTime EnquiryDate { get; set; }

    public EnquiryFlags EnquiryFlags { get; set; }

    public string Comments { get; set; }

    [ReadOnly(true)]
    public int ContactId { get; set; }

    [ReadOnly(true)]
    public int? AddressId { get; set; }

    [ReadOnly(true)]
    public string ApplicationName { get; set; }

    [ReadOnly(true)]
    public string UserName { get; set; }

    [ReadOnly(true)]
    public string FirstName { get; set; }

    [ReadOnly(true)]
    public string Surname { get; set; }

    [ReadOnly(true)]
    public DateTime CreatedDate { get; set; }

    [ReadOnly(true)]
    public string Email { get; set; }

    [ReadOnly(true)]
    public string ContactNumber { get; set; }

    [ReadOnly(true)]
    public string CompanyName { get; set; }

    [ReadOnly(true)]
    public string Url { get; set; }

    [ReadOnly(true)]
    public byte? ContactFlags { get; set; }

    [ReadOnly(true)]
    public string NameNumber { get; set; }

    [ReadOnly(true)]
    public string Address01 { get; set; }

    [ReadOnly(true)]
    public string Address02 { get; set; }

    [ReadOnly(true)]
    public string City { get; set; }

    [ReadOnly(true)]
    public string CountryCode { get; set; }

    [ReadOnly(true)]
    public double? Latitude { get; set; }

    [ReadOnly(true)]
    public double? Longitude { get; set; }

    [ReadOnly(true)]
    public string PostCode { get; set; }

    [ReadOnly(true)]
    public string Town { get; set; }

    [ReadOnly(true)]
    public int? EntityGuid { get; set; }

    [ReadOnly(true)]
    public int? LicenseId { get; set; }
  }
}
