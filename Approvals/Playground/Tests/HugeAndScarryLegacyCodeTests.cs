using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests.Reporters;
using Playground.Legacy;
using ApprovalTests;

namespace Playground.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class HugeAndScarryLegacyCodeTests
    {
        [Test]
        public void shoudl_work_some_how()
        {
            Approvals.Approve(HugeAndScarryLegacyCode.TheUgliesMethodYouMightEverSeen("someinput", 10, 'c'));
        }

        [Test]
        public void should_try_to_cover_it()
        {
            var numbers = Enumerable.Range(1, 100);
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var strings = new[] { "approvals", "xpdays", "^stangeword^", "a", "b" };

            ApprovalTests.Combinations.Approvals.ApproveAllCombinations(
                (s, i, c) => HugeAndScarryLegacyCode.TheUgliesMethodYouMightEverSeen(s, i, c),
                strings,
                numbers,
                chars);
        }
    }
}
