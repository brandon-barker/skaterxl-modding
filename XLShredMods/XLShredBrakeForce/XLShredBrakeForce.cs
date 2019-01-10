using UnityEngine;
using XLShredLib;
using XLShredLib.UI;

using System;

namespace XLShredBrakeForce {
    class XLShredBrakeForce : MonoBehaviour {
        public void Start() {
            ModUIBox modUIBox = ModMenu.Instance.RegisterModMaker("skinty", "SkiNty");
            modUIBox.AddLabel("Home / End - Adjust Brake Force", Side.left, () => Main.enabled);
        }

        public void Update() {
            if (Main.enabled) {               
                ModMenu.Instance.KeyPress(KeyCode.Home, 0.1f, () => {
                    if (Main.settings.customBrakeForce < 50f) {
                        Main.settings.IncreaseBrakeForce();
                    }
                    ModMenu.Instance.ShowMessage("Brake Force: " + string.Format("{0:0.0}", Main.settings.customBrakeForce) + " Default: 10.0, Max: 50.0");
                });

                ModMenu.Instance.KeyPress(KeyCode.End, 0.1f, () => {
                    if (Main.settings.customBrakeForce > 1f) {
                        Main.settings.DecreaseBrakeForce();
                    }
                    ModMenu.Instance.ShowMessage("Brake Force: " + string.Format("{0:0.0}", Main.settings.customBrakeForce) + " Default: 10.0, Min: 1.0");
                });
            }
        }
    }
}
