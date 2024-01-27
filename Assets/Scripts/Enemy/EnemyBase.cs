namespace MonteCarlo.Enemy
{
    public class EnemyBase
    {
        public readonly int maxHp;
        public int hp;
        public float HpRatio => (float)hp / maxHp;

        public EnemyBase(int maxHp)
        {
            this.maxHp = maxHp;
            this.hp = maxHp;
        }

        public void decreaseHp(int value)
        {
            hp -= value;
        }
    }
}
