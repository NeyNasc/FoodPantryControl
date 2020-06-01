namespace br.com.ustj.FoodPantryControl.Application.Repositories.Item
{
    public interface IItemWriteOnlyRepository
    {
        void Add(params Domain.Item.Item[] items);

        void Delete(Domain.Item.Item item);

        void Update(Domain.Item.Item item);
    }
}
