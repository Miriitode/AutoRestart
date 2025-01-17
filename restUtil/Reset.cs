using Il2CppAssets.Scripts.GameCore.HostComponent;
using Il2CppAssets.Scripts.PeroTools.Commons;

namespace restUtil
{
    public static class Reset
    {
        private static TaskStageTarget _tsk;
        public static bool NeedToRestart = false;
        public static int GotGreat => _tsk?.m_GreatResult ?? 0;
        public static int GotMiss => _tsk?.m_MissCombo ?? 0;

        internal static void CheckRestart(string mode)
        {
            if(mode == "AP")
            {
                if (GotGreat > 0 || GotMiss > 0 || Miss.MissPatch.noteMissed)
                {
                    NeedToRestart = true;
                }
            }
            else
            {
                if (GotMiss > 0 || Miss.MissPatch.noteMissed)
                {
                    NeedToRestart = true;
                }
            }
        }

        internal static void Reload()
        {
            _tsk = Singleton<TaskStageTarget>.instance;
            NeedToRestart = false;
            Miss.MissPatch.noteMissed = false;
        }
    }
}
