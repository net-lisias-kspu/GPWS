﻿/*
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
using Save = KSPe.IO.Save<GPWS.Startup>;

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
        public static int UpdateDutyCycle = 1;

        /// <summary>
        /// if true, treat lander as plane, treat plane as lander
        /// </summary>
        public static bool ChangeVesselType = false;

        private static readonly Asset.ConfigNode TEMPLATE = Asset.ConfigNode.For("GPWS_SETTINGS", "settings.cfg");
        private static readonly Data.ConfigNode SETTINGS = Data.ConfigNode.For("GPWS_SETTINGS");

        private static ConfigNode planeDefaultConfigNode = null;
        private static ConfigNode landerDefaultConfigNode = null;

        private static ConfigNode currentPlaneConfigNode = null;
        private static IPlaneConfig _currentPlaneConfig = null;
        public static IPlaneConfig CurrentPlaneConfig
        {
            get
            {
                return _currentPlaneConfig;
            }
            set
            {
                if (_currentPlaneConfig == null)
                {
                    _currentPlaneConfig = value;
                    if (currentPlaneConfigNode != null)
                    {
                        (_currentPlaneConfig as IConfigNode).Load(currentPlaneConfigNode);
                    }
                }
            }
        }

        private static ConfigNode currentLanderConfigNode = null;
        private static ILanderConfig _currentLanderConfig = null;
        public static ILanderConfig CurrentLanderConfig
        {
            get
            {
                return _currentLanderConfig;
            }
            set
            {
                if (_currentLanderConfig == null)
                {
                    _currentLanderConfig = value;
                    if (currentLanderConfigNode != null)
                    {
                        (_currentLanderConfig as IConfigNode).Load(currentLanderConfigNode);
                    }
                }
            }
        }

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
                        planeDefaultConfigNode = node.GetNode("Plane");

                    if (node.HasNode("Lander"))
                        landerDefaultConfigNode = node.GetNode("Lander");

                    Util.ConvertValue<bool>(node, "UseCaption", ref UseCaption);
                    Util.ConvertValue<float>(node, "Volume", ref Volume);
                    Util.ConvertValue(node, "UseBlizzy78Toolbar", ref UseBlizzy78Toolbar);
                    Util.ConvertValue(node, "UpdateDutyCycle", ref UpdateDutyCycle);
                }   // End of has value "name"
            }
            // check legality
            Volume = Math.Min(Math.Max(Volume, 0f), 1f);
            UpdateDutyCycle = Math.Min(Math.Max(UpdateDutyCycle, 1), 50);
        }

		internal static void LoadCurrentVesselConfig(Vessel vessel)
		{
			vessel = vessel ?? FlightGlobals.ActiveVessel; // better safe than sorry

			Save.ConfigNode config = Save.ConfigNode.For("GPWS_SETTINGS");
			if (config.IsLoadable) config.Load();

			ConfigNode vesselNode = config.Node.GetNode(vessel.vesselName) ?? new ConfigNode(vessel.vesselName);

			{
				currentPlaneConfigNode = vesselNode.GetNode(planeDefaultConfigNode.name) ?? KSPe.ConfigNodeWithSteroids.from(planeDefaultConfigNode);
				currentPlaneConfigNode.name = planeDefaultConfigNode.name;
			}

			{
				currentLanderConfigNode = vesselNode.GetNode(landerDefaultConfigNode.name) ?? KSPe.ConfigNodeWithSteroids.from(landerDefaultConfigNode);
				currentLanderConfigNode.name = landerDefaultConfigNode.name;
			}
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
            {
                ConfigNode gpwsNode = new ConfigNode();

                gpwsNode.name = "GPWS_SETTINGS";
                gpwsNode.AddValue("name", "gpwsSettings");

                gpwsNode.AddNode(planeDefaultConfigNode);
                gpwsNode.AddNode(landerDefaultConfigNode);

                gpwsNode.AddValue("UseCaption", Settings.UseCaption);
                gpwsNode.AddValue("Volume", Settings.Volume);
                gpwsNode.AddValue("UseBlizzy78Toolbar", UseBlizzy78Toolbar);
                gpwsNode.AddValue("UpdateDutyCycle", UpdateDutyCycle);

                SETTINGS.Save(gpwsNode);
            }
        }

		internal static void SaveCurrentVesselConfig(Vessel vessel)
		{
			if (null == vessel) return; // Better safe than sorry

			Save.ConfigNode config = Save.ConfigNode.For("GPWS_SETTINGS");
			ConfigNode gpwsNode = config.Node;
			ConfigNode vesselNode = gpwsNode.GetNode(vessel.vesselName);
			if (null == vesselNode)
			{
				vesselNode = new ConfigNode(vessel.vesselName);
				vesselNode.name = vessel.vesselName;
				gpwsNode.AddNode(vesselNode);
			}
			{
				ConfigNode planeNode = vesselNode.GetNode(planeDefaultConfigNode.name);
				if (null == planeNode)
				{
					planeNode = new ConfigNode(planeDefaultConfigNode.name);
					vesselNode.AddNode(planeNode);
				}
				CurrentPlaneConfig.Save(planeNode);
			}
			{
				ConfigNode landerNode = gpwsNode.GetNode(landerDefaultConfigNode.name);
				if (null == landerNode)
				{
					landerNode = new ConfigNode(landerDefaultConfigNode.name);
					vesselNode.AddNode(landerNode);
				}
				CurrentLanderConfig.Save(landerNode);
			}
			config.Save();
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
