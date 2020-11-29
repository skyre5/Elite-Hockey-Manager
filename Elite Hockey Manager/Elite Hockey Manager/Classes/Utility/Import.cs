namespace Elite_Hockey_Manager.Classes.Utility
{
    using System;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Static import class for functions to import objects from online
    /// </summary>
    public static class Import
    {
        #region Methods

        /// <summary>
        /// Tries to grab particular select token out of JToken object gather from online API
        /// Throws argument of information is not found
        /// </summary>
        /// <param name="token">JToken made up of imported information</param>
        /// <param name="key">particular data key in JToken</param>
        /// <returns>The information of that particular key</returns>
        public static string TrySelectToken(JToken token, string key)
        {
            string info = token.SelectToken(key)?.ToString();
            if (info == null)
            {
                throw new ArgumentException($"JToken unable to access token {key}");
            }

            return info;
        }

        #endregion Methods
    }
}