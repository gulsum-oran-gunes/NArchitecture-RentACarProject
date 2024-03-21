using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Dtos
{
    public class DeletedCarImageResponse
    {
        public int Id { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
