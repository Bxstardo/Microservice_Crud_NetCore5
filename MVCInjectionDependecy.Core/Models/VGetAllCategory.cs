﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MVCInjectionDependecy.Core.Models
{
    public partial class VGetAllCategory
    {
        public string ParentProductCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
