using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net;
using System.Xml.Linq;

namespace Models
{
    public class csUser : ISeed<csUser>, IEquatable<csUser>
    {
    [Key]
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool Seeded { get; set; } = false;
    
    public virtual Collection<csComments> Comments { get; set; }

    public virtual csUser Seed(csSeedGenerator sgen)
    {
        Seeded = true;

        UserId = Guid.NewGuid();
        UserName = sgen.UserName;
        Email = sgen.Email();
        return this;
    }

    public bool Equals(csUser other) => (other != null)
        ? ((UserName, Email, Password, Role) == (other.UserName, other.UserName, other.Password, other.Role))
        : false;

    public override bool Equals(object obj) => Equals(obj as csUser);
    public override int GetHashCode() => (UserName, Email, Password, Role).GetHashCode();

    public csUser()
    {
        Comments = new Collection<csComments>();
    }

    public csUser(csUser og)
    {
        Seeded = true;

        UserId = og.UserId;
        UserName = og.UserName;
        Email = og.Email;
        Password = og.Password;
        Role = og.Role;
        Comments = og.Comments ?? new Collection<csComments>();

    }
    }
}