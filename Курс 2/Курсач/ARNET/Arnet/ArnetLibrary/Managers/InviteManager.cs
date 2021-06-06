using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Database;
using Arnet.Managers;
using Arnet.Library;

namespace Arnet.Managers
{
    public class InviteManager
    {
        private readonly ARNETContext db;
        private readonly AgencyManager agencyManager;

        public InviteManager(ARNETContext db, AgencyManager agencyManager)
        {
            this.db = db;
            this.agencyManager = agencyManager;
        }

        public IQueryable<ModeratorInvite> ModeratorInvites { get => db.ModeratorInvites.Where(i => i.DateTo >= DateTime.UtcNow); }
        public IQueryable<CompanyInvite> AgentInvites { get => db.CompanyInvites.Where(i => i.DateTo >= DateTime.UtcNow); }

        /// <summary>
        /// Создаает инвайт для модератора
        /// </summary>
        /// <returns></returns>
        public ModeratorInvite CreateModerInvite()
        {
            ModeratorInvite moderatorInvite = new ModeratorInvite()
            {
                DateTo = DateTime.UtcNow.AddDays(1),
                Md5 = UniqueMd5()
            };

            db.ModeratorInvites.Add(moderatorInvite);
            db.SaveChanges();

            return moderatorInvite;
        }

        /// <summary>
        /// Создает инвайт для агента от компании
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Нет компании с данным id</exception>
        public CompanyInvite CreateAgentInvite(int companyId)
        {
            CompanyInvite agentInvite = null;
            Company company = agencyManager.Companies.First(c => c.CompanyId == companyId);

            agentInvite = new CompanyInvite()
            {
                Company = company,
                DateTo = DateTime.UtcNow.AddDays(1),
                Md5 = UniqueMd5()
            };
            db.CompanyInvites.Add(agentInvite);

            return agentInvite;
        }

        /// <summary>
        /// Удаляет инвайт для агента по ид
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>True - удален, False - с таким ид не найден</returns>
        public bool RemoveAgentInvite(int id)
        {
            CompanyInvite invite = AgentInvites.FirstOrDefault(i => i.InviteId == id);
            if (invite == null)
                return false;

            db.CompanyInvites.Remove(invite);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет инвайт для модератора по ид
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>True - удален, False - с таким ид не найден</returns>
        public bool RemoveModerInvite(int id)
        {
            ModeratorInvite invite = ModeratorInvites.FirstOrDefault(i => i.InviteId == id);
            if (invite == null)
                return false;

            db.ModeratorInvites.Remove(invite);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// удаляет инвайт с данным md5
        /// </summary>
        /// <param name="md5"></param>
        /// <returns></returns>
        public bool RemoveInvite(string md5)
        {
            CompanyInvite agentInvite = AgentInvites.FirstOrDefault(i => i.Md5 == md5);
            if (agentInvite != null)
            {
                RemoveAgentInvite(agentInvite.InviteId);
                return true;
            }

            ModeratorInvite moderatorInvite = ModeratorInvites.FirstOrDefault(i => i.Md5 == md5);
            if (moderatorInvite != null)
            {
                RemoveModerInvite(moderatorInvite.InviteId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Предоставляет md5 строку, гарантированно отсутствующую в инвайтах
        /// </summary>
        /// <returns>md5 строка</returns>
        private string UniqueMd5()
        {
            Md5Generator md5Generator = new Md5Generator();
            string md5 = null;

            do
            {
                md5 = md5Generator.RandomMd5String();
            } while (ModeratorInvites.Any(m => m.Md5 == md5) || AgentInvites.Any(a => a.Md5 == md5));

            return md5;
        }
    }
}
