using Application.Features.Brands.Dtos;
using Application.Features.CarImages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Models
{
    public class CarImageListModel :BasePageableModel
    {
        public IList<GetListCarImageResponse> Items { get; set; }
    }
}
