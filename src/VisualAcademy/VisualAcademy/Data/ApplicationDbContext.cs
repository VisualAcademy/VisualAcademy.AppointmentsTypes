using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Data {
    // ApplicationDbContext 클래스 생성 구문
    // 이 클래스는 EF Core DbContext 클래스를 상속하여, 
    // 데이터베이스 연결과 AppointmentsTypes 테이블을 매핑한다.
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        // AppointmentTypes 프로퍼티는 AppointmentsTypes 테이블과 매핑된 DbSet이다.
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
    }
}
