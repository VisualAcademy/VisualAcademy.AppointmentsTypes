using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    public interface IAppointmentTypeRepository {
        // 출력
        IEnumerable<AppointmentType> GetAppointmentTypes();
        // 상세 
        AppointmentType GetAppointmentType(int id);
        // 입력 
        void AddAppointmentType(AppointmentType appointmentType);
        // 수정 
        void UpdateAppointmentType(AppointmentType appointmentType);
        // 삭제 
        void DeleteAppointmentType(int id);
    }
}
