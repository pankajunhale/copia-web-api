namespace CopiaWebApi.Models
{
    public class InputFileDataModel
    {
        public int Index { get; set; }
        public string HeaderName { get; set; }
        public string HeaderValue { get; set; }
        public InputFileDataModel(int index, string headerName, string value) {
            this.Index = index;
            this.HeaderName = headerName;
            this.HeaderValue = value;
        }
    }
}
