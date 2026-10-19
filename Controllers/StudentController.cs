using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_vasileva.Models;

namespace wt_lab4_4mvc_vasileva.Controllers;

public class StudentController : Controller
{
    // "База данных" в памяти
    private static readonly List<Student> Students = new()
    {
        new Student { Id = 1, FullName = "Иванов Иван Иванович",     Group = "ПИ-21", AverageGrade = 4.5, EnrollmentYear = 2021, Email = "ivanov@univ.ru" },
        new Student { Id = 2, FullName = "Петрова Анна Сергеевна",   Group = "ПИ-21", AverageGrade = 4.8, EnrollmentYear = 2021, Email = "petrova@univ.ru" },
        new Student { Id = 3, FullName = "Смирнов Дмитрий Олегович", Group = "ПИ-22", AverageGrade = 4.2, EnrollmentYear = 2022, Email = "smirnov@univ.ru" },
        new Student { Id = 4, FullName = "Кузнецова Мария Игоревна", Group = "ПИ-22", AverageGrade = 4.9, EnrollmentYear = 2022, Email = "kuznetsova@univ.ru" },
        new Student { Id = 5, FullName = "Попов Артём Владимирович", Group = "ПИ-23", AverageGrade = 3.8, EnrollmentYear = 2023, Email = "popov@univ.ru" }
    };

    // GET: /Student
    public IActionResult Index()
    {
        return View(Students);
    }

    // GET: /Student/Details/1
    public IActionResult Details(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
        // GET: /Student/Create
    public IActionResult Create()
    {
        return View();
    }
    

        // POST: /Student/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        student.Id = Students.Any() ? Students.Max(s => s.Id) + 1 : 1;
        Students.Add(student);
        return RedirectToAction("Index");
    }
        // GET: /Student/Edit/1
    public IActionResult Edit(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            return NotFound();

        return View(student);
    }

    // POST: /Student/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        var existing = Students.FirstOrDefault(s => s.Id == id);
        if (existing == null)
            return NotFound();

        existing.FullName = student.FullName;
        existing.Group = student.Group;
        existing.AverageGrade = student.AverageGrade;
        existing.EnrollmentYear = student.EnrollmentYear;
        existing.Email = student.Email;

        return RedirectToAction("Index");
    }

    // POST: /Student/Delete/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
            Students.Remove(student);

        return RedirectToAction("Index");
    }
}