using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillDict
{
    // 核爆
    public static readonly List<int> NucCd = new List<int>
    {100, 90, 85, 80, 75, 70, 65, 60, 55, 50};
    public static readonly List<int> NucDamage = new List<int>
    {5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
    public static readonly List<int> NucPrice = new List<int>
    {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

    // 护盾
    public static readonly List<int> ShiCd = new List<int>
    {95, 90, 85, 80, 75, 70, 65, 60, 55, 45};
    public static readonly List<int> Shiduration = new List<int>
    {3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    public static readonly List<int> ShiPrice = new List<int>
    {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

    // 舰队扫雷
    public static readonly List<int> FleetCd = new List<int>
    {90, 85, 80, 75, 70, 65, 60, 55, 50, 45};
    public static readonly List<int> FleetDamage = new List<int>
    {4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
    public static readonly List<int> FleetPrice = new List<int>
    {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

}
