using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeRegisterAPI.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwelVendorsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public JwelVendorsController(EmployeeDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/JwelVendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JwelVendor>>> GetJwellers()
        {
            return await _context.Jwellers
                .Select(x => new JwelVendor() { 
                EmployeeID = x.EmployeeID,
                EmployeeName = x.EmployeeName,
                Occupation = x.Occupation,
                Located_distric=x.Located_distric,
                Located_province = x.Located_province,
				TelephoneNumber=x.TelephoneNumber,
				CompanyWebsite=x.CompanyWebsite,
                Min_package=x.Min_package,
                Max_package = x.Max_package,
                ImageName = x.ImageName,
                ImageSrc = String.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.ImageName)
                })
                .ToListAsync();
        }

        // GET: api/JwelVendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JwelVendor>> GetJwelVendor(int id)
        {
            var jwelVendor = await _context.Jwellers.FindAsync(id);

            if (jwelVendor == null)
            {
                return NotFound();
            }

            return jwelVendor;
        }

        // PUT: api/JwelVendors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJwelVendor(int id, [FromForm]JwelVendor jwelVendor)
        {
            if (id != jwelVendor.EmployeeID)
            {
                return BadRequest();
            }

            if(jwelVendor.ImageFile != null)
            {
                DeleteImage(jwelVendor.ImageName);
                jwelVendor.ImageName =await SaveImage(jwelVendor.ImageFile);
            }

            _context.Entry(jwelVendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JwelVendorExists(id))
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

        // POST: api/JwelVendors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JwelVendor>> PostJwelVendor([FromForm]JwelVendor jwelVendor)
        {
            jwelVendor.ImageName =await SaveImage(jwelVendor.ImageFile);
            _context.Jwellers.Add(jwelVendor);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // DELETE: api/JwelVendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JwelVendor>> DeleteJwelVendor(int id)
        {
            var jwelVendor = await _context.Jwellers.FindAsync(id);
            if (jwelVendor == null)
            {
                return NotFound();
            }
            DeleteImage(jwelVendor.ImageName);
            _context.Jwellers.Remove(jwelVendor);
            await _context.SaveChangesAsync();

            return jwelVendor;
        }

        private bool JwelVendorExists(int id)
        {
            return _context.Jwellers.Any(e => e.EmployeeID == id);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
