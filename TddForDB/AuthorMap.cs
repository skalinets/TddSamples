using FluentNHibernate.Mapping;

namespace NHTests
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(_ => _.ID);
            Map(_ => _.Name);
        }
    }
}