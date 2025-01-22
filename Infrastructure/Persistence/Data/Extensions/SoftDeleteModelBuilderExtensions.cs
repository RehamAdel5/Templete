using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Data.Extensions
{
    public static class SoftDeleteModelBuilderExtensions
    {
        public static ModelBuilder ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(HasIsActive).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                var param = Expression.Parameter(entityType.ClrType, "entity");
                var prop = Expression.PropertyOrField(param, nameof(HasIsActive.IsActive));
                var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(true)), param);

                entityType.SetQueryFilter(entityNotDeleted);
            }

            return modelBuilder;
        }
    }
}
