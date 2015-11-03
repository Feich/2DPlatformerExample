public interface IState
{
    void OnUpdate(SimplePlayerController fsm);
    void OnEnter(SimplePlayerController fsm);
    void OnExit(SimplePlayerController fsm);
}
