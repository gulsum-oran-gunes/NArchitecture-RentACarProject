using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos
{
    public class DeletedCarResponse
    {
        public  int Id { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
