using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_vasileva.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите ФИО")]
    [Display(Name = "ФИО")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите группу")]
    [Display(Name = "Группа")]
    public string Group { get; set; } = string.Empty;

    [Range(0, 5, ErrorMessage = "Средний балл должен быть от 0 до 5")]
    [Display(Name = "Средний балл")]
    public double AverageGrade { get; set; }

    [Range(2000, 2100, ErrorMessage = "Год поступления в диапазоне 2000–2100")]
    [Display(Name = "Год поступления")]
    public int EnrollmentYear { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Некорректный email")]
    public string Email { get; set; } = string.Empty;
}