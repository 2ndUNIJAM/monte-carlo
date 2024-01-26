namespace MonteCarlo.Player
{
    public class PlayerBase
    {
        public readonly int maxHp;
        public int hp;

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
            hp -= value;
        }
    }
}
