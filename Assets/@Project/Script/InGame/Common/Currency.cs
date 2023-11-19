
public class Currency
{
    private int _amount;
    private int _consumeAmount;
    private int _condition;
    
    public int Amount => _amount;

    public bool TryConsume(int count)
    {
        if (!IsEnough(count))
        {
            return false;
        }
        
        _amount -= count;
        _consumeAmount += count;

        if (_condition != _amount + _consumeAmount)
        {
            
        }
        
        return true;
    }

    public bool IsEnough(int count)
    {
        if (count > _amount)
        {
            return false;
        }

        return true;
    }

    public void Add(int count)
    {
        _condition += count;
        _amount += count;
    }
}
