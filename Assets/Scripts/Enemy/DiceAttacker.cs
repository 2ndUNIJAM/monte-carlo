using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class DiceAttacker : EnemyAction
    {
        public override float Probability => 1;

        private readonly DiceAttackData data;

        public DiceAttacker(DiceAttackData data)
        {
            this.data = data;
        }

        public override ActionResult Execute()
        {
            var randNum = Random.Range(0, 6);

            return new ActionResult()
            {
                IsSuccess = true,
                Target = CharacterType.Player,
                Result = ResultType.GetDamage,
                Value = data.Damages[randNum],
            };
        }
    }
}
