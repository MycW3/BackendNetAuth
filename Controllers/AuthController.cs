using System.Security.Claims;
using backendnet.Models;
using backendnet.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backendnet.Controllers;

[Route("api/[controller]")]
[ApiController]
    public class AuthController(UserManager<CustomIdentityUser> userManager, JwtTokenService jwtTokenService) : Controller
    {
    //POST : api/auth
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] LoginDTO loginDTO){
        //verificamos credenciales con Identity
        var usuario = await userManager.FindByEmailAsync(loginDTO.Email);

        if (usuario is null || !await userManager.CheckPasswordAsync(usuario, loginDTO.Password))
        {
            //Regresa 401 Acceso no autorizado
            return Unauthorized(new { mensaje = "Usuario o contrasela incorrectos"} );
        }
       //Estos valores nos indicaran el usuario autenticado en cada peticion usando el token
        var roles = await userManager.GetRolesAsync(usuario);
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, usuario.Email!),
            new (ClaimTypes.GivenName, usuario.Nombre),
            new (ClaimTypes.Role, roles.First()),
        };

        //Creamos el token de acceso
        var jwt = jwtTokenService.GeneraToken(claims);

        //Le regresa su token de acceso al usuario con validez de 20 minutos
        return Ok(new
            { usuario.Email,
            usuario.Nombre,
            rol = string.Join(",", roles),
            jwt

            });
        }
    }

    
            
