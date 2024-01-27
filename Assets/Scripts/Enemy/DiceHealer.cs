using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class DiceHealer : EnemyAction
    {
        public override float Probability => 1;

        private readonly DiceHealData data;

        public DiceHealer(DiceHealData data)
        {
            this.data = data;
        }

        public override ActionResult Execute()
        {
            var randNum = Random.Range(0, 6);

            return new ActionResult()
            {
                IsSuccess = true,
                Target = CharacterType.Enemy,
                Result = ResultType.GetHeal,
                Value = data.Amounts[randNum],
            };
        }
    }
}
