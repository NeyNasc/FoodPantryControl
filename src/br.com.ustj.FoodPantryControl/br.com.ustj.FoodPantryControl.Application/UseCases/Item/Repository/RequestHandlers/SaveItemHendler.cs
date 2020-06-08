using br.com.ustj.FoodPantryControl.Application.Repositories.Item;
using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;
using System.Threading;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository.RequestHandlers
{
    public class SaveItemHendler : Handler<ItemRequest>
    {
        public IItemWriteOnlyRepository ItemWrite;
        public IItemReadOnlyRepository ItemRead;

        public SaveItemHendler(IItemWriteOnlyRepository repos, IItemReadOnlyRepository readRepos)
        {
            this.ItemRead = readRepos;
            this.ItemWrite = repos;
        }

        public override void ProcessRequest(ItemRequest request)
        {
            request.AddLog($"Inserindo produto " + request.ItemRepository.Name + " de ID: " + request.ItemRepository.Id, TypeLog.Process);

            var itemUp = ItemRead.GetItemRepository(request.ItemRepository.BarCode);
            if (itemUp != null)
            {
                itemUp.Quantity += request.ItemRepository.Quantity;
                itemUp.SetNewInsertDate(DateTime.Now);
                ItemWrite.Update(itemUp);

            }
            else
            {
                ItemWrite.Add(request.ItemRepository);
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
