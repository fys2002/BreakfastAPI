using BreakfastAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BreakfastAPI.Services
{
    public class BreakfastService
    {
        private readonly List<Breakfast> _breakfasts;

        public BreakfastService()
        {
            _breakfasts = new List<Breakfast>
            {
                new Breakfast { Id = 1, Name = "Pancakes", Description = "Fluffy pancakes with syrup", Price = 5.99 },
                new Breakfast { Id = 2, Name = "Waffles", Description = "Crispy waffles with berries", Price = 6.99 }
            };
        }

        public IEnumerable<Breakfast> GetAll() => _breakfasts;

        public Breakfast GetById(int id) => _breakfasts.FirstOrDefault(b => b.Id == id);

        public void Add(Breakfast breakfast)
        {
            breakfast.Id = _breakfasts.Max(b => b.Id) + 1;
            _breakfasts.Add(breakfast);
        }

        public void Update(Breakfast breakfast)
        {
            var existingBreakfast = GetById(breakfast.Id);
            if (existingBreakfast != null)
            {
                existingBreakfast.Name = breakfast.Name;
                existingBreakfast.Description = breakfast.Description;
                existingBreakfast.Price = breakfast.Price;
            }
        }

        public void Delete(int id)
        {
            var breakfast = GetById(id);
            if (breakfast != null)
            {
                _breakfasts.Remove(breakfast);
            }
        }
    }
}