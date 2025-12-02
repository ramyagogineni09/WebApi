
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsControllers : ControllerBase
    {
        private readonly DataContext dbcontext;

        public AppointmentsControllers(DataContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments() { 

            return await dbcontext.Appointments.ToListAsync();
        
        
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointments(int id) {

            var appointments = await dbcontext.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return Ok(appointments);
        }
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            dbcontext.Appointments.Add(appointment);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAppointments), new { id = appointment.Id }, appointment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id,Appointment appointment) {

            if (id != appointment.Id)
            
                return BadRequest("Id mismatched");
            
                dbcontext.Entry(appointment).State = EntityState.Modified;
              await  dbcontext.SaveChangesAsync();
                return NoContent();
                    
                   }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id) {

            var appointment = await dbcontext.Appointments.FindAsync();
            if(appointment == null)
                return NotFound();
            dbcontext.Appointments.Remove(appointment);
            await dbcontext.SaveChangesAsync();
            return NoContent();

        
        }


    }
}
