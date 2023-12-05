
public enum Enum_ProjectileType
{
    Normal,
    Hover,
    Penetration,
}

public class SpecProjectile
{
    public int fieldID;
    public float speed;
    public int damage;
    public Enum_ProjectileType ProjectileType;

    public SpecProjectile(int fieldID, float speed, int damage, Enum_ProjectileType projectileType)
    {
        this.fieldID = fieldID;
        this.speed = speed;
        this.damage = damage;
        ProjectileType = projectileType;
    }
}
