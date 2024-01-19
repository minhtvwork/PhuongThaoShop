
namespace PTS.Domain.Entities
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreationTime {  get; set; }
        public bool IsDeleted { get; set; }
        public int? Status { get; set; }
    }
}
