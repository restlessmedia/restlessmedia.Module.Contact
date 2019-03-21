using restlessmedia.Module.Address;
using System;
using System.Linq;

namespace restlessmedia.Module.Contact
{
  public class EnquiryEntity : ContactEntity
  {
    public EnquiryEntity() { }

    public override EntityType EntityType
    {
      get
      {
        return EntityType.Enqiury;
      }
    }

    public override int? EntityId
    {
      get
      {
        return EnquiryId;
      }
    }

    [Ignore]
    public int? EnquiryId { get; set; }

    [Ignore]
    public int? CategoryId { get; set; }

    public DateTime EnquiryDate { get; set; }

    /// <summary>
    /// A summary or category of the type of enquiry
    /// </summary>
    public string Enquiry { get; set; }

    [Ignore]
    public EnquiryFlags EnquiryFlags { get; set; }

    public virtual string Comments { get; set; }

    public string ToString(string separator = ", ")
    {
      string[] row = new string[4] { Name, Email, ContactNumber, Address.ToString(separator) };
      return string.Join(separator, row.Where(x => !string.IsNullOrEmpty(x)));
    }

    public override string ToString()
    {
      return ToString(", ");
    }
  }
}