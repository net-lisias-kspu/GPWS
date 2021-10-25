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
    interface IBasicGpwsFunction
    {
        bool EnableSystem { get; set; }
        UnitOfAltitude UnitOfAltitude { get; set; }

        /// <summary>
        /// Run once.
        /// </summary>
        void InitializeConfig();

        void Initialize(IGpwsCommonData data);

        bool PreUpdate();

        void UpdateGPWS();

        void ChangeVessel(Vessel v);

        void CleanUp();
    }
}
