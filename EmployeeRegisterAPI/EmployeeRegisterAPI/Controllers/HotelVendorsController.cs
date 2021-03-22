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
    public class HotelVendorsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HotelVendorsController(EmployeeDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/HotelVendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelVendor>>> GetHotels()
        {
            return await _context.Hotels
                .Select(x => new HotelVendor() { 
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

        // GET: api/HotelVendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelVendor>> GetHotelVendor(int id)
        {
            var hotelVendor = await _context.Hotels.FindAsync(id);

            if (hotelVendor == null)
            {
                return NotFound();
            }

            return hotelVendor;
        }

        // PUT: api/HotelVendors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelVendor(int id, [FromForm]HotelVendor hotelVendor)
        {
            if (id != hotelVendor.EmployeeID)
            {
                return BadRequest();
            }

            if(hotelVendor.ImageFile != null)
            {
                DeleteImage(hotelVendor.ImageName);
                hotelVendor.ImageName =await SaveImage(hotelVendor.ImageFile);
            }

            _context.Entry(hotelVendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotelVendorExists(id))
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

        // POST: api/HotelVendors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelVendor>> PostSaloonVendor([FromForm]HotelVendor hotelVendor)
        {
            hotelVendor.ImageName =await SaveImage(hotelVendor.ImageFile);
            _context.Hotels.Add(hotelVendor);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // DELETE: api/HotelVendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelVendor>> DeleteHotelVendor(int id)
        {
            var hotelVendor = await _context.Hotels.FindAsync(id);
            if (hotelVendor == null)
            {
                return NotFound();
            }
            DeleteImage(hotelVendor.ImageName);
            _context.Hotels.Remove(hotelVendor);
            await _context.SaveChangesAsync();

            return hotelVendor;
        }

        private bool hotelVendorExists(int id)
        {
            return _context.Hotels.Any(e => e.EmployeeID == id);
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
