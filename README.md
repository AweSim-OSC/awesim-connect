![AweSim](./Documentation/img/awesim-small.png)

# AweSim Connect

## How to use the AweSim Connect App to Securely Connect a Windows PC to an AweSim Session

AweSim connect is a native windows application written in C# and compiled for .NET 2.0, providing compatibility for Windows versions from XP through Windows 10.

### Why AweSim Connect?

To connect to AweSim services, a secure tunnel to a session is required. This can be done relatively simply in OSX and Linux by using the SSH functionality built into the system, but Windows users have had to configure and use third party applications like PuTTY or Java to access secure resources at OSC. AweSim Connect provides preconfigured management of secure tunnel connections for Windows users, as well as providing a launcher for secure file transfer, VNC, terminal, and web based services.

## Getting Started

#### Download the latest release of `AweSimConnect.exe` from the AweSim Dashboard

[Download Latest Build](https://apps.awesim.org/assets/wiag/connect/latest/AweSimConnect.exe)

#### Save the file to a folder of your choice

When you first run AweSim Connect, an temporary folder with four additional files will be added to this folder. These are required for proper functionality of the application. Please ensure that these files are permitted by your IT administrator.

* `plink.exe` is the command-line version of PuTTY and is used by the application to create the secure connection to AweSim resources. (version 0.65)
* `putty.exe` the GUI application of PuTTY is used to provide terminal emulation remote console connections to AweSim resources. (version 0.65)
* `vncviewer.exe` is the VNC viewer client used to view a remote desktop session. Currently TurboVNC Viewer 2.0.
* `WinSCP.exe` AweSim Connect includes WinSCP 5.7.5 as the default SFTP client.

#### Double-Click the `AweSimConnect.exe` file to run the application

No further installation is required. In the current state, AweSim Connect is entirely deployed by a single executable file.

The application will have to be run once manually to provide support for launching sessions through the custom URI scheme.

## Connecting to a Session

The AweSim Connect application can be used to connect to a running session. Sessions are launched through the AweSim web dashboard. AweSim Connect does not have the ability to launch a new session.

#### Navigate to the AweSim Dashboard and create a session

Click the button with the globe in the upper-right side of the application to launch a default browser connection to the AweSim Dashboard, or navigate your browser directly to [https://apps.awesim.org/devapps/](https://apps.awesim.org/devapps/).

* AweSim Connect currently supports VNC connections and the web-based COMSOL Server connection.

#### Enter your AweSim Credentials in the text boxes

* Entering your credentials reveals file transfer options and allows you to select a Session type.

### Three ways to Connect

#### Option One: Click the `awesim://` link.

 AweSim Connect supports a custom URI scheme that is registered when you launch the application. After the app is run once, just click the link provided in the Session App to launch AweSim Connect and populate the configuration information. Then, just click the lightning bolt icon to connect to your session.

#### Option Two: Copy to clipboard

 Click the blue "Connection Information" button associated with your session, then just copy the provided code to your windows clipboard. The application will detect the code and populate the fields for you. Then, just click the lightning bolt icon to connect to your session.

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

#### Connection Window

Once the connection is established, you will be presented with a connection window that provides the detail of the connection. Look for the icon on the right to display a shield if a secure connection is detected, or an 'x' icon if the connection is closed.

* Using the instructions in the form, connect to the resource, alternatively, click the grey icon on the right to launch the included service.

* Click the red button to disconnect the tunnel.

* This form includes an optional tag to help you manage multiple tunnels across windows.

![v0.2 Connection](https://cloud.githubusercontent.com/assets/2374718/8045063/d022218a-0dfe-11e5-8571-df87f09285dd.png)

## Settings and Automation options

The settings menu (indicated by the wrench icon) contains several configuration options to modify the behavior of the application.

### Connection Settings

#### SSH Host

Use this dropdown to select the default host. Selecting a server here will change the endpoint for tunneling, sftp connections, console connections, and connectivity checking. ( Default: oakley.osc.edu )

### System Settings

#### Detect Clipboard Activity

When this option is enabled, the application will detect valid data on the Windows clipboard and populate the application. ( Default: On )

#### Use Included SFTP Client

When this options is checked, the application will use the embedded SFTP client as the default client. ( Default: Off )

### Automation Settings

Several automation functions are available to reduce the amount of interaction required with the AweSim Connect application.

#### Save User Credentials

When checked, allows the application to remember the user when the application is reopened. This saves the user credentials to the user settings using DPAPI Encryption. Passwords are decrypted only by current the Windows user account. ( Default: Off )

#### Launch Tunnel on Import

When checked, the tunnel will automatically connect when the application detects a valid clipboard string and the user credentials have been entered. ( Default: Off )

#### Automatically Open Session

When checked, the application will automatically launch a browser or vnc session when the tunnel is detected.

## Secure File Transfer

The AweSim Connect application will detect if you have a supported SFTP client on your system, or use the embedded client, and allow you to connect to securely connect to the AweSim file system over SFTP.

#### Enter your AweSim credentials

#### Click the file transfer button in the bottom left.

AweSim Connect now uses WinSCP as the default SFTP client.

* [WinSCP](http://winscp.net/eng/index.php) is the embedded SFTP client. The AweSim Connect application will deploy and run a WinSCP process.

## Developer Notes

* AweSim Connect is built to comply with the Microsoft .NET  runtime 2.0. 2.0 is considered "pure" .NET and the compiled binaries should function without additional dependencies on Windows XP/7/8/8.1/10.
* AweSim Connect is developed using primarily the [C# language](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx).

#### Build Instructions

* Download and install [Visual Studio Community 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Visual Studio includes team support. If you are accustomed to command-line git, download and install [Git for Windows](https://msysgit.github.io/) to gain access to Git Bash.
* `git clone` the AweSim Connect repository to your system.
* Open the project in Visual Studio by clicking **File > Open > Project/Solution** and selecting **AweSimConnect.sln** in the file dialog. You can also load the project in Visual Studio by double-clicking the **AweSimConnect.sln** file in the Windows Explorer.
* Download the required dependencies using the NuGet Package Manager
* Click the button with the green arrow and the word "Start" to build and run the solution.

#### Version Checking

* The deployment folder currently hosts a php file that returns the windows assembly file info.

This file returns a string response with the current windows assembly file version of the executable in the deployment folder.
This process is dynamic, so updating the executable in the deployment folder automatically updates the response.
The app uses this response to determine if the deployed version is newer than the client version.

* https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php

#### Usage Tracking

* As of version 0.72, calls made to awesimconnectversion.php will include a GET parameter request containing the text of the username box as param['user']. These calls can then be parsed in the future to track app launches and users.

Logs are retained for one year in `ssl_access_log.*` at `/var/log/httpd/apps.awesim.org` on `websvcs02.osc.edu`. Access logs prior to September 30th, 2015 are available in the same path on `websvcs06.osc.edu`.

For access data:

````
	ssh websvcs02.osc.edu
	cd /var/log/httpd/apps.awesim.org
	zgrep 'awesimconnectversion.php' *
````

This command will need to be modified to distill data for reporting purposes.

#### Automatic connection via `awesim://` URI

AweSim Connect has custom URI support. Run the application once to enable this feature. Clicking an AweSim URI provided by the web session manager will activate and populate the application with connection data.

Examples of valid patterns:

* VNC: ```awesim://<UserName>:<VNCPassword>@<PUAServer><RemoteHost>```
* VNC (no user): ```awesim://:<VNCPassword>@<PUAServer><RemoteHost>```
* COMSOL: ```awesim://<UserName>@<PUAServer><RemoteHost>```
* COMSOL (no user): ```awesim://<PUAServer>:<RemoteHost>```

#### Automatic connection via command line arguments.

AweSim Connect accepts command line arguments in the patterns:

* ```AweSimConnect.exe <UserName>:<VNCPassword>@<PUAServer>:<RemotePort>```
* ```AweSimConnect.exe :<VNCPassword>@<PUAServer>:<RemotePort>```
* ```AweSimConnect.exe <UserName>@<PUAServer>:<RemotePort>```
* ```AweSimConnect.exe <PUAServer>:<RemotePort>```

#### [Deprecated] Automatic connection via valid json string.

The application can detect when a properly formatted string is copied to the Windows clipboard and it will automatically parse the input data. In this version, the application can expect 4 inputs. The inputs are case-sensitive.

* **U**, or **UserName** - The AweSim username credential. *(ex: an0018)*
* **H**, or **PUAServer** - The host name of the running session. *(ex: n0580.ten.osc.edu')*
* **R**, or **RemotePort** - The remote port for the tunnel connection. The application will attempt to set the local port to the same port as the remote port, but if the local port is already in use it will select the next available port. *(ex: 5901)*
* **V**, or **VNCPassword** - An 8-char password generated by the VNC server. *(ex: VaK55uol)*

Examples of valid json strings:

* ```{'H':'n0580.ten.osc.edu','R': '5901','U':'an0018','V':'Yh8d89tf'}```
* ```{'RemotePort':'5901','VNCPassword': 'ty56u3J7','PUAServer':'r0004.ten.osc.edu','UserName': 'bmcmichael'}```
