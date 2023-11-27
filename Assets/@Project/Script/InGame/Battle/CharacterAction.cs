
public class CharacterAction
{
    public PlayerAction Attack;
    public PlayerAction CriticalAttack;
    public PlayerAction TakeHit;
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
}
