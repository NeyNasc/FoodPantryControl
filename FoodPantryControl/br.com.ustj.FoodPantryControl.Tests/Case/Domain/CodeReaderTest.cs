using br.com.ustj.FoodPantryControl.Domain.CodeReader;
using System;
using Xunit;

namespace br.com.ustj.FoodPantryControl.Tests.Case.Domain
{
    public class CodeReaderTest
    {

        [Fact]
        public void ShouldCreateValid()
        {
            var model = new CodeReader("2222222111");
            Assert.True(!String.IsNullOrEmpty(model.BarCodeNumber));
        }
    }
}
