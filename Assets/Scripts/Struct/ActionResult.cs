using MonteCarlo.Data;

namespace MonteCarlo.Struct
{
    public struct ActionResult
    {
        // 확률 연출용.
        public bool IsSuccess;

        // 데미지, 실드, 회복 표시용
        public CharacterType Target;
        public ResultType Result;
        public int Value;
    }
}
