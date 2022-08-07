using Models.Model.PortfolioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel.PortfolioViewModel
{
    public class OtherViewModel
    {
        public SkillViewModel Skills { get; set; }
        public ServiceViewModel Services { get; set; }
        public ToolViewModel Tools { get; set; }
    }
}
