using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    /// <summary>
    /// Сотрудник - продавец
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательно")]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [Display(Name = "Короткое имя")]
        public string ShortName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy г.}")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        [Display(Name = "Пол")]
        public int Sex { get; set; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        [Display(Name = "Табельный номер")]
        public string Number { get; set; }
        /// <summary>
        /// Телефон внутренний
        /// </summary>
        [Display(Name = "Телефон внутренний")]
        public string InternalPhone { get; set; }
        /// <summary>
        /// Телефон домашний
        /// </summary>
        [Display(Name = "Телефон домашний")]
        public string HomePhone { get; set; }
        /// <summary>
        /// Телефон мобильный
        /// </summary>
        [Display(Name = "Телефон мобильный")]
        public string MobilePhone { get; set; }
        /// <summary>
        /// Телефон рабочий
        /// </summary>
        [Display(Name = "Телефон рабочий")]
        public string BusinessPhone { get; set; }
        /// <summary>
        /// Факс
        /// </summary>
        [Display(Name = "Факс")]
        public string Fax { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        [RegularExpression(@"(\w+\.)*\w+@(\w+\.)+[A-Za-z]+", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }
        /// <summary>
        /// Путь к фотографии
        /// </summary>
        [Display(Name = "Фотография")]
        public string ImagePath { get; set; }
    }
}
