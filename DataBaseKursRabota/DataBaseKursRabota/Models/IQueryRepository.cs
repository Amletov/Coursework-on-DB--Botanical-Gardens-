namespace DataBaseKursRabota.Models
{
    public interface IQueryRepository
    {
        IEnumerable<Dictionary<string, object>> Query(int number);
    }
}
