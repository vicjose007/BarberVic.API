﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.Base;

namespace BarberVic.Domain.BaseModel.BaseEntity
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
