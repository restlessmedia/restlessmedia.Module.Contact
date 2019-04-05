using System.ComponentModel.DataAnnotations;
using restlessmedia.Module.DataAnnotations;

namespace restlessmedia.Module.Contact
{
  public class ContactModel : EnquiryEntity
  {
    public ContactModel() { }

    [Required(ErrorMessage = "Name is required")]
    [DataType(DataType.Text)]
    public override string Name
    {
      get
      {
        return base.Name;
      }
      set
      {
        base.Name = value;
      }
    }

    [Required(ErrorMessage = "Email is required")]
    [Email(ErrorMessage = "Invalid email")]
    [DataType(DataType.EmailAddress)]
    public override string Email
    {
      get
      {
        return base.Email;
      }
      set
      {
        base.Email = value;
      }
    }

    [TelephoneNumber(ErrorMessage = "Invalid")]
    [DataType(DataType.Text)]
    public override string ContactNumber
    {
      get
      {
        return base.ContactNumber;
      }
      set
      {
        base.ContactNumber = value;
      }
    }

    public bool DataProtection
    {
      get
      {
        return ContactFlags.HasFlag(ContactFlags.DataProtection);
      }
      set
      {
        if (value)
        {
          ContactFlags |= ContactFlags.DataProtection;
        }
        else
        {
          ContactFlags &= ~ContactFlags.DataProtection;
        }
      }
    }
  }
}