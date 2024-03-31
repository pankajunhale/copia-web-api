namespace CopiaWebApi.Models
{
    public class OutputFileModel
    {
        public OutputFileModel(int id,string tagName) { 
            Id = id;
            TagName = tagName;
        }
        public int Id { get; set; }
        public string TagName{ get; set; }

    }
}
