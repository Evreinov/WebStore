using System;

namespace WebStore.Domain.Models
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
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Телефон внутренний
        /// </summary>
        public string InternalPhone { get; set; }
        /// <summary>
        /// Телефон домашний
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        /// Телефон мобильный
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Телефон рабочий
        /// </summary>
        public string BusinessPhone { get; set; }
        /// <summary>
        /// Факс
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Путь к фотографии
        /// </summary>
        public string ImagePath { get; set; }
    }
}
