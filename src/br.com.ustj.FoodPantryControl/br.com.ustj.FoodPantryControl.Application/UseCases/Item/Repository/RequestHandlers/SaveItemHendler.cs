using br.com.ustj.FoodPantryControl.Application.Repositories.Item;
using br.com.ustj.FoodPantryControl.Domain.Enum;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository.RequestHandlers
{
    public class SaveItemHendler : Handler<ItemRequest>
    {
        public IItemWriteOnlyRepository ItemWrite;

        public SaveItemHendler(IItemWriteOnlyRepository repos)
        {
            this.ItemWrite = repos;
        }

        public override void ProcessRequest(ItemRequest request)
        {
            request.AddLog($"Inserindo produto "+ request.ItemRepository.Name+" de ID: "+request.ItemRepository.Id, TypeLog.Process);
            ItemWrite.Add(request.ItemRepository);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
