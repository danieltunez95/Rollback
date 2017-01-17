using Assets.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class SpellManager : Photon.MonoBehaviour
    {
        public CharacterController Controller;
        public GameObject Character;
        private static GameObject character;
        private static List<Spell> spells;
		CastBar castbar;
        ActionBarManager actionBarManager;
		private static KeyCode currentKey;

		public Texture2D icoQ;
		public Texture2D icoQCd;
		public Texture2D icoW;
		public Texture2D icoWCd;
		public Texture2D icoE;
		public Texture2D icoECd;

        void Start()
        {
            actionBarManager = new ActionBarManager ();
			castbar = new CastBar ();
            if (spells == null)
            {
                Spells spellConfig = new Spells();
				spellConfig.SetSpellsIcons (icoQ, icoQCd, icoW, icoWCd, icoE, icoECd);
                spells = spellConfig.GetSpells();
            }
            character = Character;
        }

        public List<Spell> GetSpells()
        {
            if (spells == null)
                spells = new List<Spell>();
            return spells;
        }

        void Update()
        {
            foreach (Spell spell in spells.Where(spell => spell.timer > 0))
            {
                spell.timer -= Time.deltaTime;

				if (spell.timer <= 0)
                    actionBarManager.switchSpellSlotIcon (false, spell.key);
				else {
                    actionBarManager.switchSpellSlotIcon (true, spell.key);
				}

            }

        }

        public bool CanCast(KeyCode keyCode)
        {
            return GetSpellByKey(keyCode).timer <= 0;
        }

        public void SetTimer(KeyCode keyCode)
        {
            Spell spell = GetSpellByKey(keyCode);
            spell.timer = spell.castTime;
            actionBarManager.switchSpellSlotIcon(true, keyCode);
        }

        public float GetCastTime(KeyCode keyCode)
        {
            return GetSpellByKey(keyCode).castTime;
        }

        public float GetEnhanceTime(KeyCode keyCode)
        {
            return GetSpellByKey(keyCode).enhanceTime;
        }

        public Spell GetSpellByKey(KeyCode keyCode)
        {
            return spells.Where(spell => spell.key == keyCode).First();
        }

        public void Start(Vector3 startPosition, Vector3 endPosition, KeyCode key)
    {
        switch (key)
            {
			    case KeyCode.Q:
                //Orb
                //(startPosition, endPosition, GetSpellByKey(key)
                Quaternion qua = new Quaternion(0, 0, 0, 0);
                Orb.orb = PhotonNetwork.Instantiate(GetSpellByKey(key).prefab, startPosition, qua, 0);
                Orb.InitializeOrb(startPosition, endPosition, GetSpellByKey(key));
                break;
           	    case KeyCode.W:
                    //dragonheal
                    Spell dragonHeal = GetSpellByKey(key);

                    PhotonNetwork.Instantiate(dragonHeal.prefab, endPosition, Character.transform.rotation, 0);
                    break;
                case KeyCode.E:
                    //Teleport
                    //Spell teleport = GetSpellByKey(key);
				    character.transform.position = endPosition;
                    break;
            }

    }

		public void StartCastBar(KeyCode key, float actualtime){
			CastBar castBar = new CastBar ();
			Spell actual = GetSpellByKey (key);
			float timeIn = actual.castTime;
			float timeOut = actual.enhanceTime;
			float velocityIn = (actualtime * castBar.widthMax / timeIn)*(float)2;
			float velocityOut = (actualtime * castBar.widthMax / timeOut)*(float)2;
			CastBar.StartVelocity (velocityIn, velocityOut);
            
        }

        public void Cancel(bool outOfTime)
        {
			CastBar castBar = new CastBar ();
			castBar.Stop ();
        }
    }

