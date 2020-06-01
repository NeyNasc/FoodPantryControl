using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Delete
{
    public interface IDeleteItemUseCase
    {
        void Execute(DeleteItemRequest request);
    }
}
