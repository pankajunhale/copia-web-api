namespace CopiaWebApi.Models
{
    public class InputFileRowInfo
    {
        public InputFileRowInfo(List<InputFileDataModel>  rows) {
            Rows = rows;
        }
        public List<InputFileDataModel> Rows { get; set; }
    }
}
