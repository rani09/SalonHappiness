using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Enums
{
    public enum OpenOrCloseType
    {
        [Display(Name = "Åbent")]
        Open,
        [Display(Name = "Lukket")]
        Close
    }
}