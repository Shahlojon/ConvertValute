using ConvertValute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertValute.Controllers
{
    public static class CurrencyState
    {
        public static CurrencyConverter current = new CurrencyConverter(); 
        public static CurrencyConverter prev = new CurrencyConverter();
        public static int i = 0;

    }
}
