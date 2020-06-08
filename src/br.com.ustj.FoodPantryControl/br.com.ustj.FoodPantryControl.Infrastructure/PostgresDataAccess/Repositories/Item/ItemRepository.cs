using AutoMapper;
using br.com.ustj.FoodPantryControl.Application.Repositories.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Repositories.Item
{
    public class ItemRepository : IItemWriteOnlyRepository, IItemReadOnlyRepository
    {
        private readonly IMapper mapper;
        public ItemRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public void Add(params Domain.Item.Item[] items)
        {
            using var context = new Context();
            context.Item.AddRange(mapper.Map<Entities.Item.Item[]>(items));
            context.SaveChanges();
        }

        public void Delete(Domain.Item.Item itemObj)
        {
            using var context = new Context();
            context.Item.Remove(mapper.Map<Entities.Item.Item>(itemObj));
            context.SaveChanges();
        }

        public List<Domain.Item.Item> GetAllItemRepository()
        {
            using var context = new Context();
            return mapper.Map<List<Domain.Item.Item>>(context.Item.ToList().OrderByDescending(o=>o.InsertDate));
        }

        public Domain.Item.Item GetItemRepository(string barcode)
        {
            using var context = new Context();
            var repository = context.Item.FirstOrDefault(w=> w.BarCode.Equals(barcode));

            return mapper.Map<Domain.Item.Item>(repository);
        }

        public void Update(Domain.Item.Item item)
        {
            using var context = new Context();
            context.Item.Update(mapper.Map<Entities.Item.Item>(item));
            context.SaveChanges();
        }
    }
}
