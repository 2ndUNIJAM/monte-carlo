using System.Collections.Generic;
using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class EnemyBase
    {
        public int MaxHp => data.MaxHP;

        public int Hp { get; private set; }
        public float HpRatio => (float)Hp / MaxHp;

        private readonly EnemyMasterDataModel data;
        private readonly Dictionary<EnemyActionType, EnemyAction> actions = new();

        public EnemyBase(EnemyMasterDataModel data, EnemyActionMasterDataModel actionData)
        {
            this.data = data;
            Hp = data.MaxHP;

            // TODO: 적 종류에 따른 액션 생성해서 넣기.
            foreach (var actionType in data.actionTypes)
            {
                switch (actionType)
                {
                    case EnemyActionType.Revolver:
                        actions.Add(actionType, new RevolverToy(actionData.Revolver));
                        break;
                    case EnemyActionType.DiceAttack:
                        actions.Add(actionType, new DiceAttacker(actionData.DiceAttack));
                        break;
                    case EnemyActionType.DiceHeal:
                        actions.Add(actionType, new DiceHealer(actionData.DiceHeal));
                        break;
                }
            }
        }

        public void DecreaseHp(int value)
        {
            Hp -= value;
        }

        public void IncreateHp(int value)
        {
            Hp += value;
        }

        public ActionResult Execute(EnemyActionType actionType)
        {
            if (actions.TryGetValue(actionType, out var action))
            {
                return action.Execute();
            }
            else
            {
                Debug.LogWarning($"Wrong action for this enemy. actionType - {actionType}");
                return TurnStateMachine.DefaultResult;
            }
        }
    }
}
