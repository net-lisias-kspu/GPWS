using System.Runtime.InteropServices;

namespace KSP_GPWS.Controller
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XInputState
    {
        private uint packetNumber;
        private XInputGamepad gamepad;

        [StructLayout(LayoutKind.Sequential)]
        public struct XInputGamepad
        {
            private ushort buttons;
            private byte leftTrigger;
            private byte rightTrigger;
            private short thumbLX;
            private short thumbLY;
            private short thumbRX;
            private short thumbRY;
        }
    }
}
