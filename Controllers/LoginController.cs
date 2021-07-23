using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rock_Senai.Models;

namespace Rock_Senai.Controllers
{
    public class LoginController : Controller
    {
         public IActionResult Index()
        {
            
            return View();
        } 

        public IActionResult Logar(IFormCollection form){

            Usuario usuarioModel = new Usuario();
            bool logado = usuarioModel.Logar(form["email"], form["senha"]);

            if (logado == true)
            {
                return LocalRedirect("~/Home");
            }else
            {
                return LocalRedirect("~/Login");
            }

        }
    }
}