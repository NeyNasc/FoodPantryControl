using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Repositories;
using br.com.ustj.FoodPantryControl.Application.Repositories.Item;
using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.GetAll
{
    public class GetAllItemUseCase : IGetAllItemUseCase
    {
        private readonly IOutputPort<List<Domain.Item.Item>> outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly  IItemReadOnlyRepository itemReadOnlyRepository;

        public GetAllItemUseCase(IOutputPort<List<Domain.Item.Item>> output,
            ILogWriteOnlyRepository logwrite,
            IItemReadOnlyRepository itemReadeRepo
            )
        {
            this.outputPort = output;
            this.logWriteOnlyRepository = logwrite;
            this.itemReadOnlyRepository = itemReadeRepo;
        }

        public void Execute(GetAllItemRequest request)
        {
            try
            {
                request.AddLog($"Pegando todos os dados de Item do banco", TypeLog.Process);

                var items = itemReadOnlyRepository.GetAllItemRepository();

                outputPort.Standard(items);
            }
            catch (Exception ex)
            {
                request.AddLog($"Erro ao executar o metodo GetAll: {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Erro ao executar o caso de uso GetAll: {ex.Message}, stacktrace: {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs.ToArray());
            }
        }
    }
}
