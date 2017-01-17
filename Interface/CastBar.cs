using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Interface
{
    public class CastBar : MonoBehaviour
    {

        public Texture2D castBar;
        public Texture2D castBarFill;
        public Rect castBarPosition;
        public Rect castBarFillPosition;
        public static bool isFilled;
        public static bool isNeeded;

        public float widthMax = 0.36f;
        private static float velocityIn;
        private static float velocityOut;

        // Use this for initialization
        void Start()
        {
            castBarFillPosition.width = 0;
            isFilled = false;
            isNeeded = false;
            velocityIn = 0;
            velocityOut = 0;
            widthMax = (float)0.328;
        }

        // Update is called once per frame
        void Update()
        {
            // The velocity is the width amount changes between frames
            if (isNeeded)
            {
                // Velocity switch
                if (isFilled)
                    castBarFillPosition.width -= velocityOut;
                else
                    castBarFillPosition.width += velocityIn;

                // Limit when fills
                if (castBarFillPosition.width >= widthMax)
                    isFilled = true;

                // Limit when empties
                if (castBarFillPosition.width < 0)
                    isNeeded = false;
            }
            else
                Stop();
        }

        void OnGUI()
        {
            if (isNeeded)
            {
                /*draw castbar*/
                GUI.DrawTexture(getCastBarRect(), castBar);
                /*draw castbar fill*/
                GUI.DrawTexture(getCastBarFillRect(), castBarFill);
            }
        }

        // This starts the castBar
        public static void StartVelocity(float VelocityIn, float VelocityOut)
        {
            velocityIn = VelocityIn;
            velocityOut = VelocityOut;
            CastBar.isNeeded = true;
        }
        // This is used for deltatime changes
        public void UpdateVelocity(float VelocityIn, float VelocityOut)
        {
            velocityIn = VelocityIn;
            velocityOut = VelocityOut;
        }

        // This stops the castBar
        public void Stop()
        {
            CastBar.isNeeded = false;
            velocityIn = 0;
            velocityOut = 0;
            castBarFillPosition.width = 0;
            isFilled = false;
        }

        Rect getCastBarRect()
        {
            return new Rect(Screen.width * castBarPosition.x, Screen.height * castBarPosition.y, Screen.width * castBarPosition.width, Screen.height * castBarPosition.height);
        }

        Rect getCastBarFillRect()
        {
            return new Rect(Screen.width * castBarFillPosition.x, Screen.height * castBarFillPosition.y, Screen.width * castBarFillPosition.width, Screen.height * castBarFillPosition.height);
        }


    }
}