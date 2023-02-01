using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    public class BuggyController: BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]

        public ActionResult<string> GetSecret()
        {
            return "secret txt";
        }



        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);

            if(thing == null)return NotFound();

            return thing;

        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            try
            {
                var thing = _context.Users.Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Computer says no!");
            }


        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
        
            return BadRequest("Whis was not a good request");

        }






    }

    




}