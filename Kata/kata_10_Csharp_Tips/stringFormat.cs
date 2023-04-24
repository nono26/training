using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace kata_10_Csharp_Tips;

public class stringFormat
{
    public stringFormat()
    {
        var firstname = "Arnaud";
        var lastname = "Martin";

        Console.WriteLine($"Firstname {firstname,-20} lastname {lastname,-10}");
        Console.WriteLine($"Firstname {firstname,20} lastname {lastname,10}");

        var threePartFormat = "(good employee) #;(bad employee) -#; (new employee)";

        var posNumber = 3;
        var negNumber = -3;
        var zeroNumber = 0;

        Console.WriteLine(posNumber.ToString(threePartFormat));
        Console.WriteLine(negNumber.ToString(threePartFormat));
        Console.WriteLine(zeroNumber.ToString(threePartFormat));
    }

}
