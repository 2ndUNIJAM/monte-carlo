using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class RevolverToy : EnemyAction
    {
        public override float Probability => 1 / (float)leftCylinder;

        private readonly RevolverActionData data;
        private int misfireCnt;
        private int leftCylinder => data.cylinderCnt - misfireCnt;

        private bool isFirst = true;
        public RevolverToy(RevolverActionData data)
        {
            this.data = data;
        }

        public override ActionResult Execute()
        {
            if (isFirst)
            {
                SoundManager.Instance.onRevolverRifleClip();
                isFirst = false;
            }
            var isFire = Random.Range(0f, 1f) < Probability;
            if (isFire)
            {
                misfireCnt = 0;
            }
            else
                misfireCnt++;

            return new ActionResult()
            {
                IsSuccess = isFire,
                Target = isFire ? CharacterType.Player : CharacterType.None,
                Result = isFire ? ResultType.GetDamage : ResultType.None,
                Value = isFire ? data.Damage : 0,
            };
        }
    }
}
