using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    public class AppointmentTypeRepositoryAsync : IAppointmentTypeRepositoryAsync {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeRepositoryAsync(ApplicationDbContext context) {
            _context = context;
        }

        public async Task AddAppointmentType(AppointmentType appointmentType) {
            await _context.AppointmentTypes.AddAsync(appointmentType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentType(int id) {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();
        }

        public async Task<AppointmentType> GetAppointmentType(int id) {
            return await _context.AppointmentTypes.FindAsync(id);
        }

        public async Task<IEnumerable<AppointmentType>> GetAppointmentTypes() {
            return await _context.AppointmentTypes.ToListAsync();
        }

        public async Task UpdateAppointmentType(AppointmentType appointmentType) {
            _context.Update(appointmentType);
            await _context.SaveChangesAsync();
        }
    }
}
