using System;

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
        public string FirstName { get; init; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; init; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; init; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        public string ShortName { get; init; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; init; }
        /// <summary>
        /// Пол
        /// </summary>
        public int Sex { get; init; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        public string Number { get; init; }
        /// <summary>
        /// Телефон внутренний
        /// </summary>
        public string InternalPhone { get; init; }
        /// <summary>
        /// Телефон домашний
        /// </summary>
        public string HomePhone { get; init; }
        /// <summary>
        /// Телефон мобильный
        /// </summary>
        public string MobilePhone { get; init; }
        /// <summary>
        /// Телефон рабочий
        /// </summary>
        public string BusinessPhone { get; init; }
        /// <summary>
        /// Факс
        /// </summary>
        public string Fax { get; init; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; init; }
        /// <summary>
        /// Путь к фотографии
        /// </summary>
        public string ImagePath { get; init; }
    }
}
