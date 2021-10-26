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
using UnityEngine;
using KSP_GPWS.Interfaces;
using KSPe.Annotations;
using Asset = KSPe.IO.Asset<GPWS.Startup>;
using Toolbar = KSPe.UI.Toolbar;

namespace KSP_GPWS.UI
{
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	class GuiAppLaunchBtn:MonoBehaviour
	{
		public static Toolbar.Button appBtn = null;

		[UsedImplicitly]
		private void Start()
		{
			if (appBtn == null)
			{
				Texture2D tex = Asset.Texture2D.LoadFromFile("gpws");
				appBtn = Toolbar.Button.Create(this
						, KSP.UI.Screens.ApplicationLauncher.AppScenes.FLIGHT
						, tex, tex
						, GPWS.Version.FriendlyName
				);
				appBtn.Toolbar.Add(Toolbar.Button.ToolbarEvents.Kind.Active
						, new Toolbar.Button.Event(this.onAppLaunchToggleOnOff, this.onAppLaunchToggleOnOff)
					);
				ToolbarController.Instance.Add(appBtn);
				ToolbarController.Instance.BlizzyActive(Settings.UseBlizzy78Toolbar);
			}

			if (Settings.guiIsActive)
			{
				SettingGui.toggleSettingGui(true);
			}
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
			ToolbarController.Instance.Destroy();
		}

		private void onAppLaunchToggleOnOff()
		{
			SettingGui.toggleSettingGui();
		}
	}
}
