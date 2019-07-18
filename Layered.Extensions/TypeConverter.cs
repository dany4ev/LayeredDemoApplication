using Layered.EF;
using LayeredDemo.ViewModels;
using System.Collections.Generic;

namespace Layered.Extensions
{
    /// <summary>
    /// All utilities for converting a particular object type to some other type go here
    /// can use automapper mappings extensions here
    /// </summary>
    public static class TypeConverter
    {
        public static PersonVM ConvertTo(this Person person)
        {
            return new PersonVM
            {
                FullName = string.Format("{0} {1}", person.FirstName, person.LastName)
            };
        }

        public static Person ConvertTo(this PersonVM personVM)
        {
            var nameSplitted = personVM.FullName.Split(' ');

            return new Person
            {
                FirstName = nameSplitted[0],
                LastName = nameSplitted[1]
            };
        }

        public static IEnumerable<PersonVM> ConvertTo(this IEnumerable<Person> personList)
        {
            foreach(var person in personList)
            {
                yield return new PersonVM
                {
                    FullName = string.Format("{0} {1}", person.FirstName, person.LastName)
                };
            }
        }
    }
}
