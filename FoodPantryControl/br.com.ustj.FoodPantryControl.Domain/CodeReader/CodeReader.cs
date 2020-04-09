namespace br.com.ustj.FoodPantryControl.Domain.CodeReader
{
    public class CodeReader
    {
        public string BarCodeNumber { get; set; }

        public CodeReader(string barCodeNumber)
        {
            this.BarCodeNumber = barCodeNumber;
        }
    }
}
