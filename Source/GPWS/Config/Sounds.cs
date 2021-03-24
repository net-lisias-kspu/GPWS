/*
	This file is part of KSP GPWS
	(C) 2021 Lisias T : http://lisias.net <support@lisias.net>

	This file is licensed as follows:

	* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt

	This file is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with KSPe API Extensions/L. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

*/
using KSP_GPWS.SimpleTypes;
using UnityEngine;

namespace KSP_GPWS
{
	public class Sounds
	{
		private readonly string audioPrefix = KSPe.GameDB.Asset<GPWS.Startup>.Solve("Sounds");
		private readonly GameObject audioPlayer;
		private readonly AudioSource asGPWS;

		internal Sounds()
		{
			this.audioPlayer = new GameObject();
			this.asGPWS = new AudioSource();
			this.asGPWS = audioPlayer.AddComponent<AudioSource>();

			this.asGPWS.volume = GameSettings.UI_VOLUME;
			this.asGPWS.spatialBlend = 0;
		}

		internal void UpdateVolume(float volume)
		{
			this.asGPWS.volume = volume;
		}

		internal bool IsPlaying => this.asGPWS.isPlaying;

		internal void Stop()
		{
			this.asGPWS.Stop();
		}

		internal static string Solve(KindOfSound kind)
		{
			string r;
			switch (kind)
			{
				case KindOfSound.NONE:
					r = "silence";
					break;

				case KindOfSound.SINK_RATE:
					r = "sink_rate";
					break;

				case KindOfSound.SINK_RATE_PULL_UP:
					r = "sink_rate_pull_up";
					break;

				case KindOfSound.TERRAIN:
					r = "terrain";
					break;

				case KindOfSound.TERRAIN_PULL_UP:
					r = "terrain_pull_up";
					break;

				case KindOfSound.DONT_SINK:
					r = "dont_sink";
					break;

				case KindOfSound.TOO_LOW_GEAR:
					r = "too_low_gear";
					break;

				case KindOfSound.TOO_LOW_TERRAIN:
					r = "too_low_terrain";
					break;

				case KindOfSound.TOO_LOW_FLAPS:
					r = "";
					break;

				case KindOfSound.GLIDESLOPE:
					r = "";
					break;

				case KindOfSound.ALTITUDE_CALLOUTS:
					r = "gpws";
					break;

				case KindOfSound.BANK_ANGLE:
					r = "bank_angle";
					break;

				case KindOfSound.WINDSHEAR:
					r = "";
					break;

				case KindOfSound.TRAFFIC:
					r = "traffic";
					break;

				case KindOfSound.HORIZONTAL_SPEED:
					r = "horizontal_speed";
					break;

				case KindOfSound.RETARD:
					r = "retard";
					break;

				case KindOfSound.V1:
					r = "v1";
					break;

				case KindOfSound.ROTATE:
					r = "rotate";
					break;

				case KindOfSound.GEAR_UP:
					r = "gear_up";
					break;

				case KindOfSound.STALL:
					r = "stall";
					break;

				default:
					r = "";		// TODO: Add something to prevent breakage
					break;
			}
			return r;
		}

		internal void PlayOneShot(KindOfSound kind, string detail = "")
		{
			if (asGPWS.isPlaying)
			{
				asGPWS.Stop();
			}

			this.Play(kind, detail);
		}

		private void Play(KindOfSound kind, string detail = "")
		{
			string fn = audioPrefix + Sounds.Solve(kind) + detail;
			Log.dbg("Playing sound file {0}", fn);
			asGPWS.clip = GameDatabase.Instance.GetAudioClip(fn);
			asGPWS.Play();
		}


	}
}
