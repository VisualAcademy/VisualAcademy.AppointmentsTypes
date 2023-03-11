using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    public class AppointmentTypeRepositoryAsync : IAppointmentTypeRepositoryAsync {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeRepositoryAsync(ApplicationDbContext context) => _context = context;

        // AddAppointmentType 메서드는 새로운 예약 종류를 추가하고, 데이터베이스에 변경 사항을 비동기적으로 저장한다.
        public async Task AddAppointmentType(AppointmentType appointmentType) {
            await _context.AppointmentTypes.AddAsync(appointmentType);
            await _context.SaveChangesAsync();
        }

        // DeleteAppointmentType 메서드는 예약 종류를 삭제하고, 데이터베이스에 변경 사항을 비동기적으로 저장한다.
        public async Task DeleteAppointmentType(int id) {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();
        }

        // GetAppointmentType 메서드는 특정 예약 종류를 가져와 비동기적으로 반환한다.
        public async Task<AppointmentType> GetAppointmentType(int id) => await _context.AppointmentTypes.FindAsync(id);

        // GetAppointmentTypes 메서드는 모든 예약 종류를 가져와 컬렉션으로 비동기적으로 반환한다.
        public async Task<IEnumerable<AppointmentType>> GetAppointmentTypes() {
            return await _context.AppointmentTypes.ToListAsync();
        }

        // UpdateAppointmentType 메서드는 예약 종류 정보를 수정하고, 데이터베이스에 변경 사항을 비동기적으로 저장한다.
        public async Task UpdateAppointmentType(AppointmentType appointmentType) {
            _context.Update(appointmentType);
            await _context.SaveChangesAsync();
        }
    }
}
