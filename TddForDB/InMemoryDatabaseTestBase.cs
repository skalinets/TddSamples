using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHTests
{
    public class InMemoryDatabaseTestBase /*: IDisposable*/
    {
        private static Configuration Configuration;
        private static ISessionFactory SessionFactory;
        protected ISession session;

        protected void SetUp()
        {
            if (Configuration == null)
            {
                Configuration = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorMap>()).BuildConfiguration();

                SessionFactory = Configuration.BuildSessionFactory();
            }

            session = SessionFactory.OpenSession();
            new SchemaExport(Configuration).Execute(true, true, false, session.Connection, Console.Out);
        }

        protected void Finish()
        {
            session.Dispose();
        }
    }
}