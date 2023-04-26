using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Services
{
    public class CinemasServise : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasServise(AppDbContext context) : base(context)
        {
        }
    }
}
