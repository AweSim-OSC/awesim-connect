using Tamir.SharpSsh;
using Tamir.SharpSsh.jsch;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Users the Tamir.SharpSSH to provide connectivity checks.
    /// </summary>
    class SSHController
    {

        public static bool CheckSSHConnectionToHost(string host)
        {
            try
            {
                SshShell ssh = new SshShell(host, "AweSim");
                ssh.Connect();
                var connected = ssh.Connected;
                ssh.Close();
                return connected;
            }
            catch (JSchException sshException)
            {
                if (sshException.Message == "Auth fail")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string CheckSSHConnectionToHostMessage(string host)
        {
            try
            {
                SshShell ssh = new SshShell(host, "AweSim");
                ssh.Connect();
                ssh.Close();
                return "Connected";
            }
            catch (JSchException sshException)
            {
                return sshException.Message;
            }
        }
    }
}
