﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Test.Models
{
    internal class CountryInfo : PlaceInfo 
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
