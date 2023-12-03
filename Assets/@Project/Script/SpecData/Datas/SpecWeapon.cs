

public class SpecWeapon
{
    public int fieldID;
    public int grade;
    public float coolDown;
    public float damage;
    public int projectileID;

    public SpecWeapon(int fieldID, int grade, float coolDown, float damage, int projectileID)
    {
        this.fieldID = fieldID;
        this.grade = grade;
        this.coolDown = coolDown;
        this.damage = damage;
        this.projectileID = projectileID;
    }
}
