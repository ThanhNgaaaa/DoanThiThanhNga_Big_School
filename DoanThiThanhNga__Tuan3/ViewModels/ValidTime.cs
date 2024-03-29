﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DoanThiThanhNga__Tuan3.ViewModels
{
    public class ValidTime:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid= DateTime.TryParseExact(Convert.ToString(value),"HH:mm",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime);
            return isValid;
        }
    }
}