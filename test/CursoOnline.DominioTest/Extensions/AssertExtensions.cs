using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest.Extensions
{
    public static class AssertExtensions
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            var validate = exception != null && exception.Message == message ? true : false;

            if (validate)
                Assert.True(true);
            else
                Assert.False(true, String.Format("Expected message '{0}'", message));
        }
    }
}
