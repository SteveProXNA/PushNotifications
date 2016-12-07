# PushNotifications
Push Notifications application for iOS and Android clients

###### RELEASE
Wednesday, 22nd June 2016

###### PLATFORMS
- iOS
- Android

###### TOOLS
- C#/.NET Framework 4.5
- Visual Studio 2012

###### SOURCE CODE
https://github.com/SteveProXNA/PushNotifications

###### CONFIGURATION
Contains all inputs (see below).  File: "App.config"

Default configuration values (if no file present)<br />
[Platform]			= iOS | Android		// (Platform to send notification)<br />
[SendMessage]		= true | false		// (True otherwise false for test)<br />
[MaxBatch]			= 20;				// (20x  per batch to Apple)<br />
[Increment]			= 1000; 			// (Debug logging  increment)<br />
[CommandTimeout]	= 600;				// (10mins before DB timeout)<br />

###### CONTACT
- Blog:		http://steveproxna.blogspot.com
- Email:	steven_boland@hotmail.com
- Twitter:	[@SteveProXNA](http://twitter.com/SteveProXNA)