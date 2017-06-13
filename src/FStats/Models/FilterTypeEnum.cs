using System;

namespace FStats.Models
{
    [Flags]
    public enum FilterTypeEnum
    {
        HW = 1 << 0, //home win
        AW = 1 << 1, //away win
        HW1 = 1 << 2,
        AW1 = 1 << 3,
        HW2 = 1 << 4,
        AW2 = 1 << 5
    }
}
