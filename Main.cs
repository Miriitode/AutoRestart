using MelonLoader;
using UnityEngine;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.UI.Controls;
namespace AutoRestart
{
    public class Main : MelonMod
    {
        private MelonPreferences_Category _category;
        private MelonPreferences_Entry<bool> _autoRestart;
        private MelonPreferences_Entry _toggleKeybind;
        private MelonPreferences_Entry<string> _restartMode;
        private MelonPreferences_Entry _modeKeybind;

        private bool _isBattleScene;
        public override void OnInitializeMelon()
        {
            _category = MelonPreferences.CreateCategory("AutoRestart");
            _autoRestart = _category.CreateEntry("Enable AutoRestart", true, "Enables or disables autorestart");
            _toggleKeybind = _category.CreateEntry("Toggle Enable Key", KeyCode.Backspace, "Key to use to toggle AutoRestart");
            _restartMode = _category.CreateEntry("Restart Mode", "FC", "AutoRestart Mode. Valid values are \"AP\", \"FC\".");
            _modeKeybind = _category.CreateEntry("Toggle Mode Key", KeyCode.Delete, "Key to use to toggle between restart modes");

            MelonPreferences.Save();

            base.OnInitializeMelon();

            if (_restartMode.Value != "FC" || _restartMode.Value != "AP")
            {
                LoggerInstance.Msg("Invalid Mode. Resetting to FC mode");
                _restartMode.Value = "FC";
            }

            LoggerInstance.Msg("Mod Loaded!"); 
        }
        public override void OnUpdate()
        {

        if(Input.GetKeyDown((KeyCode)_toggleKeybind.BoxedValue))
            {
                _autoRestart.Value = !_autoRestart.Value;

                if (!_autoRestart.Value)
                {
                    ShowText.ShowInfo("AutoRestart Disabled!");
                }
                else
                {
                    ShowText.ShowInfo("AutoRestart Enabled!");
                }
            }

        if(Input.GetKeyDown((KeyCode)_modeKeybind.BoxedValue))
            {
                if(_restartMode.Value == "FC")
                {
                    _restartMode.Value = "AP";
                    ShowText.ShowInfo("AutoRestart set to AP Mode");
                }
                else if(_restartMode.Value == "AP")
                {
                    _restartMode.Value = "FC";
                    ShowText.ShowInfo("AutoRestart set to FC Mode");
                }
            }

        if (_autoRestart.Value)
            {
                if (!_isBattleScene) return;

                if (!restUtil.Reset.NeedToRestart)
                {
                    restUtil.Reset.CheckRestart((string)_restartMode.BoxedValue);
                }
                else
                {
                    BattleHelper.GameRestart();
                }
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (restUtil.Reset.NeedToRestart)
            {
                if(_restartMode.Value == "FC")
                {
                    ShowText.ShowInfo("AP lost, Try Again...");
                }
                else if (_restartMode.Value == "AP")
                {
                    ShowText.ShowInfo("FC lost, Try Again...");
                }
            }

            _isBattleScene = sceneName == "GameMain";
            restUtil.Reset.Reload();

            base.OnSceneWasLoaded(buildIndex, sceneName);
        }
    }
}
