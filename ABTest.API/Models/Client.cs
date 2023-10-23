using System.ComponentModel.DataAnnotations;

namespace ABTest.API.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public Experiment Experiment { get; set; }

    }
}
