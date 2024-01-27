namespace MonteCarlo.Data
{
    public enum CommandType
    {
        // 턴엔드
        PlayerTurnEnd = 1,
        EnemyTurnEnd = 2,
        PlayerRollEnd = 3,
        PlayerResultEnd = 4,
        EnemyRollEnd = 5,
        EnemyResultEnd = 6,

        // 플레이어 행동
        PlayerAttack = 101,
        PlayerDefence = 102,
        PlayerHeal = 103,

        // 적 행동
        EnemyRevolverAction = 201,
    }
}
