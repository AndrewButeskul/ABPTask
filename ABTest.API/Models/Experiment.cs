using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABTest.API.Models
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Token { get; set; }

        [ForeignKey(nameof(Token))]
        public Client Client { get; set; }
    }
}
