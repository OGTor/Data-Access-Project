using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;

namespace Models;

public class csAddress : ISeed<csAddress>, IEquatable<csAddress>
{
    [Key]
    public Guid AddressId { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public bool Seeded { get; set; } = false;

    #region Constructors
    
    public csAddress() { }
    public csAddress(csAddress og)
    {
        Seeded = og.Seeded;

        AddressId = og.AddressId;
        StreetAddress = og.StreetAddress;
        City = og.City;
        Country = og.Country;
    }
    

    #endregion

    #region IEquatable

    public bool Equals(csAddress other) => (other != null)
        ? ((StreetAddress, City, Country) == (other.StreetAddress, other.City, other.Country))
        : false;
    public override bool Equals(object obj) => Equals(obj as csAddress);
    public override int GetHashCode() => (StreetAddress, City, Country).GetHashCode();

    #endregion
    #region rnd seed instance

    public virtual csAddress Seed(csSeedGenerator sgen)
    {
        Seeded = true;

        AddressId = Guid.NewGuid();
        StreetAddress = sgen.StreetAddress(Country);
        City = sgen.City(Country);
        Country = sgen.Country;

        return this;
    }

    #endregion
}