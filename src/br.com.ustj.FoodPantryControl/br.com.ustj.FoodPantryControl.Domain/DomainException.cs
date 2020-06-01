using System;

namespace br.com.ustj.FoodPantryControl.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
           : base(businessMessage)
        {
        }
    }
}
