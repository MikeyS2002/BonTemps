using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Utility
{
    public static class Helper
    {
        public static string Klant = "Klant";
        public static string Medewerker = "Medewerker";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Helper.Klant, Text = Helper.Klant },
                new SelectListItem { Value = Helper.Medewerker, Text = Helper.Medewerker }
            };
        }
    }
}
