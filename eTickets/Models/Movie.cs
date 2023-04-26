using eTickets.Data.Base;
using eTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; } 
        public string ImageURL { get; set; } = null!;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public MovieCategory MovieCategory { get; set; } 

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; } = null!;

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; } = null!;

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set;} = null!;
    }
}
