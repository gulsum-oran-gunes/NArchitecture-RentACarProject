using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class UpdatedModelResponse
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
