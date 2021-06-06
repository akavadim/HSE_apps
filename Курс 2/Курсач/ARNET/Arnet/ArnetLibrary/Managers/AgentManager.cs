using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Database;

namespace Arnet.Managers
{
    public class AgentManager
    {
        private ARNETContext db;

        private AccountManager accountManager;

        public AgentManager(ARNETContext db, AccountManager accountManager)
        {
            this.db = db;
            this.accountManager = accountManager;
            accountManager.AccountClosing += AccountManager_AccountClosing;
        }

        public IEnumerable<Agent> ActiveAgents { get => db.Agents.Where(a => a.DateTo == null || a.DateTo >= DateTime.UtcNow); }


        #region Закрытие агента

        /// <summary>
        /// Закрывает агента и аккаунт связанный с ним
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public bool CloseAgent(int agentId)
        {
            Agent agent = ActiveAgents.FirstOrDefault(a => a.AgentId == agentId);

            if (agent != null)
            {
                return accountManager.CloseAccount(agent.AccountId);
            }
            return false;
        }

        #endregion

        private void AccountManager_AccountClosing(object sender, AccountEventArgs args)
        {
            Account account = args.Account;
            if (accountManager.GetAccountType(account.AccountId) == AccountTypesEnum.Agent)
            {
                Agent agent = ActiveAgents.First(a => a.AccountId == account.AccountId);
                agent.DateTo = DateTime.UtcNow;
                db.SaveChanges();
            }
        }
    }
}
