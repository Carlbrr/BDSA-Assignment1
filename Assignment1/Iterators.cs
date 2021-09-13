using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach(IEnumerable<T> x in items){
               foreach(var y in x){
                   yield return y;
               } 
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach(var x in items){
                if(predicate(x)==true){
                    yield return x;
                }
            }
        }
    }
}
