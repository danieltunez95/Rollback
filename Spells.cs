using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class Spells
    {
        //TELEPORT
        public Texture2D teleportIcon;
        public Texture2D teleportIconCD;
        public float teleportCooldown = 15f;
        public float teleportCastTime = 0.5f;
        public float teleportEnhanceTime = 2f;
        private KeyCode teleportKey = KeyCode.E;

        //ORB
        public Texture2D orbIcon;
        public Texture2D orbIconCD;
        public float orbCooldown = 10f;
        public float orbCastTime = 2;
        public float orbEnhanceTime = 2;
        private KeyCode orbKey = KeyCode.Q;

        //DRAGON HEAL
        public Texture2D dragonhealIcon;
        public Texture2D dragonhealIconCD;
        public float dragonhealCooldown = 25f;
        public float dragonhealCastTime = 3;
        public float dragonhealEnhanceTime = 4;
        private KeyCode dragonhealKey = KeyCode.W;

        public List<Spell> GetSpells()
        {
            List<Spell> spells = new List<Spell>();

            Spell teleport = new Spell();
            teleport.name = "Teleport";
            teleport.castTime = teleportCastTime;
            teleport.enhanceTime = teleportEnhanceTime;
            teleport.cooldown = teleportCooldown;
            teleport.key = teleportKey;
            teleport.timer = 0;
            teleport.icon = teleportIcon;
            teleport.iconCD = teleportIconCD;
            spells.Add(teleport);

            Spell orb = new Spell();
            orb.name = "orb";
            orb.prefab = "Prefabs/Characters/Spells/Orb";
            orb.castTime = orbCastTime;
            orb.enhanceTime = orbEnhanceTime;
            orb.cooldown = orbCooldown;
            orb.timer = 0;
            orb.key = orbKey;
            orb.icon = orbIcon;
            orb.iconCD = orbIconCD;
            spells.Add(orb);

            Spell dragonheal = new Spell();
            dragonheal.name = "dragonheal";
            dragonheal.castTime = dragonhealCastTime;
            dragonheal.enhanceTime = dragonhealEnhanceTime;
            dragonheal.cooldown = dragonhealCooldown;
            dragonheal.timer = 0;
            dragonheal.key = dragonhealKey;
            dragonheal.icon = dragonhealIcon;
            dragonheal.iconCD = dragonhealIconCD;
            spells.Add(dragonheal);

            return spells;
        }
		public void SetSpellsIcons( Texture2D icoQ, Texture2D icoQCd,Texture2D icoW, Texture2D icoWCd,Texture2D icoE, Texture2D icoECd){
			teleportIcon = icoQ;
			teleportIconCD = icoQCd;
			orbIcon = icoW;
			orbIcon = icoWCd;
			dragonhealIcon = icoE;
			dragonhealIconCD = icoECd;
		}
    }

