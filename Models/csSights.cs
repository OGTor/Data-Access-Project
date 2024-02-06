using Microsoft.Extensions.Azure;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class csSights : ISeed<csSights>, IEquatable<csSights>
    {
        [Key]

        public Guid csSightId { get; set; }
        public string SightName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        //Address FK
        public Guid AddressId { get; set; }
        public csAddress Address { get; set; }

        //Kommentarer relaterad till Sights
        public Collection<csComments> Comments { get; set; }

        public bool Seeded { get; set; } = false;

        #region Constructors

        public csSights()
        {
            Comments = new Collection<csComments>();
        }
        public csSights(csSights org)
        {
            Seeded = true;

            csSightId = org.csSightId;
            SightName = org.SightName;
            Description = org.Description;
            Address = org.Address;
            Comments = org.Comments;
        }

        #endregion

        #region IEquatable
        public bool Equals(csSights other) => (other != null) ? ((SightName, Description, Category) ==
            (other.SightName, other.Description, other.Category)) : false;

        public override bool Equals(object obj) => Equals(obj as csSights);
        public override int GetHashCode() => (SightName, Description ,Category).GetHashCode();

        #endregion

        #region Rnd Seed Instance

        public virtual csSights Seed(csSeedGenerator sgen)
        {
            Seeded = true;

            csSightId = Guid.NewGuid();
            SightName = sgen.SightName;
            Description = sgen.Description;
            Category = sgen.Category;
            Address = new csAddress().Seed(sgen);

            //generate 0-20 comments
            Random rnd = new Random();
            int nrOfComments = rnd.Next(0, 21);
            for (int i = 0; i < nrOfComments; i++)
            {
                var comment = new csComments().Seed(sgen);
                comment.Sight = this;
                comment.csSightId = this.csSightId;
                Comments.Add(comment);
            }

            return this;
        }

        public virtual csSights Unseed()
        {
            Seeded = false;

            csSightId = Guid.Empty;
            SightName = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            Address = null;

            Comments.Clear();

            return this;
        }
        #endregion
    }
}