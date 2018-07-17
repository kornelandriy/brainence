using System.ComponentModel.DataAnnotations;

namespace Brainence.Models
{
    public class SentenceRecordModel
    {
        [Key]
        public int Id { get; set; }

        public string Sentence { get; set; }
        public int WordsCount { get; set; }
    }
}