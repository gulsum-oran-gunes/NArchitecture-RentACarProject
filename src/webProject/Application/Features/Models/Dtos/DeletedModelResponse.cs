﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class DeletedModelResponse
    {
       public int Id { get; set; }
        public DateTime DeletedDate { get; set; }   
    }
}
