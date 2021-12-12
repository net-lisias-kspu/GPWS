# GPWS :: Change Log

* 2021-1211: 1.0.0.2 (LisiasT) for KSP >= 1.2
	+ Preventing the Stock toolbar from not be used until Blizzy support is implemented on KSPe.UI.
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
* 2018-0714: 0.3.9 (bssthu) for KSP 1.2
	+ Recompile for KSP v1.4.4
	+ fix joystick shake's bug
	+ improve TOO_LOW_TERRAIN warning
* 2017-0527: 0.3.8 (bssthu) for KSP 1.2
	+ Recompile for KSP v1.3
* 2017-0320: 0.3.7 (bssthu) for KSP 1.2 PRE-RELEASE
	+ Recompile for KSP v1.2.9-prerelease
	+ Don't hard-depend on ModuleManager
* 2016-1014: 0.3.6 (bssthu) for KSP 1.2
	+ Recompile for KSP 1.2
	+ Add `Gear up` and `V1` callouts
* 2016-0608: 0.3.5 (bssthu) for KSP 1.1.2
	+ Fix compatibility issues
* 2016-0530: 0.3.4 (bssthu) for KSP 1.1.2
	+ Recompile for KSP 1.1.2
* 2016-0425: 0.3-beta.3 (bssthu) for KSP 1.1 PRE-RELEASE
	+ Update for KSP 1.1
* 2015-0822: 0.3-beta.2 (bssthu) for KSP 1.0 PRE-RELEASE
	+ Changes
		- Check stall using AOA
		- Shake joystick if stall
* 2015-0430: 0.3-beta.1 (bssthu) for KSP 1.0 PRE-RELEASE
	+ Changes
		- Support KSP 1.0
		- Can switch between plane/lander function manually
		- Imporve traffic, terrain, too low warnings
		- Say rotate when speed > take off speed
		- Fix bugs
* 2015-0309: 0.3-beta.0 (bssthu) for KSP 0.90 PRE-RELEASE
	+ Changes
		- Add support for planet landers,
		- support descent rate warning, horizontal speed warning, throttle warning, and altitude callouts
		- Add throttle warning (retard) for planes
		- Fix bugs
* 2015-0305: 0.2-beta.1 (bssthu) for KSP 0.90 PRE-RELEASE
	+ Changes
		- Add terrain clearance warning
		- Add bank angle warning
		- Add closure to terrain warning
		- Add altitude loss warning
		- Add TCAS warning
		- Improve UI
		- Support KSP-AVC
		- fix bugs
* 2015-0226: 0.2-beta.0 (bssthu) for KSP 0.90 PRE-RELEASE
	+ Changes
		- Support stock ModuleLandingGear and FSwhell from Firespitter
		- Add descent rate warning
		- Add landing gear warning
		- Add bank angle warning
		- Add setting GUI, support AppLaunch toolbar and Blizzy78's toolbar
* 2015-0117: 0.1-alpha.0 (bssthu) for KSP 0.90 PRE-RELEASE
	+ Altitude callouts
