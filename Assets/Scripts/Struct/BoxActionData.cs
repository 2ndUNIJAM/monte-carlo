using System;
using MonteCarlo.Data;

namespace MonteCarlo.Struct
{
    [Serializable]
    public struct BoxActionData
    {
        public BoxUnitActionData[] actions;
    }

    [Serializable]
    public struct BoxUnitActionData
    {
        public CharacterType Target;
        public ResultType Type;
        public int Value;
        public float Probability;
    }
}
