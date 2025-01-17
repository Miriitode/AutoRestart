using HarmonyLib;
using Il2CppGameLogic;
using Il2CppAssets.Scripts.GameCore.HostComponent;
using Il2CppFormulaBase;
using Il2CppAssets.Scripts.PeroTools.Commons;

namespace Miss
{
    public static class MissPatch
    {
        public static bool noteMissed = false;

        [HarmonyPatch(typeof(GameMissPlay), "MissCube")]
        internal static class MissCheck
        {
            private static void Postfix(int idx)
            {
                int lane = Singleton<BattleEnemyManager>.instance.GetPlayResult(idx);
                var noteData = Singleton<StageBattleComponent>.instance.GetMusicDataByIdx(idx);
                var noteType = noteData.noteData.type;

                if ((lane == 0 || lane == 1) && (noteType == 6 || noteType == 7))
                {
                    noteMissed = true;
                }
            }
        }
    }
}
