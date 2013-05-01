using System;

namespace Loop
{
    public class Loop
    {
        bool valueFound = false;        for (int i = 0; i < 100; i++)         {            Console.WriteLine(array[i]);               //if the value we search is only acceptable when its index is devisible by 10 OK            //elseware we should remove the (i % 10 == 0) check            //because it adds 1 devision operation and one check operation             //and one more check every 10 iterations            //otherwise only 1 check operation            if ((i % 10 == 0) && array[i] == expectedValue)             {                valueFound = true;   	            break;            }         }        if (valueFound)        {            Console.WriteLine("Value Found");        }        // More code here
        
    }
}
