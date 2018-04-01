/*
Boxing & Unboxing:

Stack: limited amount of memory allocated to each thread separately
--> to store values with short lifetime, which are kicked off the stack by runtimke once out of scope
--> value types

Heap: large amount of memory for storing types with longer lifetime --> referecne types

- Boxing: process of converting a value type isntance to an object reference
--> will be stored on the heap instead of the stack

- Unboxing: process of casting an object instance to a value type instance

--> Cox/Unbox is to avoid: performance penalty to create new instances

*/

using System;
using System.Collections.Generic;

namespace Boxing {

    class Program {
        static void Main (string[] args) {

            int num = 10;
            // Boxing
            Object obj = num; 

            // Unboxing
            num = (int)obj;

            // ArrayList is a list of object which can be of different type with implicit Box/Unbox: lose type safety
            // --> at runtime we cannot cast all items to e.g. Integer
            var list = new ArrayList();
            list.Add(5);            
            list.Add("hello");
            list.Add(DateTime.Today);

            // Generic list: type safety
            // no boxing/unboxing
            var anotherList = new List<int>();
            anotherList.Add(5);
        }
    }
}
