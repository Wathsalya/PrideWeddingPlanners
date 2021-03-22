using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using EmployeeRegisterAPI.Data;
using EmployeeRegisterAPI.Models;

namespace PrideWeddingPlanners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientLoginsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public ClientLoginsController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientLogin>>> GetClientLogins()
        {
            return await _context.ClientLogins.ToListAsync();
        }

        // GET: api/ClientLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientLogin>> GetClientLogin(int id)
        {
            var clientLogin = await _context.ClientLogins.FindAsync(id);

            if (clientLogin == null)
            {
                return NotFound();
            }

            return clientLogin;
        }

        // PUT: api/ClientLogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientLogin(int id, ClientLogin clientLogin)
        {
            if (id != clientLogin.ID)
            {
                return BadRequest();
            }

            _context.Entry(clientLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientLoginsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientLogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        /*public async Task<ActionResult<ClientLogin>> PostClientLogin(ClientLogin clientLogin)
        {
            _context.ClientLogins.Add(clientLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientLogin", new { id = clientLogin.ID }, clientLogin);
        }*/
        [HttpPost]
        public async Task<ActionResult<ClientLogin>> PostClientLogin(ClientLogin clientLogin)
        {
            try
            {            // CustomerModelDB.Add(newcustomer);
                var CheckUserNameBuyer = _context.Clients.FirstOrDefault(m => m.UserName.ToLower() == clientLogin.UserName.ToLower()); //check email already exit or not
                var CheckPasswordBuyer = _context.Clients.FirstOrDefault(m => m.Password == clientLogin.Password);

                var CheckUserNameSeller = _context.Vendors.FirstOrDefault(m => m.UserName.ToLower() == clientLogin.UserName.ToLower()); //check email already exit or not
                var CheckPasswordSeller = _context.Vendors.FirstOrDefault(m => m.Password == clientLogin.Password);




                if ((CheckUserNameBuyer == null || CheckPasswordBuyer == null) && (CheckUserNameSeller == null || CheckPasswordSeller == null))
                {
                    return BadRequest(); //New page
                }



                else
                {
                    //await _mailService.SendEmailAsync(login.Email, "New login", "<h1>Hey!, Did you login to your account</h1><p>New login to your account at " + DateTime.Now + "</p>");

                    return Ok();


                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // DELETE: api/ClientLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientLogin>> DeleteClientLogin(int id)
        {
            var clientLogin = await _context.ClientLogins.FindAsync(id);
            if (clientLogin == null)
            {
                return NotFound();
            }

            _context.ClientLogins.Remove(clientLogin);
            await _context.SaveChangesAsync();

            return clientLogin;
        }

        private bool ClientLoginsExists(int id)
        {
            return _context.ClientLogins.Any(e => e.ID == id);
        }
    }
}
