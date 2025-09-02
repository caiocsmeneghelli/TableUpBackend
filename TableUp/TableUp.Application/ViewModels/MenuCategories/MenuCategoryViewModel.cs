using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.ViewModels.MenuCategories
{
    public class MenuCategoryViewModel
    {
        public MenuCategoryViewModel(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
        }

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
    }
}
