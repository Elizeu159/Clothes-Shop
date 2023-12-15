using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerData
{
    public static Action<int> OnMoneyChanged;

    private static int _money = 9999;

    public static int GetMoneyValue()
    {
        return _money;
    }

    public static void ChangeMoneyValue(int value)
    {
        _money += value;
        OnMoneyChanged(_money);
    }
}
