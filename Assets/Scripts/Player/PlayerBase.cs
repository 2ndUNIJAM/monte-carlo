namespace MonteCarlo.Player
{
    public class PlayerBase
    {
        public readonly int maxHp;
        public int hp;
        public int damage;
        public int defence;
        public int heal;

        public int PlayerChanceNumerator;

        public PlayerBase(int maxHp)
        {
            this.maxHp = maxHp;
            this.hp = maxHp;
        }

        public float getHpRatio()
        {
            return (float)hp / maxHp;
        }

        public void decreaseHp(int value)
        {
            if (defence > 0)
            {
                if (defence >= value) // 방어도가 받는 데미지보다 많을 때
                {
                    defence -= value;
                    value = 0;
                }
                else // 방어도와 체력 모두 깎여야 할 때
                {
                    value -= defence;
                    defence = 0;
                }
            }
            hp -= value;
        }

        public void addDefence(int value)
        {
            defence += value;
        }

        public void healHP()
        {
            hp += heal;
        }

    }
}
