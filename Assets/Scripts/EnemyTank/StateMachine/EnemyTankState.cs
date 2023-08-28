public interface EnemyTankState {

    public void OnStateEnter(EnemyTankController tankController);
    public void OnStateExit();
    public void Tick();

}
