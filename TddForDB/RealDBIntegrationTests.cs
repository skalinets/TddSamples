using System;
using FluentAssertions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Simple.Data;
using Xunit;
using Xunit.Extensions;

namespace NHTests
{
    public class RealDBIntegrationTests : IDisposable
    {
        private const string connectionString = "Data Source=.;Initial Catalog=TestBlogs;Integrated Security=True";
        private readonly IStatelessSession session = CreateSessionFactory().OpenStatelessSession();
//        private readonly IStatelessSession session = CreateSessionFactory().OpenStatelessSession();

        #region IDisposable Members

        public void Dispose()
        {
            session.Dispose();
        }

        #endregion

        [Fact(), AutoRollback]
        public void RealTests()
        {
            object authorID;
            string authorName = "XXX";
            using (ITransaction transaction = session.BeginTransaction())
            {
                var author = Author.Create(authorName);
                authorID = session.Insert(author);
                transaction.Commit();
            }

//                session.Clear();

            using (ITransaction tx = session.BeginTransaction())
            {
                var author = session.Get<Author>(authorID);
                author.Name.Should().Be(authorName);
                author.Name = "XXX121";
//                    session.Update(author);
                tx.Commit();
            }

//                session.Clear();

            using (ITransaction tx = session.BeginTransaction())
            {
                var author = session.Get<Author>(authorID);
                author.Name.Should().Be(authorName);
                tx.Commit();
            }

            #region Magic

            object a = Database.OpenConnection(connectionString)
                .Authors
                .FindByName(authorName); 

//                Console.Out.WriteLine("a.ID = {0}", ((dynamic) a).ID);
            dynamic d = a;
            ((string) d.Name).Should().Be(authorName);
            ((object) d.ID).Should().Be(authorID);
            a.Should().NotBeNull();

            #endregion
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorMap>())
                .BuildSessionFactory();
        }
    }
}