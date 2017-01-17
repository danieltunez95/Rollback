using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
namespace Assets.Interface
{
    public class ActionBar
    {

        public Texture2D actionBar;
        private Rect actionBarPosition = new Rect(0.28f, 0.8999f, 0.4f, 0.1f);
        private Rect spellRect = new Rect(0.284f, 0.91f, 0.045f, 0.075f);

        private float spellD = 0.005f;

        // Use this for initialization
        void Start()
        {
            /*draw action bar*/
            GUI.DrawTexture(getActionBarRect(), actionBar);
        }

        // Update is called once per frame
        void Update()
        {
            updateSpellSlots();
        }

        void updateSpellSlots()
        {
            int i = 0;
            //foreach(SpellSlot spellSlot in spellSlots)
            {
                //    spellSlot.spellPosition.Set(spellX + i++ * (spellW + spellD), spellY, spellW, spellH);
            }
        }

        void OnGUI()
        {

            /*draw spellslots */
            //foreach (SpellSlot spellSlot in spellSlots)
            {
                //	GUI.DrawTexture(getSpellSlotRect(spellSlot.spellPosition), spellSlot.icon);
            }
        }

        Rect getActionBarRect()
        {
            return new Rect(Screen.width * actionBarPosition.x, Screen.height * actionBarPosition.y, Screen.width * actionBarPosition.width, Screen.height * actionBarPosition.height);
        }

        public Rect getSpellSlotRect(Rect position)
        {
            return new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height);
        }


    }
}