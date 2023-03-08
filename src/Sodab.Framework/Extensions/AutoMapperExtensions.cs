using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sodab.Framework.Common;

namespace Sodab.Framework.Extensions;

public static class AutoMapperExtensions
{
    private static IMapper Mapper => ServiceLocator.GetService<IMapper>();

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static T MapTo<T>(this object obj)
    {
        return Mapper.Map<T>(obj);
    }

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static IEnumerable<T> MapTo<T>(this IEnumerable<object> obj)
    {
        return Mapper.Map<IEnumerable<T>>(obj);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj">  </param>
    /// <param name="dest"> </param>
    public static void Map<T>(this object obj, T dest)
    {
        Mapper.Map(obj, dest);
    }
}