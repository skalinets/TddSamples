﻿using FluentAssertions;
using NHibernate;
using NUnit.Framework;

namespace NHTests
{
    public class InMemoryDBIntegrationTests : InMemoryDatabaseTestBase
    {
        [SetUp]
        public void setup()
        {
            SetUp();
        }

        [TearDown]
        public void Done()
        {
            Finish();
        }

        [Test]
        public void read_and_write_test()
        {
            object id;

            using (ITransaction tx = session.BeginTransaction())
            {
                id = session.Save(Author.Create("test author"));
                tx.Commit();
            }

            session.Clear(); 

            using (ITransaction tx = session.BeginTransaction())
            {
                var author = session.Get<Author>(id);
                author.Name.Should().Be("test author");
                tx.Commit();
            }
        }

        #region other tests

//        [Test]
//        public void read_and_write_test6()
//        {
//            object id;
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                id = session.Save(new Author("test author"));
//                tx.Commit();
//            }
//
//            session.Clear();
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                var author = session.Get<Author>(id);
//                author.Name.Should().Be("test author");
//                tx.Commit();
//            }
//        }
//
//        [Test]
//        public void read_and_write_test3()
//        {
//            object id;
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                id = session.Save(new Author("test author"));
//                tx.Commit();
//            }
//
//            session.Clear();
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                var author = session.Get<Author>(id);
//                author.Name.Should().Be("test author");
//                tx.Commit();
//            }
//        }
//
//        [Test]
//        public void read_and_write_test2()
//        {
//            object id;
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                id = session.Save(new Author("test author"));
//                tx.Commit();
//            }
//
//            session.Clear();
//
//            using (ITransaction tx = session.BeginTransaction())
//            {
//                var author = session.Get<Author>(id);
//                author.Name.Should().Be("test author");
//                tx.Commit();
//            }
//        }

        #endregion
    }
}