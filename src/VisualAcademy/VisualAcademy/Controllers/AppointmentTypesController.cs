using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisualAcademy.Models;
using VisualAcademy.Repositories;

namespace VisualAcademy.Controllers {
    public class AppointmentTypesController : Controller {
        private readonly IAppointmentTypeRepositoryAsync _repository;

        public AppointmentTypesController(IAppointmentTypeRepositoryAsync repository) {
            _repository = repository;
        }

        // GET: AppointmentTypes
        public async Task<IActionResult> Index() {
            var appointmentTypes = await _repository.GetAppointmentTypes();
            return View(appointmentTypes);
        }

        // GET: AppointmentTypes/Create
        public IActionResult Create() {
            return View();
        }

        // POST: AppointmentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentTypeName,IsActive,DateCreated")] AppointmentType appointmentType) {
            if (ModelState.IsValid) {
                await _repository.AddAppointmentType(appointmentType);
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentType);
        }

        // GET: AppointmentTypes/Details/5
        public async Task<IActionResult> Details(int id) {
            var appointmentType = await _repository.GetAppointmentType(id);
            if (appointmentType == null) {
                return NotFound();
            }
            return View(appointmentType);
        }

        // GET: AppointmentTypes/Edit/5
        public async Task<IActionResult> Edit(int id) {
            var appointmentType = await _repository.GetAppointmentType(id);
            if (appointmentType == null) {
                return NotFound();
            }
            return View(appointmentType);
        }

        // POST: AppointmentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentTypeName,IsActive,DateCreated")] AppointmentType appointmentType) {
            if (id != appointmentType.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                await _repository.UpdateAppointmentType(appointmentType);
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentType);
        }

        // GET: AppointmentTypes/Delete/5
        public async Task<IActionResult> Delete(int id) {
            var appointmentType = await _repository.GetAppointmentType(id);
            if (appointmentType == null) {
                return NotFound();
            }

            return View(appointmentType);
        }

        // POST: AppointmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            await _repository.DeleteAppointmentType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
