using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopiaWebApi.Entities
{
    public class InputOutputMapper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int InputFileId { get; set; }
        [Required]
        public int OutputFileId { get; set; }

        //Navigation Property
        public InputFile InputFiles { get; }
        public OutputFile OutputFiles { get; }

    }
}
