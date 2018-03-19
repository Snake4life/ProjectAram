using System;
using System.Diagnostics;

namespace ProjectAram.Helpers
{
    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }
}