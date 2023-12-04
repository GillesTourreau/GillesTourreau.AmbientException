//-----------------------------------------------------------------------
// <copyright file="Class1.cs" company="Gilles TOURREAU">
//     Copyright (c) Gilles TOURREAU. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GillesTourreau.AmbientException
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            using (var obj = new DisposableObject())
            {
            }

            try
            {
                using (var obj = new DisposableObject())
                {
                    Throw();
                }
            }
            catch
            {
            }
        }

        private static void Throw()
        {
            throw new InvalidOperationException("An exception is thrown !");
        }

        private class DisposableObject : IDisposable
        {
            public void Dispose()
            {
                if (ExceptionHelper.IsExceptionOnGoing())
                {
                    Console.WriteLine("We are in the Dispose() method and an exception is on going.");
                }
                else
                {
                    Console.WriteLine("We are in the Dispose() method.");
                }
            }
        }
    }
}