using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CopiaWebApi.Entities
{
    public class OutputFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TagName { get; set; }
        public InputOutputMapper InputOutputMappers { get; set; } = new InputOutputMapper();
    }
}
