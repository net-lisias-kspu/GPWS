# GPWS :: Changes

* 2021-1027: 1.0.0.1 (LisiasT) for KSP >= 1.2
	+ Added KSPe facilities:
		- Logging
		- File System Abstraction
			- Global Settings are saved on `<KSP>/PluginData/net.lisias.ksp/GPWS`
			- Vessel specific settings are saved on `<KSP>/save/<current_savegame>/net.lisias.ksp/GPWS`
		- Seamless support for Click Trough Blocker (if it is installed, it's used, otherwise nothing bad happens)
		- HMI (XInput)
		- Toolbar
	+ Adding support for KSPWheels and Stock wheels.
	+ Lots of improvements, optimisations and small bug fixes
	+ Added an option to display the GPWS warning on the Screen
	+ Works on every KSP version from 1.2.0 to the latest.
