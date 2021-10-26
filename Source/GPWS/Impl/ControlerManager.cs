/*
	This file is part of GPWS /L Unleashed
		© 2021 Lisias T : http://lisias.net <support@lisias.net>
		© 2015-2018 bssthu
		© 2013-2014 Cryphonus

	GPWS /L is licensed as follows:

		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	GPWS /L Unleashed is distributed in the hope that it will be useful, but
	WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
	or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 2.0
	along with GPWS /L Unleashed. If not, see <https://www.gnu.org/licenses/>.

 */
﻿using UnityEngine;

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
