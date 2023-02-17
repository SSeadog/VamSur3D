using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public class Item
    {
        public int id;
        public string name;
    }

    public class Hero
    {
        public string name;
        public int hp;
        public int moveSpeed;
        public float power;
        public string imageUrl;
    }

    public class Weapon
    {
        public int id;
        public float power;
        public int enforce;
        public string imageUrl;
    }

    enum WeaponType
    {
        Sword,
        Staff,
        Bible,
        FireField,
        Boomerang
    }


}
