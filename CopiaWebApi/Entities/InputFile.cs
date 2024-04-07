using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CopiaWebApi.Entities
{
    public class InputFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Index { get; set; }
        public bool IsHeader { get; set; }

        public InputOutputMapper InputOutputMappers { get; set; }

    }
}


