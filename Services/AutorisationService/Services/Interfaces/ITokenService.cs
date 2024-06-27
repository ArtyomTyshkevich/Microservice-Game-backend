using AutorisationService.Models;
using Microsoft.AspNetCore.Identity;


namespace AutorisationService.Services;

public interface ITokenService
{
    string CreateToken(User user, List<IdentityRole<long>> role);
}