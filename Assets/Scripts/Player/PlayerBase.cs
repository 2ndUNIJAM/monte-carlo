using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

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

        public ActionResult ShieldUp()
        {
            var defenceData = data.Defence;
            bool isSuccess = Random.Range(0f, 1f) < defenceData.Probability;

            if (isSuccess)
                Defence += data.Defence.DefenceAmount;

            return new ActionResult()
            {
                IsSuccess = isSuccess,
                Target = isSuccess ? CharacterType.Player : CharacterType.None,
                Result = isSuccess ? ResultType.GetShield : ResultType.None,
                Value = isSuccess ? defenceData.DefenceAmount : 0,
            };
        }

        public ActionResult HealHP()
        {
            var healData = data.Heal;
            bool isSuccess = Random.Range(0f, 1f) < healData.Probability;

            if (isSuccess)
                Hp += healData.HealAmount;

            return new ActionResult()
            {
                IsSuccess = isSuccess,
                Target = isSuccess ? CharacterType.Enemy : CharacterType.None,
                Result = isSuccess ? ResultType.GetDamage : ResultType.None,
                Value = isSuccess ? healData.HealAmount : 0,
            };
        }

        public ActionResult AttackAction()
        {
            var attackData = data.Attack;
            bool isSuccess = Random.Range(0f, 1f) < attackData.Probability;
            return new ActionResult()
            {
                IsSuccess = isSuccess,
                Target = isSuccess ? CharacterType.Enemy : CharacterType.None,
                Result = isSuccess ? ResultType.GetDamage : ResultType.None,
                Value = isSuccess ? attackData.Damage : 0,
            };
        }
    }
}
