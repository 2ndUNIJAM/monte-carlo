using MonteCarlo.Data;

namespace MonteCarlo.Enemy
{
    public class EnemyBase
    {
        public int MaxHp => data.MaxHP;

        public int Hp { get; private set; }
        public float HpRatio => (float)Hp / MaxHp;

        private readonly EnemyMasterDataModel data;

        public EnemyBase(EnemyMasterDataModel data)
        {
            Hp = data.MaxHP;
        }

        public void DecreaseHp(int value)
        {
            Hp -= value;
        }
    }
}
