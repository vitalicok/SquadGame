namespace SquadGame.Api.Base.Models
{
    public class PaginatedResult<TEntity>
    {
        public long Total { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
    }
}
