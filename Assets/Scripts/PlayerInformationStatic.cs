using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInformationStatic
{
    private static string _playerHero = "Man";

    public static string PrefabHero
    {
        get
        {
            return _playerHero;
        }
        set
        {
            _playerHero = value;
        }
    }
}
