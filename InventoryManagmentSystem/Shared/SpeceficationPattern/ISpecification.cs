using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace InventoryManagmentSystem.Shared.SpeceficationPattern;

public interface ISpecification<T>
{
    public Expression<Func<T , bool>> Criteria { get; }
}
