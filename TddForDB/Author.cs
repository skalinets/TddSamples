namespace NHTests
{
    public class Author
    {
        public virtual int ID { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string City { get; set; }

        public static Author Create(string name)
        {
            return new Author {Name = name};
        }
    }
}