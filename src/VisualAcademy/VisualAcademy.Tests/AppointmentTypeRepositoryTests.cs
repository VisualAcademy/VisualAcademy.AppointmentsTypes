using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;
using VisualAcademy.Repositories;

namespace VisualAcademy.Tests {
    [TestClass]
    public class AppointmentTypeRepositoryTests {
        private ApplicationDbContext _context;
        private AppointmentTypeRepository _repository;

        [TestInitialize]
        public void Initialize() {
            // In-memory database를 사용해서 테스트
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _repository = new AppointmentTypeRepository(_context);
        }

        [TestCleanup]
        public void Cleanup() {
            // In-memory database를 삭제
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

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

        [TestMethod]
        public void AddAppointmentType_AddsAppointmentType() {
            // Arrange
            var appointmentType = new AppointmentType { AppointmentTypeName = "AppointmentType1", IsActive = true };

            // Act
            _repository.AddAppointmentType(appointmentType);

            // Assert
            Assert.AreEqual(1, _context.AppointmentTypes.Count());
        }

        [TestMethod]
        public void UpdateAppointmentType_UpdatesAppointmentType() {
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
