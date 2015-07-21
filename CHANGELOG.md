#AweSim Connect Change Log

## Upcoming

* Connection windows now spawn to the right of the main form.
* All child windows are brought to fore when app is activated.
* Fix bug with multiple windows to the same point not maintaining connection properly.
* Remove FileZilla handling and use WinSCP by default.
* Add the time launched to the optional panel window.
* Compiler updated to .NET Native. (VS2015)

## v0.60

* Add support for clickable awesim:// links.
* Clean up deployed resources and processes on close.
* PuTTY version update.
* Optimizations and bug fixes.

## v0.51

* Fix bug where app doesn't deploy to subfolder when existing in base folder.

## v0.50

* UI Revamp
* Bug Fixes
* Performance improvements
* Single-instancing
* Add basic SSH check if telnet status changes
* Add terminal emulation via PuTTY
* All helper apps now save to PATH/AweSimFiles/
* Application accepts and parses command line args
* Application accepts and parses awesim:// string
* Add optional advanced setting for automated click

## v0.43

* Add WinSCP as embedded resource and SFTP client fallback.

## v0.42

* Remove giant x
* Enable clipboard by default
* Advanced settings tooltips

## v0.41

* Advanced settings bug fix

## v0.3

* Add support for visualization nodes
* Changed default vnc client from ggivnc to TurboVNC 1.2.9beta (for improved performance and support for screen resizing)
* Local port mapping to prevent multiple tunnel overlap
* Better handling of clipboard data
* Process management improvements
* General bug fixes
