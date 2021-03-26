using UnityEngine;

using KSPe.HMI.Multiplatform.XInput;
using GamePad = KSPe.HMI.Multiplatform.XInput.GamePad.Controller;

namespace KSP_GPWS.Impl
{
    public class ControlerManager
    {
        public const float SHAKE_TIME = 1.0f;
        private float shakeStartTime = 0.0f;

        public ControlerManager()
        {
        }

        public void SetShake(float leftMotor, float rightMotor)
        {
            //for (PlayerIndex playerIndex = PlayerIndex.One; playerIndex <= PlayerIndex.Four; playerIndex++)
            //{
            //    GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
            //}
            shakeStartTime = now();
        }

        public void ResetShake()
        {
            shakeStartTime = 0.0f;
            //for (PlayerIndex playerIndex = PlayerIndex.One; playerIndex <= PlayerIndex.Four; playerIndex++)
            //{
            //    GamePad.SetVibration(playerIndex, 0f, 0f);
            //}
        }

        // to auto stop shake
        public void CheckResetShake()
        {
            if (shakeStartTime > 0f && now() - shakeStartTime >= SHAKE_TIME)
            {
                ResetShake();
            }
        }

        private float now()
        {
            return Time.realtimeSinceStartup;
        }
    }
}
