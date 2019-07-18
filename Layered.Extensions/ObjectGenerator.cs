using System;

namespace Layered.Extensions.Helpers
{
    /// <summary>
    /// All helper utilities for generating a particular object go here
    /// </summary>
    public static class ObjectGenerator
    {
        /// <summary>
        /// Generates a random integer value
        /// </summary>
        /// <returns></returns>
        public static int RandomInt()
        {
            return new Random().Next();
        }
    }
}
