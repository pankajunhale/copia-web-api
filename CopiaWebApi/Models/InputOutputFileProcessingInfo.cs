namespace CopiaWebApi.Models
{
    public class InputOutputFileProcessingInfo
    {
        public string[] InputFileHeaderData { get; set; } = new string[] { };

        public List<InputFileRowInfo> InputFileRowData { get; set; } = new List<InputFileRowInfo>();

        public List<InputOutputMappingInfo> MappingInfo { get; set; } = new List<InputOutputMappingInfo>();
    }
}
