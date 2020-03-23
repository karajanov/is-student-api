using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApp.Extensions
{
    public static class MapperExtension
    {
        /// <summary>
        /// Map a list of objects to a list of other objects
        /// A mapping profile must be enabled beforehand
        /// </summary>
        /// <typeparam name="map destination"></typeparam>
        /// <typeparam name="map source"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="listToMapFrom"></param>
        /// <returns></returns>
        public static IEnumerable<T> MapList<T, X>(this IMapper mapper, IEnumerable<X> listToMapFrom)
            where T : class
            where X : class
        {
            if (listToMapFrom == null || listToMapFrom.ToList().Count == 0)
                return null;

            var mappedList = new List<T>();

            foreach (var item in listToMapFrom)
            {
                var mappedObj = mapper.Map<T>(item);
                mappedList.Add(mappedObj);
            }

            return mappedList;
        }
    }
}
