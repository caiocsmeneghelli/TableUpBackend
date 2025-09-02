﻿using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public string Name { get; private set; }

        public MenuCategory(string name)
        {
            Name = name;
        }

    }
}
