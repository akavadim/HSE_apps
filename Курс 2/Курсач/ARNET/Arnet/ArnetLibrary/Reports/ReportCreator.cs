using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Arnet.Managers;
using Arnet.Database;

namespace Arnet.Reports
{
    public class ReportCreator
    {
        ARNETContext db;
        AccountManager accountManager;
        AgencyManager agencyManager;
        AgentManager agentManager;

        public ReportCreator(ARNETContext db, AccountManager accountManager, AgencyManager agencyManager, AgentManager agentManager)
        {
            this.db = db;
            this.accountManager = accountManager;
            this.agencyManager = agencyManager;
            this.agentManager = agentManager;
        }

        #region Отчет по новым объявлениям

        public DataTable NewPublishmentsReport()
        {
            DataTable report = new DataTable("Новые объявления");
            report.Columns.Add().ColumnName=" ";
            report.Columns.Add("Агент");
            report.Columns.Add("Обычный пользователь");
            report.Columns.Add("Всего");

            //TODO: сделать нормально
            report.Rows.Add("За день", 0, 0, 0);
            report.Rows.Add("За неделю", 0, 0, 0);
            report.Rows.Add("За месяц", 0, 0, 0);
            report.Rows.Add("За год", 4, 3, 7);
            report.Rows.Add("Все время", 4, 3, 7);

            return report;
        }

        /// <summary>
        /// Создает строку c количеством новых объявлений созданных после указанной даты
        /// в порядке name, Агент, обычный польователь, Всего
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string[] NewPublishmentCreatedAfter(string name, DateTime dateTime)
        {
            throw new NotImplementedException();
            List<string> res = new List<string>();
            int[] values = new int[3];

            values[0] = accountManager.Agents.Where(a => a.DateFrom > dateTime).Count();
            values[1] = accountManager.Agencies.Where(a => a.DateFrom > dateTime).Count();
            values[2] = values[0] + values[1];

            res.Add(name);
            res.AddRange(values.Select(v => v.ToString()));
        }

        #endregion

        #region Отчет по новым пользователям

        public DataTable NewUsersReport()
        {
            DataTable report = new DataTable("Новые пользователи");

            string[] dayAgo = NewUserReportCreatedAfter("За день", DateTime.UtcNow.AddDays(-1));
            string[] weekAgo = NewUserReportCreatedAfter("За неделю", DateTime.UtcNow.AddDays(-7));
            string[] monthsAgo = NewUserReportCreatedAfter("За месяц", DateTime.UtcNow.AddMonths(-1));
            string[] yearAgo = NewUserReportCreatedAfter("За год", DateTime.UtcNow.AddYears(-1));
            string[] allTime = NewUserReportCreatedAfter("Все время", new DateTime());


            report.Columns.Add().ColumnName=" ";
            report.Columns.Add("Агент");
            report.Columns.Add("Агентство");
            report.Columns.Add("Обычный пользователь");
            report.Columns.Add("Модератор");
            report.Columns.Add("Всего");

            report.Rows.Add(dayAgo);
            report.Rows.Add(weekAgo);
            report.Rows.Add(monthsAgo);
            report.Rows.Add(yearAgo);
            report.Rows.Add(allTime);

            return report;
        }

        /// <summary>
        /// Создает строку c количеством пользователей зарегестрированных после указанной даты
        /// в порядке name, Агент, Агенство, Обычный пользователь, Модератор, Всего
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string[] NewUserReportCreatedAfter(string name, DateTime dateTime)
        {
            List<string> res = new List<string>();
            int[] values = new int[5];
            System.Data.SqlTypes.SqlDateTime sqlDateTimeMin = System.Data.SqlTypes.SqlDateTime.MinValue;

            if (dateTime < sqlDateTimeMin.Value)
                dateTime = sqlDateTimeMin.Value;

            values[0] = accountManager.Agents.Where(a => a.DateFrom > dateTime).Count();
            values[1] = accountManager.Agencies.Where(a => a.DateFrom > dateTime).Count();
            values[2] = accountManager.Users.Where(a => a.DateFrom > dateTime).Count();
            values[3] = accountManager.Moderators.Where(a => a.DateFrom > dateTime).Count();
            values[4] = values[0] + values[1] + values[2] + values[3];

            res.Add(name);
            res.AddRange(values.Select(v => v.ToString()));


            return res.ToArray();
        }

        #endregion

        #region Отчет по всем пользователям
        
        public DataTable AllUsersReport()
        {
            DataTable table = new DataTable("Пользователи проекта ARNET");

            table.Columns.Add("Фамилия");
            table.Columns.Add("Имя");
            table.Columns.Add("Отчество");
            table.Columns.Add("Тип аккаунта");
            table.Columns.Add("Дата регистрации");
            table.Columns.Add("Дата закрытия аккаунта");
            table.Columns.Add("Открыто объявлений");
            table.Columns.Add("Закрыто объявлений");
            table.Columns.Add("Телефон");
            table.Columns.Add("Email");
            table.Columns.Add("Агентство");

            foreach(var account in db.Accounts)
            {
                AccountTypesEnum accountType = db.AccountTypes.Find(account.AccountTypeId).Type;
                string middleName = account.MiddleName ?? "-";
                string accountTypeStr = accountType.ToString();
                string dateTo = account.DateTo.ToString() ?? "-";
                string phone = accountManager.Phones.FirstOrDefault(p => p.AccountId == account.AccountId)?.Number??"-";
                string email = accountManager.Emails.FirstOrDefault(e => e.AccountId == account.AccountId)?.Value ?? "-";
                string agencyName = null;

                if (accountType == AccountTypesEnum.Agency)
                {
                    Company agency = agencyManager.Companies.FirstOrDefault(a => a.OwnerId == account.AccountId);
                    if (agency == null)
                    {
                        var agencies = db.Companies.Where(a => a.OwnerId == account.AccountId);
                        var max = agencies.Max(a => a.DateTo);
                        agency = agencies.First(a => a.DateTo == max);
                    }
                    agencyName = agency.Name;

                }
                else if (accountType == AccountTypesEnum.Agent)
                {
                    Agent agent = agentManager.ActiveAgents.FirstOrDefault(a => a.AgentId == account.AccountId);
                    if (agent == null)
                    {
                        var agents = db.Agents.Where(a => a.AccountId == account.AccountId).ToArray();
                        var max = agents.Max(a => a.DateTo);
                        agent = agents.First(a => a.DateTo == max); //TODO: в отдельный метод в AgentManager
                    }
                    agencyName = db.Companies.Find(agent.CompanyId).Name;
                }
                else agencyName = "-";

                table.Rows.Add(account.FirstName, account.SecondName, middleName,   //TODO: количество открытых/закрытых объявлений
                    accountTypeStr, account.DateFrom, dateTo, 0, 0, phone, email, agencyName);
            }

            return table;
        }
        
        #endregion
    }
}
