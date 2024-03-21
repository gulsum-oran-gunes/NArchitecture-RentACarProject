using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService
{
    public interface ICarImageService
    {
        Task<List<CarImage>> GetList();
        Task<CarImage> Get(int id);
        Task Add(IFormFile file, CarImage carImage);
        Task Update(IFormFile file, CarImage carImage);
        Task Delete( CarImage carImage);
        Task<List<CarImage>> GetImagesByCarId(int id);
    }
}
