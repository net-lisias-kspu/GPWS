using System;

using UnityEngine;
using KSP_GPWS;

namespace GPWS  // Breaking the standard to induce KSPe into looking for files on GPWS folder, not KSP_GPWS.
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class Startup : MonoBehaviour
	{
        private void Start()
        {
            Log.force("Version {0}", Version.Text);

            try
            {
                KSPe.Util.Installation.Check<Startup>();
            }
            catch (KSPe.Util.InstallmentException e)
            {
                Log.error(e.ToShortMessage());
                KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
            }
        }
	}
}
