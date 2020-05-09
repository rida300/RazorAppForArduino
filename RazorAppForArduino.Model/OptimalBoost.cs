using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace RazorAppForArduino
{
    public class OptimalBoost
    {
        //[Key]
        public int Id { get; set; }
       [Required]
        public double CorrespondingVoltage { get; set; }
       [Required]
        public double Psi { get; set; }
    }
}
