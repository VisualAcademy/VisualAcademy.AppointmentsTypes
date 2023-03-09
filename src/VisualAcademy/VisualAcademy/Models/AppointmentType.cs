// AppointmentType 클래스 생성 구문
// 이 클래스는 AppointmentsTypes 테이블의 모델을 정의하는 클래스이다.
// #nullable disable은 null 참조를 허용하는 C# 8.0 이전의 문법으로,
// 이 클래스의 모든 프로퍼티는 null 값을 허용하지 않는다.
// Id 프로퍼티는 int 형으로, AppointmentsTypes 테이블의 Id 열과 매핑된다. 이 프로퍼티는 getter와 setter를 모두 가지고 있다.
// AppointmentTypeName 프로퍼티는 string 형으로, AppointmentsTypes 테이블의 AppointmentTypeName 열과 매핑된다. 이 프로퍼티는 getter와 setter를 모두 가지고 있다.
// IsActive 프로퍼티는 bool 형으로, AppointmentsTypes 테이블의 IsActive 열과 매핑된다. 이 프로퍼티는 getter와 setter를 모두 가지고 있다.
// DateCreated 프로퍼티는 DateTime 형으로, AppointmentsTypes 테이블의 DateCreated 열과 매핑된다. 이 프로퍼티는 getter와 setter를 모두 가지고 있다.

#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualAcademy.Models {
    [Table("AppointmentsTypes")]
    public class AppointmentType {
        public int Id { get; set; }
        public string AppointmentTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
