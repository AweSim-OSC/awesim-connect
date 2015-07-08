![AweSim](./Documentation/img/awesim-small.png)

# Connecting to AweSim
## How to use the AweSim Connect App to Securely Connect a Windows PC to an AweSim Session

AweSim connect is a native windows application written in C# and compiled for .NET 2.0, providing compatibility for Windows versions from XP through Windows 10.

### Why AweSim Connect?

To connect to AweSim services, a secure tunnel to a session is required. This can be done relatively simply in OSX and Linux by using the SSH functionality built into the system, but Windows users have had to configure and use third party applications like PuTTY or Java to access secure resources at OSC. AweSim Connect provides preconfigured management of secure tunnel connections for Windows users, as well as providing a launcher for secure file transfer, VNC, terminal, and web based services.

## Getting Started

#### Download the latest release of `AweSimConnect.exe` from the AweSim Dashboard

[Download Latest Build](https://apps.awesim.org/assets/wiag/connect/latest/AweSimConnect.exe)

#### Save the file to a folder of your choice

When you first run AweSim Connect, an additional folder will be created and four additional files may be added to this folder. These are required for proper functionality of the application. Please ensure that these files are permitted by your IT administrator.

* `plink.exe` is the command-line version of PuTTY and is used by the application to create the secure connection to AweSim resources. 
* `putty.exe` the GUI application of PuTTY is used to provide terminal emulation remote console connections to AweSim resources.
* `vncviewer.exe` is the VNC viewer client used to view a remote desktop session. Currently TurboVNC Viewer 1.2.9beta.
* `WinSCP.exe` AweSim Connect includes WinSCP 5.7.4 as the default SFTP client. AweSim connect also supports the FileZilla Client for SFTP transfers. If FileZilla is installed on your machine, AweSim Connect will attempt to use it, you can override this feature and used the embedded client by selecting the `Use Included SFTP Client` in the Advanced Settings (indicated by the wrench icon).

#### Double-Click the `AweSimConnect.exe` file to run the application

No further installation is required. In the current state, AweSim Connect is entirely deployed by a single executable file.

## Connecting to a Session

The AweSim Connect application can be used to connect to a running session. Sessions are launched through the AweSim web dashboard. AweSim Connect does not have the ability to launch a session.

#### Navigate to the AweSim Dashboard and create a session

Click the button with the globe in the upper-right side of the application to launch a default browser connection to the AweSim Dashboard, or navigate your browser directly to [https://apps.awesim.org/devapps/](https://apps.awesim.org/devapps/).

* AweSim Connect currently supports VNC connections and the web-based COMSOL Server connection.

#### Enter your AweSim Credentials in the text boxes

* Entering your credentials reveals file transfer options and allows you to select a Session type.

### Two ways to Connect

#### Option One: Copy to clipboard

 Click the blue "Connection Information" button associated with your session, then just copy the provided code to your windows clipboard. The application will detect the code and populate the fields for you. Then, just click the lightning bolt icon to connect to your session.

 If your information has been entered correctly, you will be automatically connected to our system. You may see a window open and close briefly, this is the secure tunnel being established. 

* If your password was entered incorrectly on the main form, this window will remain open while the system prompts you for a valid password.


![v0.3guide](https://cloud.githubusercontent.com/assets/2374718/8111048/7281a128-102d-11e5-9d10-2d551bed39e8.png)

#### Option Two: Manually enter the connection data.  

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

* This form includes an optional tag to help you manage multiple tunnels.

![v0.2 Connection](https://cloud.githubusercontent.com/assets/2374718/8045063/d022218a-0dfe-11e5-8571-df87f09285dd.png)

## Secure File Transfer

The AweSim Connect application will detect if you have a supported SFTP client on your system, or use the embedded client, and allow you to connect to securely connect to the AweSim file system over SFTP.

#### Enter your AweSim credentials

#### Click the file transfer button in the bottom left.

If the supported SFTP client is detected, the application will resort to the embedded option. You can enable the embedded option as the default in the Advanced Settings Menu.

* [FileZilla](https://filezilla-project.org/) is currently the supported SFTP client across all operating systems. FileZilla must be installed separately on your system.
Download from: [https://filezilla-project.org/download.php](https://filezilla-project.org/download.php) 

AweSim Connect now uses WinSCP as the SFTP fallback if FileZilla is not detected.  

* [WinSCP](http://winscp.net/eng/index.php) is the embedded SFTP client. If FileZilla is not detected on your system, the AweSim Connect application will deploy and run a WinSCP process. If you prefer to use the WinSCP client you can select the "Use Included SFTP Client" option in the advanced settings menu.

## Developer Notes

* AweSim Connect is built to comply with the Microsoft .NET  runtime 2.0. 2.0 is considered "pure" .NET and the compiled binaries should function without additional dependencies on Windows XP/7/8/8.1/10.
* AweSim Connect is developed using primarily the [C# language](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx).

#### Build Instructions

* Download and install [Visual Studio Community 2013](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Visual Studio includes team support. If you are accustomed to command-line git, download and install [Git for Windows](https://msysgit.github.io/) to gain access to Git Bash.
* Git clone the AweSim Connect repository to your system.
* Open the project in Visual Studio by clicking **File > Open > Project/Solution** and selecting **AweSimConnect.sln** in the file dialog. You can also load the project in Visual Studio by double-clicking the **AweSimConnect.sln** file in the Windows Explorer. 
* Download the required dependencies using the NuGet Package Manager
* Click the button with the green arrow and the word "Start" to build and run the solution.

#### Automatic connection via valid json string.

The application can detect when a properly formatted string is copied to the Windows clipboard and it will automatically parse the input data. In this version, the application can expect 4 inputs. The inputs are case-sensitive.

* **U**, or **UserName** - The AweSim username credential. *(ex: an0018)*
* **H**, or **PUAServer** - The host name of the running session. *(ex: n0580.ten.osc.edu')*
* **R**, or **RemotePort** - The remote port for the tunnel connection. The application will attempt to set the local port to the same port as the remote port, but if the local port is already in use it will select the next available port. *(ex: 5901)*
* **V**, or **VNCPassword** - An 8-char password generated by the VNC server. *(ex: VaK55uol)*

Examples of valid json strings:

* ```{'H':'n0580.ten.osc.edu','R': '5901','U':'an0018','V':'Yh8d89tf'}```
* ```{'RemotePort':'5901','VNCPassword': 'ty56u3J7','PUAServer':'r0004.ten.osc.edu','UserName': 'bmcmichael'}```

#### Automatic connection via command line arguments.

AweSim Connect accepts command line arguments in the pattern:

* ```AweSimConnect.exe <UserName>:<VNCPassword>@<PUAServer>:<RemotePort>```

#### Automatic connection via `awesim://` URI

(v0.50) AweSim Connect has custom URI support planned for future editions. For now, copying an AweSim URI string to the clipboard will activate the parser and populate data in the same manner as the JSON method.
Examples of valid patterns:

* VNC: ```awesim://<UserName>:<VNCPassword>@<PUAServer><RemoteHost>```
* VNC (no user): ```awesim://:<VNCPassword>@<PUAServer><RemoteHost>```
* COMSOL: ```awesim://<UserName>@<PUAServer><RemoteHost>```
* COMSOL (no user): ```awesim://<PUAServer>:<RemoteHost>``` 