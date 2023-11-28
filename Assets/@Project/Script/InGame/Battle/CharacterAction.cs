
public class CharacterAction
{
    public PlayerAction Attack;
    public PlayerAction CriticalAttack;
    public PlayerAction TakeHit;
    public PlayerAction HoverAttack;
    public PlayerAction Death;
    public PlayerAction Kill;
    
    public struct PlayerAction
    {
        public delegate void ActionEvent();

        private ActionEvent _onAction;

        private event ActionEvent OnAction
        {
            add
            {
                _onAction -= value;
                _onAction += value;
            }
            remove => _onAction -= value;
        }

        public void AddListener(ActionEvent action)
        {
            OnAction += action;
        }

        public void RemoveListener(ActionEvent action)
        {
            OnAction -= action;
        }

        public void Action()
        {
            _onAction?.Invoke();
        }
    }
    
    public struct PlayerActionRef<T>
    {
        public delegate void ActionEvent(ref T param);

        private ActionEvent _onAction;

        private event ActionEvent OnAction
        {
            add
            {
                _onAction -= value;
                _onAction += value;
            }
            remove => _onAction -= value;
        }

        public void AddListener(ActionEvent action)
        {
            OnAction += action;
        }

        public void RemoveListener(ActionEvent action)
        {
            OnAction -= action;
        }

        public void Action(ref T param)
        {
            _onAction?.Invoke(ref param);
        }
    }
}
