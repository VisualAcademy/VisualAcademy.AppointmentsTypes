using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Repositores {
    public class AppointmentTypeRepository : IAppointmentTypeRepository {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddAppointmentType(AppointmentType appointmentType) {
            _context.AppointmentTypes.Add(appointmentType);
            _context.SaveChanges();
        }

        public void DeleteAppointmentType(int id) {
            var appointmentType = _context.AppointmentTypes.Find(id);
            _context.AppointmentTypes.Remove(appointmentType);
            _context.SaveChanges();
        }

        public AppointmentType GetAppointmentType(int id) {
            return _context.AppointmentTypes.Find(id);
        }

        public IEnumerable<AppointmentType> GetAppointmentTypes() {
            return _context.AppointmentTypes.ToList();
        }

        public void UpdateAppointmentType(AppointmentType appointmentType) {
            _context.Update(appointmentType);
            _context.SaveChanges();
        }
    }
}
