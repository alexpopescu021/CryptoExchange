﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Domain.Dto;
public class CurrencyGetDto
{
    public string CurrencyCode { get; set; } = string.Empty;
    public bool IsFiat { get; set; }

}
