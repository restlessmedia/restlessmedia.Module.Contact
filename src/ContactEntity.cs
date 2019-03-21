using restlessmedia.Module.Address;

namespace restlessmedia.Module.Contact
{
  public class ContactEntity : Entity
  {
    public override EntityType EntityType
    {
      get
      {
        return EntityType.Contact;
      }
    }

    public override int? EntityId
    {
      get
      {
        return ContactId;
      }
    }

    [Ignore]
    public int? ContactId { get; set; }

    [Ignore]
    public string ApplicationName { get; set; }

    [Ignore]
    public virtual string Username { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

		public virtual string Name
		{
			get
			{
				return string.Concat(FirstName, " ", Surname).Trim();
			}
			set
			{
				if (string.IsNullOrEmpty(value))
        {
          return;
        }

        int firstSpacePos = value.IndexOf(" ", 0);
				if (firstSpacePos == -1)
				{
					FirstName = value;
				}
				else
				{
					FirstName = value.Substring(0, firstSpacePos);
					Surname = value.Substring(firstSpacePos);
				}
			}
		}

    public virtual string Email { get; set; }

    public virtual string ContactNumber { get; set; }

    public string CompanyName { get; set; }

    public virtual string Url { get; set; }

    [Ignore]
    public ContactFlags ContactFlags { get; set; }
    
    public AddressEntity Address
    {
      get
      {
        return _address = _address ?? new AddressEntity();
      }
      set
      {
        _address = value;
      }
    }

    private AddressEntity _address = null;
  }
}