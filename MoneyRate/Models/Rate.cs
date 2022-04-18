using System.ComponentModel.DataAnnotations;

namespace MoneyRate.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        [Required]                       //обязательное заполнение этого поля 
        public string CountryName { get; set; }

        public int CountryRate { get; set; }

        public string CurrencyName { get; set; }
    }
}
