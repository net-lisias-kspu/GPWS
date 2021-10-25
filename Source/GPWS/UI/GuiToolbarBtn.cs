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
using UnityEngine;
using KSP_GPWS.Interfaces;

namespace KSP_GPWS.UI
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class GuiToolbarBtn : MonoBehaviour
    {
        private IButton btn = null;

        public void Awake()
        {
            if (Settings.UseBlizzy78Toolbar && ToolbarManager.ToolbarAvailable)
            {
                btn = ToolbarManager.Instance.add("GPWS", "GPWSBtn");
                btn.TexturePath = "GPWS/gpws";
                btn.ToolTip = "GPWS settings";
                btn.Visibility = new GameScenesVisibility(GameScenes.FLIGHT);
                btn.OnClick += (e) => SettingGui.toggleSettingGui();
            }
        }

        public void OnDestroy()
        {
            if (btn != null)
            {
                btn.Destroy();
                btn = null;
            }
        }
    }
}
