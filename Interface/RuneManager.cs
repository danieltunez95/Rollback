using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Interface
{
    class RuneManager
    {
        private static Texture2D iconCD;
        private int nRunes = 10;        //number of runes
        private int nRunesActive = 10;  //number of active runes
        private int runesCooldown = 0;
        private float runeX = 0.332f;   //Screen X
        private float runeY = 0.847f;   //Screen Y
        private float runeW = 0.0328f;  //rune width
        private float runeH = 0.048f;   //rune height
        private float runeD = 0.0025f;  //rune distance

        private static Rect runeRect;
        private static List<Rune> runes = new List<Rune>();

        public RuneManager(Texture2D icon, Texture2D iconCD)
        {
            runeX = Screen.width * runeX;
            runeY = Screen.height * runeY;
            runeW = Screen.width * runeW;
            runeH = Screen.height * runeH;
            runeD = Screen.width * runeD;

            SetRunes(icon);
        }

        public List<Rune> GetRunes()
        {
            return runes;
        }

        private void SetRunes(Texture2D icon)
        {
            if (runes.Count == 0)
            {
                runeRect.Set(runeX, runeY, runeW, runeH);
                runes = new List<Rune>();
                for (int i = 0; i < 10; i++)
                {
                    Rune rune = new Rune();
                    rune.icon = icon;
                    rune.cooldown = false;
                    runeRect.Set(runeX + i * (runeW + runeD), runeY, runeW, runeH);
                    rune.runePosition = runeRect;
                    runes.Add(rune);
                }
            }
        }

        // This returns if have enought runes to cast
        public bool CanCast(int nRunesCost)
        {
            return nRunesCost <= nRunesActive;
        }

        // This spends and amount of runes
        public void SpendRunes(int nRunesCost)
        {
            //left to right
            int actual = 0;
            while (nRunesCost > 0)
            {
                if (!runes[actual].cooldown)
                {
                    runes[actual].cooldown = true;
                    GUI.DrawTexture(runes[actual].runePosition, iconCD);
                    nRunesCost--;
                    actual++;
                }
            }

            //right to left
            //for (int i = nRunesActive-1; i > (nRunesActive - 1) - nRunesCost; i--)
            //{
            //    runes.ElementAt(i).icon = runeCDIcon;
            //    GUI.DrawTexture(runes.ElementAt(i).runePosition, runes.ElementAt(i).icon);
            //}
            runesCooldown += nRunesCost;
            nRunesActive -= nRunesCost;
        }

        // This returns if runes are full
        public bool CanAddRune()
        {
            return nRunesActive == nRunes ? false : true;
        }
        // This adds a rune
        public void RefreshRune()
        {
            GUI.DrawTexture(runes.ElementAt(nRunesActive).runePosition, runes.ElementAt(nRunesActive).icon);
            nRunesActive++;
        }
    }

}