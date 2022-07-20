using System.Threading.Tasks;

namespace TimeSheet.Application.Abstraction
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
