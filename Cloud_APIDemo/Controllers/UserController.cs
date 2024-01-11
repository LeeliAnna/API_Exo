using BLL.Forms;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_API_Exo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok(_userService.GetAll);
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            User? u = _userService.GetById(id);

            if (u is not null)
            {
                return Ok(u);
            }
            return BadRequest();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create(RegisterForm form)
        {
            if(ModelState.IsValid)
            {
                _userService.Create(form);
            }
            return Ok();
        }

        [HttpPatch("update")]
        public IActionResult Update(int id)
        {
            UpdatePasswordForm form = new UpdatePasswordForm()
            {
                Id = id,
                ConfirmationPassword = "",
                Password = "",
            };
            return Ok(form);
        }

        [HttpPatch("update")]
        public IActionResult Update(UpdatePasswordForm form)
        {
            if (ModelState.IsValid)
            {
                if (_userService.UpdatePassword(form))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Mot de passe incorrecte");
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_userService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

    }
}
