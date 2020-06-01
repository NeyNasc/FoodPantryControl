using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Boudaries.Item;
using br.com.ustj.FoodPantryControl.Application.Repositories;
using br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository.RequestHandlers;
using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;
using System.Linq;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository
{
    public class ItemUseCase : IItemUseCase
    {
        private readonly SaveItemHendler saveItemHendler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<ItemOutput> outputPort;

        public ItemUseCase(SaveItemHendler saveItemHendler,
            ILogWriteOnlyRepository logWrite,
            IOutputPort<ItemOutput> output)
        {
            this.saveItemHendler = saveItemHendler;
            this.logWriteOnlyRepository = logWrite;
            this.outputPort = output;
        }
        public void Execute(ItemRequest request)
        {
            try
            {
                saveItemHendler.ProcessRequest(request);

                if (!request.Logs.Any(a => a.TypeLog.Equals(TypeLog.Error)))
                    outputPort.Standard(new ItemOutput(
                        request.ItemRepository.Id,
                        request.ItemRepository.BarCode,
                        request.ItemRepository.Quantity,
                        request.ItemRepository.Name,
                        request.ItemRepository.ExpirationDate,
                        request.ItemRepository.InsertDate));
            }
            catch (Exception ex)
            {
                request.AddLog($"Error on execute Item process: {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on execute ItemOutput process: {ex.Message}, stacktrace: {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs.ToArray());
            }
        }
    }
}
