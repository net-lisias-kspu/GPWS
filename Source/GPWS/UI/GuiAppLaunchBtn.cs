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
    class GuiAppLaunchBtn : MonoBehaviour
    {
        public static KSP.UI.Screens.ApplicationLauncherButton appBtn = null;

        public void Awake()
        {
            GameEvents.onGUIApplicationLauncherReady.Add(onGuiAppLauncherReady);
        }

        public void onGuiAppLauncherReady()
        {
            if ((Settings.UseBlizzy78Toolbar && ToolbarManager.ToolbarAvailable) || !KSP.UI.Screens.ApplicationLauncher.Ready)
            {
                return;
            }
            if (appBtn == null)
            {
                appBtn = KSP.UI.Screens.ApplicationLauncher.Instance.AddModApplication(
                        onAppLaunchToggleOnOff,
                        onAppLaunchToggleOnOff,
                        () => { },
                        () => { },
                        () => { },
                        () => { },
                        KSP.UI.Screens.ApplicationLauncher.AppScenes.FLIGHT,
                        (Texture)GameDatabase.Instance.GetTexture("GPWS/gpws", false));
            }
            if (Settings.guiIsActive)
            {
                SettingGui.toggleSettingGui(true);
            }
        }

        private void onAppLaunchToggleOnOff()
        {
            SettingGui.toggleSettingGui();
            appBtn.SetFalse(false);
        }

        public void onGuiAppLauncherDestroyed()
        {
            if (appBtn != null)
            {
                KSP.UI.Screens.ApplicationLauncher.Instance.RemoveModApplication(appBtn);
                appBtn = null;
            }
        }

        public void OnDestroy()
        {
            onGuiAppLauncherDestroyed();
        }
    }
}
