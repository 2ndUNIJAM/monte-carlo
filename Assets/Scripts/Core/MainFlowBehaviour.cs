using MonteCarlo.Player;
using UnityEngine;

namespace MonteCarlo.Core
{
    // TODO: singleton.
    public class MainFlowBehaviour : MonoBehaviour
    {
        private TurnStateMachine turn;
        private PlayerBase player;

        void Awake()
        {
            turn = new TurnStateMachine();
            player = new PlayerBase();
        }

        void Update()
        {

        }
    }
}
