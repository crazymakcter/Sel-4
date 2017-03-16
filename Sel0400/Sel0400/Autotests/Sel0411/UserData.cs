using System;
using System.Linq;

namespace Sel0400.Autotests.Sel0411
{
  public class UserData
  {
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Adres { get; set; }
    public string PosCode { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Pass { set; get; }

    private static readonly Random Random = new Random();
    public static string GenerateText(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
    public static string GenerateNumber(int length)
    {
      const string chars = "0123456789";
      return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
  }
}
