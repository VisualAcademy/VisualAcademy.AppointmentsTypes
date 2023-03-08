using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;
using VisualAcademy.Repositories;

namespace VisualAcademy.Tests {
    // AppointmentTypeRepositoryTests 클래스 생성 구문
    // 이 클래스는 AppointmentTypeRepository 클래스의 각 메서드에 대한 단위 테스트를 수행한다.
    [TestClass]
    public class AppointmentTypeRepositoryTests {
        private ApplicationDbContext _context;
        private AppointmentTypeRepository _repository;

        // Initialize 메서드는 테스트 전에 수행되며, In-memory database를 설정한다.
        [TestInitialize]
        public void Initialize() {
            // In-memory database를 사용해서 테스트
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _repository = new AppointmentTypeRepository(_context);
        }

        // Cleanup 메서드는 테스트 후에 수행되며, In-memory database를 삭제한다.
        [TestCleanup]
        public void Cleanup() {
            // In-memory database를 삭제
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // GetAppointmentTypes_ReturnsAllAppointmentTypes 메서드는 모든 예약 종류를 가져오는 메서드를 테스트한다.
        [TestMethod]
        public void GetAppointmentTypes_ReturnsAllAppointmentTypes() {
            // Arrange
            _context.AppointmentTypes.Add(new AppointmentType { AppointmentTypeName = "AppointmentType1", IsActive = true });
            _context.AppointmentTypes.Add(new AppointmentType { AppointmentTypeName = "AppointmentType2", IsActive = false });
            _context.SaveChanges();

            // Act
            var appointmentTypes = _repository.GetAppointmentTypes();

            // Assert
            Assert.AreEqual(2, appointmentTypes.Count());
        }

        // GetAppointmentType_ReturnsAppointmentType 메서드는 특정 예약 종류를 가져오는 메서드를 테스트한다.
        [TestMethod]
        public void GetAppointmentType_ReturnsAppointmentType() {
            // Arrange
            _context.AppointmentTypes.Add(new AppointmentType { Id = 1, AppointmentTypeName = "AppointmentType1", IsActive = true });
            _context.SaveChanges();

            // Act
            var appointmentType = _repository.GetAppointmentType(1);

            // Assert
            Assert.AreEqual("AppointmentType1", appointmentType.AppointmentTypeName);
        }

        // AddAppointmentType_AddsAppointmentType 메서드는 새로운 예약 종류를 추가하는 메서드를 테스트한다.
        [TestMethod]
        public void AddAppointmentType_AddsAppointmentType() {
            // Arrange
            var appointmentType = new AppointmentType { AppointmentTypeName = "AppointmentType1", IsActive = true };

            // Act
            _repository.AddAppointmentType(appointmentType);

            // Assert
            Assert.AreEqual(1, _context.AppointmentTypes.Count());
        }

        // UpdateAppointmentType_UpdatesAppointmentType 메서드는 예약 종류 정보를 수정하는 메서드를 테스트한다.
        [TestMethod]
        public void UpdateAppointmentType_UpdatesAppointmentType() {
            #region 단독으로 테스트할 때 사용한 코드 
            //// Arrange
            //_context.AppointmentTypes.Add(new AppointmentType { Id = 1, AppointmentTypeName = "AppointmentType1", IsActive = true });
            //_context.SaveChanges();

            //var appointmentType = new AppointmentType { Id = 1, AppointmentTypeName = "UpdatedAppointmentType1", IsActive = false };

            //// Act
            //_repository.UpdateAppointmentType(appointmentType);

            //// Assert
            //Assert.AreEqual("UpdatedAppointmentType1", _context.AppointmentTypes.Find(1).AppointmentTypeName);
            //Assert.IsFalse(_context.AppointmentTypes.Find(1).IsActive);
            // Arrange 
            #endregion
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateAppointmentType_UpdatesAppointmentType")
                .Options;

            using (var context = new ApplicationDbContext(options)) {
                var repository = new AppointmentTypeRepository(context);
                var appointmentType = new AppointmentType { AppointmentTypeName = "Test Appointment Type", IsActive = true };
                repository.AddAppointmentType(appointmentType);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options)) {
                var repository = new AppointmentTypeRepository(context);
                var appointmentTypeToUpdate = repository.GetAppointmentTypes().First();
                appointmentTypeToUpdate.AppointmentTypeName = "Updated Test Appointment Type";
                // Detach the appointmentTypeToUpdate object from the DbContext
                context.Entry(appointmentTypeToUpdate).State = EntityState.Detached;

                // Act
                repository.UpdateAppointmentType(appointmentTypeToUpdate);

                // Assert
                var updatedAppointmentType = repository.GetAppointmentType(appointmentTypeToUpdate.Id);
                Assert.AreEqual("Updated Test Appointment Type", updatedAppointmentType.AppointmentTypeName);
            }
        }

        // DeleteAppointmentType_DeletesAppointmentType 메서드는 예약 종류를 삭제하는 메서드를 테스트한다.
        [TestMethod]
        public void DeleteAppointmentType_DeletesAppointmentType() {
            // Arrange
            _context.AppointmentTypes.Add(new AppointmentType { Id = 1, AppointmentTypeName = "AppointmentType1", IsActive = true });
            _context.SaveChanges();

            // Act
            _repository.DeleteAppointmentType(1);

            // Assert
            Assert.AreEqual(0, _context.AppointmentTypes.Count());
        }
    }
}
