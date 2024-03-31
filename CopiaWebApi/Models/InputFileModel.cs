namespace CopiaWebApi.Models
{
    public class InputFileModel
    {
        public InputFileModel(int id, string name, int index, bool isHeader) {
            Id = id;
            Name = name; Index = index;
            IsHeader = isHeader;
            Index = index;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public bool IsHeader { get; set; }


    }
}
