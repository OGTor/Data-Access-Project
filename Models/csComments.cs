using System.ComponentModel.DataAnnotations;


namespace Models;


public class csComments : ISeed<csComments>, IEquatable<csComments>
{
    [Key]
    //Sevärdighet Foreignkey
    public Guid csSightId { get; set; }

    public csSights Sight { get; set; }
    public bool Seeded { get; set; } = false;

    public Guid CommentId { get; set; }
    public string Comment { get; set; }

    //Användares Kommentarer
    public csUser Author { get; set; }
    public Guid UserId { get; set; }



    public csComments()
    {
    }

    public csComments(csComments og)
    {
        CommentId = og.CommentId;
        Comment = og.Comment;
        Author = og.Author;
        csSightId = og.csSightId;
        Sight = og.Sight;
        Seeded = og.Seeded;
    }

    public bool Equals(csComments other) => (other != null)
        ? ((Comment, Author) ==
           (other.Comment, other.Author))
        : false;

    public override bool Equals(object obj) => Equals(obj as csComments);
    public override int GetHashCode() => (Comment, Author).GetHashCode();

    public virtual csComments Seed(csSeedGenerator sgen)
    {
        Seeded = true;
        CommentId = Guid.NewGuid();

        var _comment = sgen.Comment;
        Comment = _comment.Comment;
        Author = new csUser().Seed(sgen);

        return this;

    }


}