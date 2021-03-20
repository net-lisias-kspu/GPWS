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
using System;
using UnityEngine;

using KSP_GPWS.Interfaces;

using Asset = KSPe.IO.Asset<GPWS.Startup>;
using Data = KSPe.IO.Data<GPWS.Startup>;

namespace KSP_GPWS
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class SettingsLoader : MonoBehaviour
    {
        public void Awake()
        {
            // load settings when game start
            Settings.LoadSettings();
            // check toolbar
            if (Settings.UseBlizzy78Toolbar && !ToolbarManager.ToolbarAvailable)
            {
                Log.warn("Blizzy78 Toolbar not available");
            }
            Gpws.InitializeGPWSFunctions();
        }
    }

    static class Settings
    {
        public static bool UseCaption = true;
        public static float Volume = 0.5f;
        public static bool UseBlizzy78Toolbar = false;

        /// <summary>
        /// if true, treat lander as plane, treat plane as lander
        /// </summary>
        public static bool ChangeVesselType = false;

        private static readonly Asset.ConfigNode TEMPLATE = Asset.ConfigNode.For("GPWS_SETTINGS", "settings.cfg");
        private static readonly Data.ConfigNode SETTINGS = Data.ConfigNode.For("GPWS_SETTINGS");

        public static IPlaneConfig PlaneConfig
        {
            get
            {
                return _planeConfig;
            }
            set
            {
                if (_planeConfig == null)
                {
                    _planeConfig = value;
                    if (planeConfigNode != null)
                    {
                        (_planeConfig as IConfigNode).Load(planeConfigNode);
                    }
                }
            }
        }
        private static IPlaneConfig _planeConfig = null;

        public static ILanderConfig LanderConfig
        {
            get
            {
                return _landerConfig;
            }
            set
            {
                if (_landerConfig == null)
                {
                    _landerConfig = value;
                    if (landerConfigNode != null)
                    {
                        (_landerConfig as IConfigNode).Load(landerConfigNode);
                    }
                }
            }
        }
        private static ILanderConfig _landerConfig = null;

        private static ConfigNode planeConfigNode = null;
        private static ConfigNode landerConfigNode = null;

        public static Rect guiwindowPosition = new Rect(100, 100, 100, 50);
        public static bool showConfigs = true;  // show lower part of the setting GUI
        public static bool guiIsActive = false;

        public static void LoadSettings()
        {
            LoadFromCfg();
            LoadFromXml();
        }

        private static void LoadFromCfg()
        {
            ConfigNode node;
            if (SETTINGS.IsLoadable)
            {
                SETTINGS.Load();
                node = SETTINGS.Node;
            }
            else
            {
                TEMPLATE.Load();
                node = TEMPLATE.Node;
            }

            //if (node.HasNode("GPWS_SETTINGS"))
            {
                //node = node.GetNode("GPWS_SETTINGS");
                if (Util.ConvertValue(node, "name", "") == "gpwsSettings")
                {
                    if (node.HasNode("Plane"))
                    {
                        planeConfigNode = node.GetNode("Plane");
                    }
                    if (node.HasNode("Lander"))
                    {
                        landerConfigNode = node.GetNode("Lander");
                    }

                    Util.ConvertValue<bool>(node, "UseCaption", ref UseCaption);
                    Util.ConvertValue<float>(node, "Volume", ref Volume);
                    Util.ConvertValue(node, "UseBlizzy78Toolbar", ref UseBlizzy78Toolbar);
                }   // End of has value "name"
            }
            // check legality
            Volume = Math.Max(Volume, 0.0f);
            Volume = Math.Min(Volume, 1.0f);
        }

        private static void LoadFromXml()
        {
            Data.PluginConfiguration config = Data.PluginConfiguration.CreateFor("Window.xml");
            config.load();
            guiwindowPosition = config.GetValue<Rect>("guiwindowPosition", guiwindowPosition);
            showConfigs = config.GetValue<bool>("showConfig", showConfigs);
            guiIsActive = config.GetValue<bool>("guiIsActive", guiIsActive);
        }

        public static void SaveSettings()
        {
            SaveToCfg();
            SaveToXml();
        }

        private static void SaveToCfg()
        {
            ConfigNode gpwsNode = new ConfigNode();

            gpwsNode.name = "GPWS_SETTINGS";
            gpwsNode.AddValue("name", "gpwsSettings");

            ConfigNode planeNode = new ConfigNode();
            PlaneConfig.Save(planeNode);
            gpwsNode.AddNode(planeNode);

            ConfigNode landerNode = new ConfigNode();
            LanderConfig.Save(landerNode);
            gpwsNode.AddNode(landerNode);

            gpwsNode.AddValue("UseCaption", Settings.UseCaption);
            gpwsNode.AddValue("Volume", Settings.Volume);
            gpwsNode.AddValue("UseBlizzy78Toolbar", UseBlizzy78Toolbar);

            SETTINGS.Save(gpwsNode);
        }

        public static void SaveToXml()
        {
            Data.PluginConfiguration config = Data.PluginConfiguration.CreateFor("Window.xml");
            config.SetValue("guiwindowPosition", guiwindowPosition);
            config.SetValue("showConfig", showConfigs);
            config.SetValue("guiIsActive", guiIsActive);
            config.save();
        }
    }
}
