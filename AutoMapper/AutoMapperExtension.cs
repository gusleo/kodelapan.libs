using AutoMapper;

namespace Kodelapan.Libs.AutoMapperExtension
{
    /// <summary>
    /// This is custom AutoMapper extension
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Ignore all properties on model which is not mapped
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="expression"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression, IProfileExpression profile)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            TypeMap existingMaps = null;
            profile.ForAllMaps((map, expr) =>
            {
                if ( map.SourceType.Equals(sourceType) && map.DestinationType.Equals(destinationType) )
                {
                    existingMaps = map;
                }
            });

            if(existingMaps != null )
            {
                foreach ( var property in existingMaps.GetUnmappedPropertyNames() )
                {
                    expression.ForMember(property, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
    
}
