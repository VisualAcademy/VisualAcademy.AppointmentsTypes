using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    // AppointmentTypeRepository 클래스 생성 구문
    // 이 클래스는 IAppointmentTypeRepository 인터페이스를 구현하여, 
    // AppointmentsTypes 테이블에 대한 데이터 액세스 기능을 구현한다.
    public class AppointmentTypeRepository : IAppointmentTypeRepository {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeRepository(ApplicationDbContext context) => this._context = context;

        // AddAppointmentType 메서드는 새로운 예약 종류를 추가한다.
        // appointmentType 매개변수는 추가할 예약 종류 정보를 담고 있는 객체이다.
        // 데이터베이스에 변경 사항이 저장된다.
        public void AddAppointmentType(AppointmentType appointmentType) {
            _context.AppointmentTypes.Add(appointmentType);
            _context.SaveChanges();
        }

        // DeleteAppointmentType 메서드는 예약 종류를 삭제한다.
        // id 매개변수는 삭제할 예약 종류의 Id 열 값을 나타낸다.
        // 데이터베이스에 변경 사항이 저장된다.
        public void DeleteAppointmentType(int id) {
            var appointmentType = _context.AppointmentTypes.Find(id);
            _context.AppointmentTypes.Remove(appointmentType);
            _context.SaveChanges();
        }

        // GetAppointmentType 메서드는 특정 예약 종류를 가져온다.
        // id 매개변수는 가져올 예약 종류의 Id 열 값을 나타낸다.
        // 예약 종류 객체가 반환된다.
        public AppointmentType GetAppointmentType(int id) => _context.AppointmentTypes.Find(id);

        // GetAppointmentTypes 메서드는 모든 예약 종류를 가져온다.
        // 예약 종류 컬렉션이 반환된다.
        public IEnumerable<AppointmentType> GetAppointmentTypes() => _context.AppointmentTypes.ToList();

        // UpdateAppointmentType 메서드는 예약 종류 정보를 수정한다.
        // appointmentType 매개변수는 수정할 예약 종류 정보를 담고 있는 객체이다.
        // 데이터베이스에 변경 사항이 저장된다.
        public void UpdateAppointmentType(AppointmentType appointmentType) {
            _context.Update(appointmentType);
            _context.SaveChanges();
        }
    }
}
