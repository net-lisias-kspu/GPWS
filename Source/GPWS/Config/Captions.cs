/*
	This file is part of KSP GPWS
		© 2021 Lisias T : http://lisias.net <support@lisias.net>

	This file is licensed as follows:

		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	This file is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with KSPe API Extensions/L. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

*/
using KSP_GPWS.SimpleTypes;

namespace KSP_GPWS
{
	public static class Captions
	{
		private static string Solve(KindOfSound kind)
		{
			string r;
			switch (kind)
			{
				case KindOfSound.SINK_RATE:
					r = "** Sink Rate **";
					break;

				case KindOfSound.SINK_RATE_PULL_UP:
					r = "** Sink Rate PULL UP !! **";
					break;

				case KindOfSound.TERRAIN:
					r = "** Terrain !! **";
					break;

				case KindOfSound.TERRAIN_PULL_UP:
					r = "** Terrain PULL UP !! **";
					break;

				case KindOfSound.DONT_SINK:
					r = "** Don't Sink **";
					break;

				case KindOfSound.TOO_LOW_GEAR:
					r = "** Too Low! GEAR !!";
					break;

				case KindOfSound.TOO_LOW_TERRAIN:
					r = "** Too Low! TERRAIN !! **";
					break;

				case KindOfSound.TOO_LOW_FLAPS:
					r = "** Too Low! FLAPS !! **";
					break;

				case KindOfSound.GLIDESLOPE:
					r = "** Glidescope ! **";
					break;

				case KindOfSound.ALTITUDE_CALLOUTS:
					r = "Altitude: ";
					break;

				case KindOfSound.BANK_ANGLE:
					r = "** Bank Angle ! **";
					break;

				case KindOfSound.WINDSHEAR:
					r = "** WINDSHEAR !! **";
					break;

				case KindOfSound.TRAFFIC:
					r = "** TRAFFIC !! **";
					break;

				case KindOfSound.HORIZONTAL_SPEED:
					r = "** Horizontal Speed ! **";
					break;

				case KindOfSound.RETARD:
					r = "** Retard ! **";
					break;

				case KindOfSound.V1:
					r = "** V One **";
					break;

				case KindOfSound.ROTATE:
					r = "** Rotate **";
					break;

				case KindOfSound.GEAR_UP:
					r = "** Gear Up ! **";
					break;

				case KindOfSound.STALL:
					r = "** STALL !! **";
					break;

				default:
					r = "";
					break;
			}
			return r;
		}

		private const string RED_MESSAGE = "<color=red>{0}</color>";
		private const string YELLOW_MESSAGE = "<color=yellow>{0}</color>";
		private const string GREEN_MESSAGE = "<color=green>{0}</color>";

		internal static void PlayRed(KindOfSound kind, string detail = null)
		{
			Play(RED_MESSAGE, Captions.Solve(kind) + (null == detail ? "" : " " + detail));
		}

		internal static void PlayYellow(KindOfSound kind, string detail = null)
		{
			Play(YELLOW_MESSAGE, Captions.Solve(kind) + (null == detail ? "" : " " + detail));
		}

		internal static void PlayGreen(KindOfSound kind, string detail = null)
		{
			Play(GREEN_MESSAGE, Captions.Solve(kind) + (null == detail ? "" : " " + detail));
		}

		private static void Play(string mask, string msg)
		{
			Log.dbg("Screen message {0}", msg);
			if (Settings.UseCaption) ScreenMessages.PostScreenMessage(string.Format(mask, msg));
		}
	}
}
