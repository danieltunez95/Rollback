using System;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace Assets.Interface
{
    class ActionBarManager
    {
        public static List<SpellSlot> spellSlots;
        private static ActionBar actionBar;
        
        // Use this for initialization
        void Start()
        {
            initializeSpellSlots();
            actionBar = new ActionBar();
        }
        void initializeSpellSlots()
        {
            spellSlots = new List<SpellSlot>();
            List<Spell> spells = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellManager>().GetSpells();
            for (int i = 0; i < spells.Count; i++)
            {
                SpellSlot spellSlot = new SpellSlot();
                spellSlot.spell = spells[i];
                spellSlot.key = spells[i].key;
                spellSlot.icon = spells[i].icon;
                spellSlots.Add(spellSlot);
            }

        }


        public void switchSpellSlotIcon(bool cd, KeyCode keyCode)
        {
            if (cd)
            {
                //   spellSlots.Find(x => x.key == keyCode).icon = spellSlots.Find(x => x.key == keyCode).spell.iconCD;
            }
            else
            {
                //	spellSlots.Find(x => x.key == keyCode).icon = spellSlots.Find(x => x.key == keyCode).spell.icon;
            }
            //si no se actualiza automaticamente como el update hay que llamarlo?  OnGUI ();
        }
    }
}
