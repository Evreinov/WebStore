using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; init; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательно")]
        public string LastName { get; init; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; init; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [Display(Name = "Короткое имя")]
        public string ShortName { get; init; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy г.}")]
        public DateTime Birthday { get; init; }
        /// <summary>
        /// Пол
        /// </summary>
        [Display(Name = "Пол")]
        public int Sex { get; init; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        [Display(Name = "Табельный номер")]
        public string Number { get; init; }
        /// <summary>
        /// Телефон внутренний
        /// </summary>
        [Display(Name = "Телефон внутренний")]
        public string InternalPhone { get; init; }
        /// <summary>
        /// Телефон домашний
        /// </summary>
        [Display(Name = "Телефон домашний")]
        public string HomePhone { get; init; }
        /// <summary>
        /// Телефон мобильный
        /// </summary>
        [Display(Name = "Телефон мобильный")]
        public string MobilePhone { get; init; }
        /// <summary>
        /// Телефон рабочий
        /// </summary>
        [Display(Name = "Телефон рабочий")]
        public string BusinessPhone { get; init; }
        /// <summary>
        /// Факс
        /// </summary>
        [Display(Name = "Факс")]
        public string Fax { get; init; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        [RegularExpression(@"(\w+\.)*\w+@(\w+\.)+[A-Za-z]+", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; init; }
        /// <summary>
        /// Путь к фотографии
        /// </summary>
        [Display(Name = "Фотография")]
        public string ImagePath { get; init; }
    }
}
