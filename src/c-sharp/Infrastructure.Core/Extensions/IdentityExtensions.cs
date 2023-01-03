using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Infrastructure.Core.Extensions
{
    /// <summary>
    ///     Extensions making it easier to get the user related claims off of an identity
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        ///     Return the user's email using the "email" ClaimType.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetEmail(this IIdentity identity)
        {
            if (identity is null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;
            if (ci is null)
            {
                return null;
            }

            return ci.FindFirst("email")?.Value;
        }

        /// <summary>
        ///     Return the user's first name using the "given_name" ClaimType.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetFirstName(this IIdentity identity)
        {
            if (identity is null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;
            if (ci is null)
            {
                return null;
            }

            return ci.FindFirst("given_name")?.Value;
        }

        /// <summary>
        ///     Return the user's surname using the "family_name" ClaimType.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetSurname(this IIdentity identity)
        {
            if (identity is null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;
            if (ci is null)
            {
                return null;
            }

            return ci.FindFirst("family_name")?.Value;
        }

        /// <summary>
        ///     Return the current client.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetClient(this IIdentity identity)
        {
            if (identity is null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;
            if (ci is null)
            {
                return null;
            }

            return ci.FindFirst("client_id")?.Value;
        }
    }
}