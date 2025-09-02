using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Enums;

namespace TableUp.Application.ViewModels.MenuCategories
{
    public class MenuCategoryViewModel
    {
        public MenuCategoryViewModel(Guid guid, string name, EStatus status)
        {
            Guid = guid;
            Name = name;
            Status = status;
        }

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public EStatus Status { get; private set; }
    }
}
