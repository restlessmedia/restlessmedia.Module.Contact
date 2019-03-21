namespace restlessmedia.Module.Contact
{
  public struct ContactNumber
  {
    public ContactNumber(string name, string number)
    {
      Name = name;
      Number = number;
    }

    public readonly string Name;

    public readonly string Number;
  }
}