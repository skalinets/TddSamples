using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests.Reporters;
using Playground.Wpf;
using ApprovalTests;

namespace Playground.Tests
{
    [TestFixture]
    [UseReporter(typeof(ImageReporter))]
    //[UseReporter(typeof(DiffReporter))]
    public class WpfFormsApproveTests
    {
        [Test]
        [STAThread]
        public void should_approve_wpf_form()
        {
            // do
            var form = new MainWindow();

            // verify
            ApprovalTests.Wpf.Approvals.Approve(form);
        }
    }
}
