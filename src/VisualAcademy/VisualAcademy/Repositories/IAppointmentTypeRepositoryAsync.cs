using System.Collections.Generic;
using System.Threading.Tasks;
using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    public interface IAppointmentTypeRepositoryAsync {
        Task<IEnumerable<AppointmentType>> GetAppointmentTypes();
        Task<AppointmentType> GetAppointmentType(int id);
        Task AddAppointmentType(AppointmentType appointmentType);
        Task UpdateAppointmentType(AppointmentType appointmentType);
        Task DeleteAppointmentType(int id);
    }
}
