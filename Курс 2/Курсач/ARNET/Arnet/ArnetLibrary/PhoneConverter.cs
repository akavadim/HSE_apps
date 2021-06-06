using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Arnet.Database;

namespace Arnet.Library
{
    public class PhoneConverter
    {
        public static Regex RussianPhone { get; } = new Regex(@"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$");

        /// <summary>
        /// Пробует преобразовать строку в Phone
        /// </summary>
        /// <param name="phone">номер телефона</param>
        /// <returns>Корректный телефон</returns>
        public static Phone TryCreatePhone(string phone)
        {
            if (phone == null)
                return null;

            Phone phoneClass = null;
            if (RussianPhone.IsMatch(phone))
                phoneClass = CreateRussianPhone(phone);

            return phoneClass;
        }

        /// <summary>
        /// Создает класс Phone с русским номером
        /// </summary>
        /// <param name="phone">Русский номер телефона</param>
        /// <returns>Телефон</returns>
        /// <exception cref="FormatException">Номер не является русским</exception>
        /// <exception cref="ArgumentNullException">Пустая строка</exception>
        private static Phone CreateRussianPhone(string phone)
        {
            if (!RussianPhone.IsMatch(phone))
                throw new FormatException("Это не русский номер");

            Phone res = new Phone();
            res.Number = "+7" + phone.Substring(phone.Length - 10);
            return res;
        }
    }
}
