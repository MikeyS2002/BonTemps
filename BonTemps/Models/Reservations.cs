using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [ReservationDate(ErrorMessage = "Je kan 1 dag van tevoren reserveren")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Tijdsblok")]
        public string Time { get; set; }

  
        [Display(Name = "Personen")]
        [Range(4, 50, ErrorMessage = "Er kunnen tussen de {1} en {2} personen gereserveerd worden")]
        public int Persons { get; set; }

        [Required]
        [Display(Name = "Locatie")]
        public string Location { get; set; }

        [Display(Name = "Opmerking (Optioneel)")]
        public string Comment { get; set; }

        //Factuuren *Optioneel*
        [Display(Name = "Kvk-Nummer")]
        public string KvkNumber { get; set; }
        [Display(Name = "BTW-Nummer")]
        public string VatNumber { get; set; }
        [Display(Name = "Adress")]
        public string Address { get; set; }
        [Display(Name = "Postcode")]
        public string PostalCode { get; set; }
        [Display(Name = "Bedrag")]
        public double Price { get; set; }
        [Display(Name = "Dienst")]
        public string Service { get; set; }


    }
}
