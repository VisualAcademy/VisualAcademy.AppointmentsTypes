using VisualAcademy.Models;

namespace VisualAcademy.Repositories {
    // IAppointmentTypeRepository 인터페이스 생성 구문
    // 이 인터페이스는 AppointmentsTypes 테이블에 대한 데이터 액세스 기능을 정의하는 인터페이스이다.
    public interface IAppointmentTypeRepository {
        // GetAppointmentTypes 메서드는 모든 예약 종류를 가져온다.
        IEnumerable<AppointmentType> GetAppointmentTypes();

        // GetAppointmentType 메서드는 특정 예약 종류를 가져온다.
        // id 매개변수는 가져올 예약 종류의 Id 열 값을 나타낸다.
        AppointmentType GetAppointmentType(int id);

        // AddAppointmentType 메서드는 새로운 예약 종류를 추가한다.
        // appointmentType 매개변수는 추가할 예약 종류 정보를 담고 있는 객체이다.
        void AddAppointmentType(AppointmentType appointmentType);

        // UpdateAppointmentType 메서드는 예약 종류 정보를 수정한다.
        // appointmentType 매개변수는 수정할 예약 종류 정보를 담고 있는 객체이다.
        void UpdateAppointmentType(AppointmentType appointmentType);

        // DeleteAppointmentType 메서드는 예약 종류를 삭제한다.
        // id 매개변수는 삭제할 예약 종류의 Id 열 값을 나타낸다.
        void DeleteAppointmentType(int id);
    }
}
