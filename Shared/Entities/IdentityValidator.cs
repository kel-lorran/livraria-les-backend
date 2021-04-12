using FluentValidation;

namespace Shared
{
    public class IdentityValidator<TEntity, TId> : AbstractValidator<TEntity>
        where TEntity : Identity<TEntity, TId>
    {

    }
}
