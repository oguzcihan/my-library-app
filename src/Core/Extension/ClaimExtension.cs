using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Extension
{
    public static class ClaimExtension
    {
        //extension yazdım jwthelper classında kullanmak için
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            //o anki rolü foreachle döndüm ve neyse yazdırdım.
            //bu şekilde o anki rolün ne olduğuna ulaşım sağladım.
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
