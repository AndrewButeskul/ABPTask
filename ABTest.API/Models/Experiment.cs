using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABTest.API.Models
{
    public class Experiment
    {
        [Key]
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
