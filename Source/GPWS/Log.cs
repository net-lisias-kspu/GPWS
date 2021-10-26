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
using KSPe.Util.Log;
using System.Diagnostics;

#if DEBUG
using System.Collections.Generic;
#endif

namespace KSP_GPWS
{
    internal static class Log
    {
        private static readonly Logger log = Logger.CreateForType<GPWS.Startup>();

        internal static void force (string msg, params object [] @params)
        {
            log.force (msg, @params);
        }

        internal static void info(string msg, params object[] @params)
        {
            log.info(msg, @params);
        }

        internal static void warn(string msg, params object[] @params)
        {
            log.warn(msg, @params);
        }

        internal static void detail(string msg, params object[] @params)
        {
            log.detail(msg, @params);
        }

        internal static void error(Exception e, string msg)
        {
            log.error(e, msg);
        }

        internal static void error(string msg, params object[] @params)
        {
            log.error(msg, @params);
        }

        internal static void trace(string msg, params object[] @params)
        {
            log.trace(msg, @params);
        }

        [ConditionalAttribute("DEBUG")]
        internal static void dbg(string msg, params object[] @params)
        {
            log.trace(msg, @params);
        }

        #if DEBUG
        private static readonly HashSet<string> DBG_SET = new HashSet<string>();
        #endif

        [ConditionalAttribute("DEBUG")]
        internal static void dbgOnce(string msg, params object[] @params)
        {
            string new_msg = string.Format(msg, @params);
            #if DEBUG
            if (DBG_SET.Contains(new_msg)) return;
            DBG_SET.Add(new_msg);
            #endif
            log.trace(new_msg);
        }
    }
}
