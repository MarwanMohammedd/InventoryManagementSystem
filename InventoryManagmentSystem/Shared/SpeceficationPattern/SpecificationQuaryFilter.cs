using System.Linq.Expressions;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.SpeceficationPattern;

public static class SpecificationQuaryFilter
{
    public static IQueryable<T> GetQuary<T>(
     IQueryable<T> inputQuary,
     ISpecification<T> specification
    )
    {
        var quary = inputQuary;
        if (specification.Criteria is not null)
        {
            quary = quary.Where(specification.Criteria);
        }
        return quary;
    }

}