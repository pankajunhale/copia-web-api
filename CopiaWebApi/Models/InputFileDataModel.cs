namespace CopiaWebApi.Models
{
    public class InputFileDataModel
    {
        public int Index { get; set; } 
        public string Name { get; set; }
        public string Value { get; set; }
        public InputFileDataModel(int index, string headerName, string value) {
            this.Index = index;
            this.Name = headerName;
            this.Value= value;
        }
    }
}
