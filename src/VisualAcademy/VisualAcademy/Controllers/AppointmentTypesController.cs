using Microsoft.AspNetCore.Mvc;
using VisualAcademy.Models;
using VisualAcademy.Repositories;

namespace VisualAcademy.Controllers;

public class AppointmentTypesController : Controller {
    private readonly IAppointmentTypeRepositoryAsync _repository;

    // 생성자에서 IAppointmentTypeRepositoryAsync 의존성 주입을 받는다.
    public AppointmentTypesController(IAppointmentTypeRepositoryAsync repository) {
        _repository = repository;
    }

    // 모든 예약 종류를 가져와 Index.cshtml 뷰 페이지를 반환한다.
    // GET: AppointmentTypes
    public async Task<IActionResult> Index() {
        var appointmentTypes = await _repository.GetAppointmentTypes();
        return View(appointmentTypes);
    }

    // 새로운 예약 종류를 추가하는 Create.cshtml 뷰 페이지를 반환한다.
    // GET: AppointmentTypes/Create
    public IActionResult Create() => View();

    // 새로운 예약 종류를 추가한다.
    // AppointmentType 모델 바인딩을 사용하고, ModelState.IsValid 속성을 사용하여 모델 유효성 검사를 수행한다.
    // 추가가 완료되면 Index 페이지로 리디렉션한다.
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

    // 특정 예약 종류 정보를 가져와 Details.cshtml 뷰 페이지를 반환한다.
    // GET: AppointmentTypes/Details/5
    public async Task<IActionResult> Details(int id) {
        var appointmentType = await _repository.GetAppointmentType(id);
        if (appointmentType == null) {
            return NotFound();
        }
        return View(appointmentType);
    }

    // 특정 예약 종류 정보를 가져와 Edit.cshtml 뷰 페이지를 반환한다.
    // GET: AppointmentTypes/Edit/5
    public async Task<IActionResult> Edit(int id) {
        var appointmentType = await _repository.GetAppointmentType(id);
        if (appointmentType == null) {
            return NotFound();
        }
        return View(appointmentType);
    }

    // 특정 예약 종류 정보를 수정한다.
    // AppointmentType 모델 바인딩을 사용하고, ModelState.IsValid 속성을 사용하여 모델 유효성 검사를 수행한다.
    // 수정이 완료되면 Index 페이지로 리디렉션한다.
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

    // 특정 예약 종류 정보를 가져와 Delete.cshtml 뷰 페이지를 반환한다.
    // GET: AppointmentTypes/Delete/5
    public async Task<IActionResult> Delete(int id) {
        var appointmentType = await _repository.GetAppointmentType(id);
        if (appointmentType == null) {
            return NotFound();
        }

        return View(appointmentType);
    }

    // 특정 예약 종류 정보를 삭제한다.
    // 삭제가 완료되면 Index 페이지로 리디렉션한다.
    // POST: AppointmentTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _repository.DeleteAppointmentType(id);
        return RedirectToAction(nameof(Index));
    }
}
