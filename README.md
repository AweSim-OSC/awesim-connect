![OSC](./Documentation/img/osclogofull.png)

# OSC Connect

## How to use the OSC Connect App to Securely Connect a Windows PC to an OSC Session

OSC connect is a native windows application written in C# and compiled for .NET 2.0, providing compatibility for Windows versions from XP through Windows 10.

### Why OSC Connect?

To connect to OSC services, a secure tunnel to a session is required. This can be done relatively simply in OSX and Linux by using the SSH functionality built into the system, but Windows users have had to configure and use third party applications like PuTTY or Java to access secure resources at OSC. OSC Connect provides preconfigured management of secure tunnel connections for Windows users, as well as providing a launcher for secure file transfer, VNC, terminal, and web based services.

## Getting Started

#### Download the latest release of `OSCConnect.exe` from the OSC OnDemand or AweSim Dashboard

[Download Latest Build](https://github.com/OSC/osc-connect/releases/latest)

#### Use "Save" or "Save As" to save this file to a folder of your choice

When you first run OSC Connect, a temporary folder with four additional files will be added to this folder. These are required for proper functionality of the application. Please ensure that these files are permitted by your IT administrator.

* `plink.exe` is the command-line version of PuTTY and is used by the application to create the secure connection to OSC resources. (version 0.66)
* `putty.exe` the GUI application of PuTTY is used to provide terminal emulation remote console connections to OSC resources. (version 0.66)
* `vncviewer.exe` is the VNC viewer client used to view a remote desktop session. Currently TurboVNC Viewer 2.0.1.
* `WinSCP.exe` OSC Connect includes WinSCP 5.7.6 as the default SFTP client.

#### Double-Click the `OSCConnect.exe` file to run the application

No further installation is required. In the current state, OSC Connect is entirely deployed by a single executable file.

The application will have to be run once manually to provide support for launching sessions through the custom URI scheme.

## Connecting to a Session

The OSC Connect application can be used to connect to a running session. Sessions are launched through the OSC web dashboard. OSC Connect does not have the ability to launch a new session.

#### Navigate to the OSC OnDemand or AweSim Dashboard and create a session

* [OSC OnDemand](http://www.osc.edu)
* [AweSim Dashboard](http://apps.awesim.org)

#### Enter your OSC Credentials in the text boxes

* Entering your credentials reveals file transfer options and allows you to select a Session type.

### Three ways to Connect

#### Option One: Click the `osc://` or `awesim://` link.

 OSC Connect supports a custom URI scheme that is registered when you launch the application. After the app is run once, just click the link provided in the Session App to launch OSC Connect and populate the configuration information. Then, just click the lightning bolt icon to connect to your session.

#### Option Two: Copy to clipboard

 The "Copy to clipboard" option is currently disabled by default. If you are having difficulty connecting using one of the OSC URIs, you can open the Advanced Settings menu and enable the "Detect Clipboard Activity" option.
 
 When this option is enabled just copy the URI link to your windows clipboard. The application will detect the code and populate the fields for you. Then, just click the lightning bolt icon to connect to your session.

 If your information has been entered correctly, you will be automatically connected to our system. You may see a window open and close briefly, this is the secure tunnel being established.

* If your password was entered incorrectly on the main form, this window will remain open while the system prompts you for a valid password.

#### Option Three: Manually enter the connection data.

##### Select a session type

* Click the option to create a VNC Tunnel or a COMSOL server session tunnel.

##### Enter your session info

* **COMSOL Server**: Enter the host name provided by the session manager. A remote port of 2036 will be entered by default.

* **VNC Connection**: In the session manager of the application you want to connect to, click the blue icon to display additional connection info. Enter the Host, Port, and VNC password as displayed in the image below.

##### Click to Connect the tunnel

When all of the fields are populated, click the lightning bolt icon to establish the secure tunnel. If your information has been entered correctly, you will be automatically connected to our system. You may see a window open and close briefly, this is the secure tunnel being established.

* If your password was entered incorrectly on the main form, this window will remain open while the system prompts you for a valid password.

## Settings and Automation options

The settings menu (indicated by the wrench icon) contains several configuration options to modify the behavior of the application.

### Connection Settings

#### SSH Host

Use this dropdown to select the default host. Selecting a server here will change the endpoint for tunneling, sftp connections, console connections, and connectivity checking. ( Default: oakley.osc.edu )

### System Settings

#### Detect Clipboard Activity

When this option is enabled, the application will detect valid data on the Windows clipboard and populate the application. ( Default: Off )

### Automation Settings

Several automation functions are available to reduce the amount of interaction required with the OSC Connect application.

#### Save User Credentials

When checked, allows the application to remember the user when the application is reopened. This saves the user credentials to the user settings using DPAPI Encryption. Passwords are decrypted only by current the Windows user account. ( Default: Off )

#### Launch Tunnel on Import

When checked, the tunnel will automatically connect when the application detects a valid clipboard string and the user credentials have been entered. ( Default: On )

#### Automatically Open Session

When checked, the application will automatically launch a browser or vnc session when the tunnel is detected.

## Secure File Transfer

The OSC Connect application will use the embedded client to allow you to connect to securely connect to the OSC file system over SFTP.

#### Enter your OSC credentials

#### Click the file transfer button in the bottom left.

OSC Connect now uses WinSCP as the default SFTP client.

* [WinSCP](http://winscp.net/eng/index.php) is the embedded SFTP client. The OSC Connect application will deploy and run a WinSCP process.

## FAQ

#### I've clicked the `awesim://` or `osc://` link and nothing happened.

Be sure to launch `OSCConnect.exe` at least once. The initial launch will add a key to your user registry that initializes the URI scheme.

If you move or rename the `OSCConnect.exe` file, you will need to open the application again manually to update the path in the handler.

#### I've received the error "Unable to open helper application. The porotocol specified in this address is not valid."

This issue appears in some earlier versions of Internet Explorer when attempting to launch the application from a Temporary location. Download and run the `OSCConnect.exe` application, being sure to click "Save As" or "Save" in your browser to save the file to a non-temporary location.

## Developer Notes

* OSC Connect is built to comply with the Microsoft .NET  runtime 2.0. 2.0 is considered "pure" .NET and the compiled binaries should function without additional dependencies on Windows XP/7/8/8.1/10.
* OSC Connect is developed using primarily the [C# language](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx).

#### Build Instructions

* Download and install [Visual Studio Community 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Visual Studio includes team support. If you are accustomed to command-line git, download and install [Git for Windows](https://msysgit.github.io/) to gain access to Git Bash.
* `git clone` the OSC Connect repository to your system.
* Open the project in Visual Studio by clicking **File > Open > Project/Solution** and selecting **AweSimConnect.sln** in the file dialog. You can also load the project in Visual Studio by double-clicking the **AweSimConnect.sln** file in the Windows Explorer.
* Download the required dependencies using the NuGet Package Manager
* Click the button with the green arrow and the word "Start" to build and run the solution.

#### Version Checking

As of version 0.92, OSC Connect relies upon Github for hosting binaries and version information. The app will make a request to the [GitHub API](https://api.github.com/repos/OSC/osc-connect/releases/latest) to obtain the latest tagged release.

If the released version on github is newer than the existing version, the app displays a link to the latest version of the application.


#### Automatic connection via `awesim://` or `osc://` URI

OSC Connect has custom URI support. Run the application once to enable this feature. Clicking an AweSim or OSC URI provided by the web session manager will activate and populate the application with connection data.

Examples of valid patterns:

* VNC: ```osc://<UserName>:<VNCPassword>@<PUAServer><RemoteHost>```
* VNC (no user): ```osc://:<VNCPassword>@<PUAServer><RemoteHost>```
* COMSOL: ```osc://<UserName>@<PUAServer><RemoteHost>```
* COMSOL (no user): ```osc://<PUAServer>:<RemoteHost>```
* SFTP: ```osc://sftp@<RemotePath>```
* VNC: ```awesim://<UserName>:<VNCPassword>@<PUAServer><RemoteHost>```
* VNC (no user): ```awesim://:<VNCPassword>@<PUAServer><RemoteHost>```
* COMSOL: ```awesim://<UserName>@<PUAServer><RemoteHost>```
* COMSOL (no user): ```awesim://<PUAServer>:<RemoteHost>```
* SFTP: ```awesim://sftp@<RemotePath>```

#### Automatic connection via command line arguments.

OSC Connect accepts command line arguments in the patterns:

* ```OSCConnect.exe <UserName>:<VNCPassword>@<PUAServer>:<RemotePort>```
* ```OSCConnect.exe :<VNCPassword>@<PUAServer>:<RemotePort>```
* ```OSCConnect.exe <UserName>@<PUAServer>:<RemotePort>```
* ```OSCConnect.exe <PUAServer>:<RemotePort>```
* ```OSCConnect.exe sftp@<RemotePath>```

#### [Deprecated] Automatic connection via valid json string.

The application can detect when a properly formatted string is copied to the Windows clipboard and it will automatically parse the input data. In this version, the application can expect 4 inputs. The inputs are case-sensitive.

* **U**, or **UserName** - The OSC username credential. *(ex: an0018)*
* **H**, or **PUAServer** - The host name of the running session. *(ex: n0580.ten.osc.edu')*
* **R**, or **RemotePort** - The remote port for the tunnel connection. The application will attempt to set the local port to the same port as the remote port, but if the local port is already in use it will select the next available port. *(ex: 5901)*
* **V**, or **VNCPassword** - An 8-char password generated by the VNC server. *(ex: VaK55uol)*

Examples of valid json strings:

* ```{'H':'n0580.ten.osc.edu','R': '5901','U':'an0018','V':'Yh8d89tf'}```
* ```{'RemotePort':'5901','VNCPassword': 'ty56u3J7','PUAServer':'r0004.ten.osc.edu','UserName': 'bmcmichael'}```
