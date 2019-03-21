using System;

namespace restlessmedia.Module.Contact
{
  [Flags]
  public enum ContactFlags : byte
  {
    Anonymous = 1,
    Personal = 2,
    Business = 4,
    Organisation = 8,
    /// <summary>
    /// If this bit is enabled, the user has specified they cannot be contacted and remain protected against further marketing
    /// </summary>
    DataProtection = 16,
  }
}