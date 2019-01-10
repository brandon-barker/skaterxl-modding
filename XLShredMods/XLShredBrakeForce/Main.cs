using UnityEngine;
using Harmony12;
using System.Reflection;
using UnityModManagerNet;
using System;
using XLShredLib;

namespace XLShredBrakeForce {
    [Serializable]
    public class Settings : UnityModManager.ModSettings {

        public float customBrakeForce = 10f;

        public void IncreaseBrakeForce()
        {
            customBrakeForce += 1f;
            UpdateBrakeForce();
        }

        public void DecreaseBrakeForce()
        {
            customBrakeForce -= 1f;
            UpdateBrakeForce();
        }

        public void UpdateBrakeForce()
        {
            PlayerController.Instance.skaterController.breakForce = customBrakeForce;
        }

        public override void Save(UnityModManager.ModEntry modEntry) {
            UnityModManager.ModSettings.Save<Settings>(this, modEntry);
        }
    }

    static class Main
    {
        public static bool enabled;
        public static Settings settings;

        static bool Load(UnityModManager.ModEntry modEntry) {
            settings = Settings.Load<Settings>(modEntry);

            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            modEntry.OnSaveGUI = OnSaveGUI;
            modEntry.OnToggle = OnToggle;       

            ModMenu.Instance.gameObject.AddComponent<XLShredBrakeForce>();

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            enabled = value;
            return true;
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry) {
            settings.Save(modEntry);
        }
    }
}
