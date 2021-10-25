/*
	This file is part of GPWS /L Unleashed
		© 2021 Lisias T : http://lisias.net <support@lisias.net>
		© 2015-2018 bssthu
		© 2013-2014 Cryphonus

	GPWS /L is double licensed, as follows:

		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	GPWS /L Unleashed is distributed in the hope that it will be useful, but
	WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
	or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 2.0
	along with GPWS /L Unleashed. If not, see <https://www.gnu.org/licenses/>.

*/
namespace KSP_GPWS.Interfaces
{
    public interface IGpwsCommonData
    {
        float RadarAltitude { get; set; }

        float LastRadarAltitude { get; }

        float Altitude { get; set; }

        float LastAltitude { get; }

        /// <summary>
        /// in m/s
        /// </summary>
        float HorSpeed { get; }

        float LastHorSpeed { get; }

        /// <summary>
        /// in m/s
        /// </summary>
        float VerSpeed { get; }

        float LastVerSpeed { get; }

        float Speed { get; }

        float CurrentTime { get; }

        float LastTime { get; }

        /// <summary>
        /// time of takeoff.
        /// when on ground, takeOffTime = time
        /// </summary>
        float TakeOffTime { get; }

        /// <summary>
        /// time of landing/splashing.
        /// when flying, landingTime = time
        /// </summary>
        float LandingTime { get; }

        Vessel ActiveVessel { get; }
    }
}
