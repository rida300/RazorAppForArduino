using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace RazorAppForArduino
{
    public class OptimalBoost
    {
        /// <summary>
        /// id for each entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Corresponding voltage to each Psi
        /// </summary>
       [Required]
        public double CorrespondingVoltage { get; set; }

        /// <summary>
        /// Psi value
        /// </summary>
       [Required]
        public double Psi { get; set; }
    }
}
