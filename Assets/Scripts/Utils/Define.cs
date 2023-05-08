namespace Define
{
    public class Hero
    {
        public int id;
        public int hp;
        public int moveSpeed;
        public float power;
        public string imageUrl;
        public string prefabPath;
    }
    
    public class Weapon
    {
        public int id;
        public int lv;
        public float power;
        public int projectileCount;
        public float projectileSpeed;
        public float coolTime;
        public string prefabPath;
        public string imageUrl;
        public string rank;
        public string desc;
        public string levelDesc;
    }

    public class WeaponEnhance
    {
        public int id;
        public int enhanceLv;
        public float power;
    }

    public class Monster
    {
        public int id;
        public int hp;
        public int exp;
        public int projectileCount;
        public float power;
        public string prefabPath;
        public string imageUrl;
    }

    public enum HeroType
    {
        None,
        SwordHero,
        Wizard
    }

    public enum WeaponType
    {
        None,
        Sword,
        Staff,
        Bible,
        FireField,
        Boomerang,
        Max
    }
    public enum MonsterType
    {
        NormalMob = 1,
        ProjectileMob,
        EliteMob,
        Max
    }
}
