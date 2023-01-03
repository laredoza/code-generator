using System.Security.Claims;

namespace Infrastructure.Core.Extensions
{
    /// <summary>
    ///     Extensions making it easier to get the user related claims off of a claims principal.
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        ///     Return the user's email using the "email" ClaimType.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                return null;
            }

            return principal.FindFirst(ClaimTypes.Email)?.Value;
        }

        /// <summary>
        ///     Return the user's first name using the "given_name" ClaimType.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                return null;
            }

            return principal.FindFirst("given_name")?.Value;
        }

        /// <summary>
        ///     Return the user's surname using the "family_name" ClaimType.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetSurname(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                return null;
            }

            return principal.FindFirst("family_name")?.Value;
        }

        /// <summary>
        ///     Return the current client.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetClient(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                return null;
            }

            return principal.FindFirst("client_id")?.Value;
        }
    }
}