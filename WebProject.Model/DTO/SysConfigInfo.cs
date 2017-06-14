using System;
using System.Collections.Generic;

namespace WebProject.Model
{
    public class SysConfigList : QueryPageBase<SysConfigModel>
    {
        public int Id { get; set; }
        public string Search { get; set; }
        public List<SysConfigMenu> Menus { get; set; }
    }
}
