using System.Collections.Generic;
using MonteCarlo.Data;
using MonteCarlo.Struct;

namespace MonteCarlo.Enemy
{
    public class EnemyBase
    {
        public int MaxHp => data.MaxHP;

        public int Hp { get; private set; }
        public float HpRatio => (float)Hp / MaxHp;

        private readonly EnemyMasterDataModel data;
        private readonly List<EnemyAction> actions = new();

        public EnemyBase(EnemyMasterDataModel data)
        {
            this.data = data;
            Hp = data.MaxHP;

            // TODO: 적 종류에 따른 액션 생성해서 넣기.
            actions.Add(new RevolverToy(data.Revolver));
        }

        public void DecreaseHp(int value)
        {
            Hp -= value;
        }

        public ActionResult Execute(int id)
        {
            return actions[0].Execute();
        }
    }
}
