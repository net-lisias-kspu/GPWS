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
using System;
using UnityEngine;
using KSP_GPWS.SimpleTypes;

namespace KSP_GPWS.Impl
{
    public class AudioManager
    {
        public float Volume { get; set; }

        private Sounds sounds;
        private float lastPlayTime = 0.0f;

        public KindOfSound KindOfSound
        {
            get
            {
                return _kindOfSound;
            }
            private set
            {
                _kindOfSound = value;
            }
        }
        private static KindOfSound _kindOfSound = KindOfSound.NONE;

        private String detail = "";

        public void Initialize()
        {
            this.sounds = new Sounds();

            KindOfSound = KindOfSound.NONE;
            lastPlayTime = Time.time;
        }

        public void UpdateVolume()
        {
            Volume = GameSettings.UI_VOLUME * Settings.Volume;
            this.sounds.UpdateVolume(Volume);
        }

        public void PlaySound(KindOfSound kind, String detail = "")
        {
            if (Time.time - lastPlayTime < 0.3f)    // check time
            {
                return;
            }

            switch (kind)
            {
                case KindOfSound.SINK_RATE:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.SINK_RATE_PULL_UP:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP))
                    {
                        Captions.PlayRed(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.TERRAIN:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                        && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.TERRAIN_PULL_UP:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                        && !IsPlaying(KindOfSound.TERRAIN_PULL_UP))
                    {
                        Captions.PlayRed(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.DONT_SINK:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                        && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                        && !IsPlaying(KindOfSound.DONT_SINK))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.TOO_LOW_GEAR:
                    if (!IsPlaying(KindOfSound.TOO_LOW_GEAR)
                            && !IsPlaying(KindOfSound.TOO_LOW_TERRAIN)
                            && !IsPlaying(KindOfSound.TOO_LOW_FLAPS))
                    {
                        Captions.PlayRed(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.TOO_LOW_TERRAIN:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.TOO_LOW_GEAR) && !IsPlaying(KindOfSound.TOO_LOW_TERRAIN)
                            && !IsPlaying(KindOfSound.TOO_LOW_FLAPS))
                    {
                        Captions.PlayRed(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.TRAFFIC:
                    if (!IsPlaying(KindOfSound.TRAFFIC))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.STALL:
                    if (!IsPlaying(KindOfSound.STALL) && !IsPlaying(KindOfSound.TOO_LOW_FLAPS)
                            && !IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.TOO_LOW_GEAR) && !IsPlaying(KindOfSound.TOO_LOW_TERRAIN))
                    {
                        Captions.PlayRed(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.ALTITUDE_CALLOUTS:
                    this.detail = detail;
                    Captions.PlayGreen(kind, detail);
                    PlayOneShot(kind, detail);
                    break;
                case KindOfSound.BANK_ANGLE:
                    if (!IsPlaying(KindOfSound.BANK_ANGLE))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.HORIZONTAL_SPEED:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.HORIZONTAL_SPEED))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.RETARD:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.DONT_SINK) && !IsPlaying(KindOfSound.RETARD))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.V1:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.DONT_SINK) && !IsPlaying(KindOfSound.V1) && !IsPlaying(KindOfSound.ROTATE))
                    {
                        Captions.PlayGreen(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.ROTATE:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.DONT_SINK) && !IsPlaying(KindOfSound.ROTATE))
                    {
                        Captions.PlayGreen(kind);
                        PlayOneShot(kind);
                    }
                    break;
                case KindOfSound.GEAR_UP:
                    if (!IsPlaying(KindOfSound.SINK_RATE) && !IsPlaying(KindOfSound.SINK_RATE_PULL_UP)
                            && !IsPlaying(KindOfSound.TERRAIN) && !IsPlaying(KindOfSound.TERRAIN_PULL_UP)
                            && !IsPlaying(KindOfSound.DONT_SINK) && !IsPlaying(KindOfSound.GEAR_UP))
                    {
                        Captions.PlayYellow(kind);
                        PlayOneShot(kind);
                    }
                    break;
                default:
                    break;
            }
        }

        private void PlayOneShot(KindOfSound kind)
        {
            this.PlayOneShot(kind, "");
        }

        private void PlayOneShot(KindOfSound kind, string detail)
        {
            this.sounds.PlayOneShot(kind, detail);

            _kindOfSound = kind;
            lastPlayTime = Time.time;
            Log.detail("play {0} {1}", kind, detail);
        }
        
        public void Stop()
        {
            if (this.sounds.IsPlaying)
            {
                this.sounds.Stop();
            }
        }

        public bool IsPlaying()
        {
            return this.sounds.IsPlaying;
        }

        public bool IsPlaying(KindOfSound kind)
        {
            if (!this.sounds.IsPlaying)
            {
                return false;
            }
            if (kind != KindOfSound)
            {
                return false;
            }
            return true;
        }

        public bool WasPlaying(KindOfSound kind)    // was or is playing
        {
            return kind == KindOfSound;
        }

        public void SetUnavailable()
        {
            KindOfSound = KindOfSound.UNAVAILABLE;
            Stop();
        }

        public void MarkNotPlaying()
        {
            KindOfSound = KindOfSound.NONE;
        }

        /// <summary>
        /// get KindOfSound in string in RTF format
        /// </summary>
        /// <returns></returns>
        public String GetKindOfSoundRTF()
        {
            String rtfText = KindOfSound.ToString();
            if (KindOfSound == KindOfSound.UNAVAILABLE)
            {
                rtfText = "<color=white>" + rtfText + "</color>";
            }
            else if (KindOfSound == KindOfSound.ALTITUDE_CALLOUTS)
            {
                UnitOfAltitude unit = UnitOfAltitude.NONE;
                if (Gpws.ActiveVesselType == SimpleTypes.VesselType.PLANE)
                {
                    unit = Settings.CurrentPlaneConfig.UnitOfAltitude;
                }
                else if (Gpws.ActiveVesselType == SimpleTypes.VesselType.LANDER)
                {
                    unit = Settings.CurrentLanderConfig.UnitOfAltitude;
                }
                rtfText = detail + Util.GetShortString(unit);
            }
            else if (KindOfSound != KindOfSound.NONE)
            {
                rtfText = "<color=red>" + rtfText + "</color>";
            }
            return rtfText;
        }
    }
}
