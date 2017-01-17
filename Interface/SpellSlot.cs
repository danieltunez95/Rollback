using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace Assets.Interface
{
    public class SpellSlot
    {

        public Spell spell;
        public Texture2D icon;
        public KeyCode key;
        public Rect spellPosition;

        public void drawSpellSlot()
        {
            GUI.DrawTexture(spellPosition, icon);
        }
    }
}