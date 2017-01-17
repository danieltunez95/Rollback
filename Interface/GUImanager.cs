using System;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace Assets.Interface
{
    public class GUImanager : MonoBehaviour
    {
        public Texture2D runeIcon;
        public Texture2D runeCDIcon;

        private float seconds = 0f;
        RuneManager runeManager;
        void Start()
        {
            runeManager = new RuneManager(runeIcon, runeCDIcon);
        }

        // Update is called once per frame
        void OnGUI()
        {
            foreach (Rune rune in runeManager.GetRunes())
            {
                if (rune.cooldown)
                    GUI.DrawTexture(rune.runePosition, runeCDIcon);
                else
                    GUI.DrawTexture(rune.runePosition, rune.icon);
            }


            if (seconds >= 0)
            {
                seconds -= Time.fixedDeltaTime;
                if (seconds <= 0)
                {
                    //activar runa
                }
                //si hay mas runas en CD, volver a 5. Si no, dejar en 0
            }
        }
    }
}
