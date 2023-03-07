#nullable disable
namespace VisualAcademy.Models {
    public class AppointmentType {
        public int Id { get; set; }
        public string AppointmentTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
