

public class SpecWeapon
{
    public int fieldID;
    public int grade;
    public float coolDown;
    public float value;
    public float subValue;
    public int projectileID;

    public Enum_EffectType effectType;

    public SpecWeapon(int fieldID, int grade, float coolDown, float value, float subValue, int projectileID,Enum_EffectType effectType)
    {
        this.fieldID = fieldID;
        this.grade = grade;
        this.coolDown = coolDown;
        this.value = value;
        this.subValue = subValue;
        this.projectileID = projectileID;
        this.effectType = effectType;
    }
}
