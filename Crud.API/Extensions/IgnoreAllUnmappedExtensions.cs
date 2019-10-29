using AutoMapper;

namespace Crud.API
{
    static class IgnoreAllUnmappedExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllUnmapped<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            expression.ForAllMembers(o => o.Ignore());

            return expression;
        }
    }
}
