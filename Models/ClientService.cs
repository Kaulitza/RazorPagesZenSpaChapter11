using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class ClientService
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ClienID")]
        public int ClientID { get; set; }
        public Client Client {get;set;}
        [ForeignKey("ServicesID")]
        public int ServicesID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;


    }
}
