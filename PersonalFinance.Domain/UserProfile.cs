using System;
using System.Collections.Generic;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain
{
    public static class UserProfile
    {
        public static Currency DefaultCurrency { get; set; } = Currency.RUB;

        public static List<Category> Categories { get; set; }
    }
}
