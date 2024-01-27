using MonteCarlo.Data;
using MonteCarlo.Struct;

namespace MonteCarlo.Player
{
    public class PlayerBase
    {
        public int MaxHp => data.MaxHP;
        public AttackData AttackInfo => data.Attack;
        public DefenceData DefenceInfo => data.Defence;
        public HealData HealInfo => data.Heal;

        public int Hp { get; private set; }
        public float HpRatio => (float)Hp / MaxHp;
        public int Defence { get; private set; }
        public int Heal { get; private set; }

        private readonly PlayerMasterDataModel data;

        public PlayerBase(PlayerMasterDataModel data)
        {
            this.data = data;
            Hp = data.MaxHP;
            Defence = data.Defence.DefenceAmount;
            Heal = data.Heal.HealAmount;
        }

        public void DecreaseHp(int value)
        {
            if (Defence > 0)
            {
                if (Defence >= value) // 방어도가 받는 데미지보다 많을 때
                {
                    Defence -= value;
                    value = 0;
                }
                else // 방어도와 체력 모두 깎여야 할 때
                {
                    value -= Defence;
                    Defence = 0;
                }
            }
            Hp -= value;
        }

        public void addDefence(int value)
        {
            Defence += value;
        }

        public void healHP()
        {
            Hp += data.Heal.HealAmount;
        }
    }
}
