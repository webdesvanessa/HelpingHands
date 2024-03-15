using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpingHands
{
    public class WorkerProfile_CLASS
    {
        public int Id { get; set; }
        
        [Required]        
        public string? Name { get; set; }
        
        public string? Bio { get; set; }        
        
        public string? Handle { get; set; }

        public string? Location { get; set; }

        public string? Tags { get; set; }
    }
}
