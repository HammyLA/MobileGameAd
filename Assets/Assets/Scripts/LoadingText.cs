using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadingText
{
    private static string[] listStrings =
        {
            "This is a Test String",
            "I made this game",
            "Weapons might be better than more players",
            "Players might be better than more weapons",
            "This is a loading screen",
            "Move using WASD, but W and S don't work",
            "Help I can't see",
            "Kill more enemies",
            "I can't help you",
            "Don't die",
            "You can't get max upgraded gun, it's not possible",
            "Be nice",
            "Dual wielding potentially doubles melee damage output... but prevents any kind of blocking",
            "I made a game like this is middle school, but it was way better",
            "This isn't a tip",
            "You don't need help",
        };

    public static string[] getListString()
    {
        return listStrings;
    }


}
