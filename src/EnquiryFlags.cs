using System;

namespace restlessmedia.Module.Contact
{
  [Flags]
  public enum EnquiryFlags : byte
  {
		None = 0,
		Feedback = 1,
		Other = 2
  }
}