
public struct CurrencyEvent
{
    public Enum_Currency Type;

    private static CurrencyEvent e;

    public static void Trigger(Enum_Currency type)
    {
        e.Type = type;
        
        GameEventManager.TriggerGameEvent(e);
    }
}