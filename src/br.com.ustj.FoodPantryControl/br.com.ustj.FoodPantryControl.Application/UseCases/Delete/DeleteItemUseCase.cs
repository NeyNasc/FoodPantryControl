using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Boudaries.Item;
using br.com.ustj.FoodPantryControl.Application.Repositories;
using br.com.ustj.FoodPantryControl.Application.Repositories.Item;
using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;
using System.Linq;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Delete
{
    public class DeleteItemUseCase : IDeleteItemUseCase
    {
        
        private readonly IOutputPort<ItemOutput> outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IItemReadOnlyRepository itemReadOnlyRepository;
        private readonly IItemWriteOnlyRepository itemWriteOnlyRepository;


        public DeleteItemUseCase(IOutputPort<ItemOutput> output, ILogWriteOnlyRepository log,
            IItemReadOnlyRepository read, IItemWriteOnlyRepository write)
        {
            this.outputPort = output;
            this.logWriteOnlyRepository = log;
            this.itemReadOnlyRepository = read;
            this.itemWriteOnlyRepository = write;

        }

        public void Execute(DeleteItemRequest request)
        {
            try
            {
                request.AddLog($"Requisitando objeto de item", TypeLog.Process);
                var item = itemReadOnlyRepository.GetItemRepository(request.BarCode);
                if (item == null)
                    return;

                request.AddLog($"Removendo quantidade do item {item?.Name}", TypeLog.Process);
                item.Quantity -= 1;

                if (item.Quantity < 1)
                {
                    request.AddLog($"Deletando item {item?.Name}", TypeLog.Process);
                    itemWriteOnlyRepository.Delete(item);
                }
                else
                {
                    request.AddLog($"Atualizando item {item.Name} com a nova quantidade {item.Quantity}", TypeLog.Process);
                    itemWriteOnlyRepository.Update(item);
                }

                if (!request.Logs.Any(a => a.TypeLog.Equals(TypeLog.Error)))
                    outputPort.Standard(new ItemOutput(
                        item.Id,
                        item.BarCode,
                        item.Quantity,
                        item.Name,
                        item.ExpirationDate,
                        item.InsertDate));
            }
            catch (Exception ex)
            {
                request.AddLog($"Erro ao executar o metodo Delete: {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Erro ao executar o caso de uso Delete: {ex.Message}, stacktrace: {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs.ToArray());
            }
        }
    }
}
