using System.ComponentModel.DataAnnotations;

namespace ABTest.API.Models
{
    public class Client
    {
        [Key]
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public Guid ClientId { get; set; }
        public Experiment Experiment { get; set; }

    }
}
