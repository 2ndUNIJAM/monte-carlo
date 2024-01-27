using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class BoxAction : EnemyAction
    {
        public override float Probability => data.Probability;

        private readonly BoxUnitActionData data;

        public BoxAction(BoxActionData data, int num)
        {
            this.data = data.actions[num];
        }

        public override ActionResult Execute()
        {
            var isSuccess = Random.Range(0f, 1f) < Probability;

            return new ActionResult()
            {
                IsSuccess = isSuccess,
                Target = isSuccess ? data.Target : CharacterType.None,
                Result = isSuccess ? data.Type : ResultType.None,
                Value = isSuccess ? data.Value : 0,
            };
        }
    }
}
