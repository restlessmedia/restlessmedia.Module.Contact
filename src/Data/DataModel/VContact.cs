using SqlBuilder;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restlessmedia.Module.Contact.Data.DataModel
{
  [Table("_VContact", Schema = "dbo")]
  public class VContact : DataModel<VContact, ContactEntity>
  {
    [Key]
    public int ContactId { get; set; }

    public int? AddressId { get; set; }

    public string ApplicationName { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Email { get; set; }

    public string ContactNumber { get; set; }

    public string CompanyName { get; set; }

    public string Url { get; set; }

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