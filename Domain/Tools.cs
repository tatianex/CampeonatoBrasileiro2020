using System;
using System.Collections.Generic;

namespace Domain
{
    static class Tools
    {
        /*
            Algoritmo de embaralhamento Fisher-Yates
            https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        */
        public static void Shuffle<T>(this IList<T> list)  
        {  
            var rand = new Random();
            var n = list.Count;  

            while (n > 1) 
            {  
                n--;  
                var k = rand.Next(n + 1); 

                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
}    
    