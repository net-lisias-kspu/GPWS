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
using KSP_GPWS.SimpleTypes;

namespace KSP_GPWS.Interfaces
{
    public interface IPlaneConfig : IConfigNode
    {
        bool EnableSystem { get; set; }
        bool EnableDescentRate { get; set; }
        bool EnableClosureToTerrain { get; set; }
        bool EnableAltitudeLoss { get; set; }
        bool EnableTerrainClearance { get; set; }
        bool EnableAltitudeCallouts { get; set; }
        bool EnableRetard { get; set; }
        bool EnableBankAngle { get; set; }
        bool EnableTraffic { get; set; }
        bool EnableV1 { get; set; }
        bool EnableRotate { get; set; }
        bool EnableGearUp { get; set; }
        bool EnableStall { get; set; }
        bool EnableStallShake { get; set; }

        float DescentRateFactor { get; set; }
        float TooLowGearAltitude { get; set; }
        float V1Speed { get; set; }
        float TakeOffSpeed { get; set; }
        float LandingSpeed { get; set; }
        float StallAoa { get; set; }
        int[] AltitudeArray { get; set; }

        /// <summary>
        /// use meters or feet, feet is recommanded.
        /// </summary>
        UnitOfAltitude UnitOfAltitude { get; set; }
    }
}
