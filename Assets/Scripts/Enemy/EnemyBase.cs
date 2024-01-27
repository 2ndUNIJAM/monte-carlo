namespace MonteCarlo.Enemy
{
    public class EnemyBase
    {
        public int MaxHp { get; }
        public int Hp { get; private set; }
        public float HpRatio => (float)Hp / MaxHp;

        public EnemyBase(int maxHp)
        {
            MaxHp = maxHp;
            Hp = maxHp;
        }

        public void DecreaseHp(int value)
        {
            Hp -= value;
        }
    }
}
