using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Web.Models.Agency
{
    public class InfoViewModel
    {
        [Display(Name ="Название агенства")]
        public string AgencyName { get; set; }

        [Display(Name ="Количество агентов")]
        public int AgentCount { get; set; }

        [Display(Name="Продано")]
        public int SoldCount { get; set; }

        public bool IsOwner { get; set; }
    }
}
