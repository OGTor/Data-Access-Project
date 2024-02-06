using System.Collections.Generic;

namespace Models
{
    public class GoodComment
    {
        public string Comment { get; set; }
        public csUser Author { get; set; }

        public GoodComment() { }

        public GoodComment(string qoute, csUser author)
        {
            Comment = qoute;
            Author = author;
        }
    }

    public interface ISeed<T>
    {
        //In order to separate from real and seeded instances
        public bool Seeded { get; set; }

        //Seeded The instance
        public T Seed(csSeedGenerator seedGenerator);
    }

    public class csSeedGenerator : Random
    {

        string[] _firstnames = "Harry, Lord, Hermione, Albus, Severus, Ron, Draco, Frodo, Gandalf, Sam, Peregrin, Saruman".Split(", ");
        string[] _lastnames = "Potter, Voldemort, Granger, Dumbledore, Snape, Malfoy, Baggins, the Gray, Gamgee, Took, the White".Split(", ");

        string[][] _city =
            {
                "Stockholm, Göteborg, Malmö, Uppsala, Linköping, Örebro".Split(", "),
                "Oslo, Bergen, Trondheim, Stavanger, Dramen".Split(", "),
                "Köpenhamn, Århus, Odense, Aahlborg, Esbjerg".Split(", "),
                "Helsingfors, Espoo, Tampere, Vaanta, Oulu".Split(", "),
             };

        string[][] _address =
            {
                "Svedjevägen, Ringvägen, Vasagatan, Odenplan, Birger Jarlsgatan, Äppelviksvägen, Kvarnbacksvägen".Split(", "),
                "Bygdoy alle, Frognerveien, Pilestredet, Vidars gate, Sågveien, Toftes gate, Gardeveiend".Split(", "),
                "Rolighedsvej, Fensmarkgade, Svanevej, Gröndalsvej, Githersgade, Classensgade, Moltekesvej".Split(", "),
                "Arkandiankatu, Liisankatu, Ruoholahdenkatu, Pohjoistranta, Eerikinkatu, Vauhtitie, Itainen Vaideki".Split(", ")
            };

        string[] _country = "Sweden, Norway, Denmark, Finland".Split(", ");


        string[] _domains = "icloud.com, me.com, mac.com, hotmail.com, gmail.com".Split(", ");

        string[] _sightnames = "Colosseum, Eiffel Tower, Statue of Liberty, Pyramids of Giza, Great Wall of China, Machu Picchu, Taj Mahal, Big Ben, Sydney Opera House, Christ the Redeemer, Stonehenge, Acropolis, Notre Dame Cathedral, Brandenburg Gate, Mount Rushmore".Split(", ");
        string[] _category = "Amphitheater, Tower, Statue, Pyramids, Wall, Ancient City, Mausoleum, Clock Tower, Opera House, Statue, Prehistoric Monument, Ancient Citadel, Cathedral, Gate, Mountain Sculpture".Split(", ");
        string[] _description = "A historic amphitheater located in the center of Rome, Italy, An iconic iron tower located on the Champ de Mars in Paris, France, A colossal neoclassical sculpture on Liberty Island in New York City, USA, Ancient limestone structures located in Giza, Egypt, A series of fortifications made of stone, brick, and other materials, primarily built along the northern borders of China, A 15th-century Inca citadel situated on a mountain ridge above the Sacred Valley in Peru, An ivory-white marble mausoleum on the right bank of the Yamuna river in the Indian city of Agra, A historic clock tower located at the north end of the Palace of Westminster in London, UK, A multi-venue performing arts center in Sydney, Australia, A towering statue of Jesus Christ located atop the Corcovado mountain in Rio de Janeiro, Brazil, A prehistoric monument consisting of a ring of standing stones, located in Wiltshire, England, Ancient citadel located above the city of Athens, Greece, A medieval Catholic cathedral located on the Île de la Cité in Paris, France, A neoclassical monument in Berlin, Germany, A famous sculpture carved into the granite face of Mount Rushmore in South Dakota, USA".Split(", ");

        GoodComment[] _comments = {
            
            new GoodComment("Lorem ipsum dolor sit amet? Consectetur. Adipiscing. Vestibulum non magna et dui convallis posuere.", new csUser()),
            new GoodComment("Vestibulum facilisis, purus nec? Pulvinar iaculis. Velit orci aliquet augue.", new csUser()),
            new GoodComment("Sed do eiusmod tempor incididunt? Labore et dolore. Magna aliqua.", new csUser()),
            new GoodComment("Ut enim ad minim veniam? Quis nostrud. Exercitation ullamco.", new csUser()),
            new GoodComment("Nulla facilisi etiam dignissim? Diam quis enim. Lobortis scelerisque fermentum.", new csUser()),
            new GoodComment("Pellentesque elit eget gravida? Sed pulvinar proin. Gravida hendrerit lectus.", new csUser()),
            new GoodComment("Turpis egestas maecenas pharetra? Convallis posuere. Morbi leo urna.", new csUser()),
            new GoodComment("Elementum facilisis leo vel? Risus commodo. Viverra maecenas.", new csUser()),
            new GoodComment("Tempor orci dapibus ultrices? In hac habitasse. Platea dictumst.", new csUser()),
            new GoodComment("Risus sed vulputate odio? Ut enim. Blandit volutpat.", new csUser()),
            new GoodComment("Fringilla phasellus faucibus scelerisque? Eleifend donec pretium. Vulputate sapien.", new csUser()),
            new GoodComment("Neque vitae tempus quam? Pellentesque nec. Nam aliquam sem et tortor consequat.", new csUser()),
            new GoodComment("Curabitur vitae nunc sed velit? Dignissim sodales. Ut eu sem integer.", new csUser()),
            new GoodComment("Vitae turpis massa sed elementum? Tempus egestas. Sed sed risus pretium.", new csUser()),
            new GoodComment("Nunc aliquet bibendum enim? Facilisis gravida. Neque convallis a cras semper.", new csUser()),
            new GoodComment("Risus quis varius quam quisque? Id diam vel. Quam elementum pulvinar.", new csUser()),
            new GoodComment("Amet mattis vulputate enim? Nulla aliquet porttitor. Lacus luctus accumsan.", new csUser()),
            new GoodComment("Lorem ipsum dolor sit amet? Consectetur. Adipiscing. Vestibulum non magna et dui convallis posuere.", new csUser()),
            new GoodComment("Vestibulum facilisis, purus nec? Pulvinar iaculis. Velit orci aliquet augue.", new csUser()),
            new GoodComment("Sed do eiusmod tempor incididunt? Labore et dolore. Magna aliqua.", new csUser()),
            new GoodComment("Ut enim ad minim veniam? Quis nostrud. Exercitation ullamco.", new csUser()),
            new GoodComment("Nulla facilisi etiam dignissim? Diam quis enim. Lobortis scelerisque fermentum.", new csUser()),
            new GoodComment("Pellentesque elit eget gravida? Sed pulvinar proin. Gravida hendrerit lectus.", new csUser()),
            new GoodComment("Turpis egestas maecenas pharetra? Convallis posuere. Morbi leo urna.", new csUser()),
            new GoodComment("Elementum facilisis leo vel? Risus commodo. Viverra maecenas.", new csUser()),
            new GoodComment("Tempor orci dapibus ultrices? In hac habitasse. Platea dictumst.", new csUser()),
            new GoodComment("Risus sed vulputate odio? Ut enim. Blandit volutpat.", new csUser()),
            new GoodComment("Fringilla phasellus faucibus scelerisque? Eleifend donec pretium. Vulputate sapien.", new csUser()),
            new GoodComment("Neque vitae tempus quam? Pellentesque nec. Nam aliquam sem et tortor consequat.", new csUser()),
            new GoodComment("Curabitur vitae nunc sed velit? Dignissim sodales. Ut eu sem integer.", new csUser()),
            new GoodComment("Vitae turpis massa sed elementum? Tempus egestas. Sed sed risus pretium.", new csUser()),
            new GoodComment("Nunc aliquet bibendum enim? Facilisis gravida. Neque convallis a cras semper.", new csUser()),
            new GoodComment("Risus quis varius quam quisque? Id diam vel. Quam elementum pulvinar.", new csUser()),
            new GoodComment("Amet mattis vulputate enim? Nulla aliquet porttitor. Lacus luctus accumsan.", new csUser()),

        };

        public string SightName => _sightnames[this.Next(0, _sightnames.Length)];
        public string Category => _category[this.Next(0, _category.Length)];
        public string Description => _description[this.Next(0, _description.Length)];
        public string FirstName => _firstnames[this.Next(0, _firstnames.Length)];
        public string LastName => _lastnames[this.Next(0, _lastnames.Length)];
        public string UserName => $"{FirstName} {LastName}";


        public DateTime getDateTime(int? fromYear = null, int? toYear = null)
        {
            bool dateOK = false;
            DateTime _date = default;
            while (!dateOK)
            {
                fromYear ??= DateTime.Today.Year;
                toYear ??= DateTime.Today.Year + 1;

                try
                {
                    int year = this.Next(Math.Min(fromYear.Value, toYear.Value),
                        Math.Max(fromYear.Value, toYear.Value));
                    int month = this.Next(1, 13);
                    int day = this.Next(1, 32);

                    _date = new DateTime(year, month, day);
                    dateOK = true;
                }
                catch
                {
                    dateOK = false;
                }
            }

            return DateTime.SpecifyKind(_date, DateTimeKind.Utc);
        }

        //General random truefalse
        public bool Bool => (this.Next(0, 10) < 5) ? true : false;

        public string Email(string fname = null, string lname = null)
        {
            fname ??= FirstName;
            lname ??= LastName;

            return $"{fname}.{lname}@{_domains[this.Next(0, _domains.Length)]}";
        }

        public string Phone => $"{this.Next(700, 800)} {this.Next(100, 1000)} {this.Next(100, 1000)}";

        public string Country => _country[this.Next(0, _country.Length)];

        public string City(string Country = null)
        {

            var cIdx = this.Next(0, _city.Length);
            if (Country != null)
            {
                //Give a City in that specific country
                cIdx = Array.FindIndex(_country, c => c.ToLower() == Country.Trim().ToLower());

                if (cIdx == -1) throw new Exception("Country not found");
            }

            return _city[cIdx][this.Next(0, _city[cIdx].Length)];
        }

        public string StreetAddress(string Country = null)
        {

            var cIdx = this.Next(0, _city.Length);
            if (Country != null)
            {
                //Give a City in that specific country
                cIdx = Array.FindIndex(_country, c => c.ToLower() == Country.Trim().ToLower());

                if (cIdx == -1) throw new Exception("Country not found");
            }

            return $"{_address[cIdx][this.Next(0, _address[cIdx].Length)]} {this.Next(1, 51)}";
        }

        public int ZipCode => this.Next(10101, 100000);

        #region Seed from own datastructures
        public TEnum FromEnum<TEnum>() where TEnum : struct
        {
            if (typeof(TEnum).IsEnum)
            {

                var _names = typeof(TEnum).GetEnumNames();
                var _name = _names[this.Next(0, _names.Length)];

                return Enum.Parse<TEnum>(_name);
            }
            throw new ArgumentException("Not an enum type");
        }
        public TItem FromList<TItem>(List<TItem> items)
        {
            return items[this.Next(0, items.Count)];
        }
        #endregion

        #region generate seeded Lists
        public List<TItem> ToList<TItem>(int NrOfItems)
            where TItem : ISeed<TItem>, new()
        {
            //Create a list of seeded items
            var _list = new List<TItem>();
            for (int c = 0; c < NrOfItems; c++)
            {
                _list.Add(new TItem().Seed(this));
            }
            return _list;
        }

        //Create a list of unique randomly seeded items
        public List<TItem> ToListUnique<TItem>(int tryNrOfItems, List<TItem> appendToUnique = null)
             where TItem : ISeed<TItem>, IEquatable<TItem>, new()
        {
            //Create a list of uniquely seeded items
            HashSet<TItem> _set = (appendToUnique == null) ? new HashSet<TItem>() : new HashSet<TItem>(appendToUnique);

            while (_set.Count < tryNrOfItems)
            {
                var _item = new TItem().Seed(this);

                int _preCount = _set.Count();
                int tries = 0;
                do
                {
                    _set.Add(_item);
                    if (++tries >= 5)
                    {
                        //it takes more than 5 tries to generate a random item.
                        //Assume this is it. return the list
                        return _set.ToList();
                    }
                } while (!(_set.Count > _preCount));
            }

            return _set.ToList();
        }


        //Pick a number of unique items from a list of TItem (which does not have to be unique)
        public List<TItem> FromListUnique<TItem>(int tryNrOfItems, List<TItem> list = null)
        where TItem : ISeed<TItem>, IEquatable<TItem>, new()
        {
            //Create a list of uniquely seeded items
            HashSet<TItem> _set = new HashSet<TItem>();

            while (_set.Count < tryNrOfItems)
            {
                var _item = list[this.Next(0, list.Count)];

                int _preCount = _set.Count();
                int tries = 0;
                do
                {
                    _set.Add(_item);
                    if (++tries >= 5)
                    {
                        //it takes more than 5 tries to generate a random item.
                        //Assume this is it. return the list
                        return _set.ToList();
                    }
                } while (!(_set.Count > _preCount));
            }

            return _set.ToList();
        }

        #endregion

        #region Quotes
        public List<GoodComment> AllComments => _comments.ToList<GoodComment>();
        public GoodComment Comment => _comments[this.Next(0, _comments.Length)];
        #endregion
    }
}

