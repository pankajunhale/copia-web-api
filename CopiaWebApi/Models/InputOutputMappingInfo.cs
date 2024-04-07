namespace CopiaWebApi.Models
{
    public class InputOutputMappingInfo
    {
        //public InputOutputMappingInfo(int id, int inputFileModelId, int outputFileModelId) { 
        //    Id = id;
        //    InputFileModelId = inputFileModelId;
        //    OutputFileModelId = outputFileModelId;
        //}
        public int Id { get; set; }
        public int InputFileModelId { get; set; }
        public int OutputFileModelId { get; set; }

        public string? HeaderName { get; set; }
        public string? TagName { get; set;}

    }
}
