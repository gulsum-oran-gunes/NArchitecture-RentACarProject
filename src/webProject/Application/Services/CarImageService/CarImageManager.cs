using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly CarImageBusinessRules _carImageBusinessRules;

        public CarImageManager(ICarImageRepository carImageRepository, CarImageBusinessRules carImageBusinessRules)
        {
            _carImageRepository = carImageRepository;
            _carImageBusinessRules = carImageBusinessRules;
        }

        public async Task Add(IFormFile file, CarImage carImage)
        {
            await _carImageBusinessRules.CheckIfCarImageNull(carImage.CarId);
            await _carImageBusinessRules.CheckIfCarImageFormat(file);
            await _carImageBusinessRules.CheckIfImageLimit(carImage.CarId);
            carImage.ImagePath = FileHelper.Add(file, "CarImages");
            await _carImageRepository.AddAsync(carImage);

        }

        public async Task Delete(CarImage carImage)
        {
            await _carImageBusinessRules.CarImageIdShouldExistsWhenSelected(carImage.Id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync(c => c.Id == carImage.Id).Result.ImagePath;
            var result = FileHelper.Delete(path);
            await _carImageRepository.DeleteAsync(carImage);

        }

        public async Task<CarImage> Get(int id)
        {
            return await _carImageRepository.GetAsync(c => c.Id == id);

        }

        public async Task<List<CarImage>> GetImagesByCarId(int id)
        {

            await _carImageBusinessRules.CarImageCarIdShouldExistsWhenSelected(id);
            return await _carImageBusinessRules.CheckIfCarImageNull(id);
        }

        public async Task<List<CarImage>> GetList()
        {
            return await _carImageRepository.GetAllAsync(include: c => c.Include(c => c.Car));
        }

        public async Task Update(IFormFile file, CarImage carImage)
        {
            await _carImageBusinessRules.CheckIfCarImageFormat(file);
            await _carImageBusinessRules.CheckIfCarImageNull(carImage.CarId);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync(c => c.Id == carImage.Id).Result.ImagePath;
            carImage.ImagePath = FileHelper.Update(path, file, "CarImages");
            await _carImageRepository.UpdateAsync(carImage);
        }
    }

}
