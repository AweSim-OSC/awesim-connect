using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Models
{
    // Handles the data for the connection.
    class Connection
    {
        //TODO: Add some handling to ensure inputs at least look valid.
        //TODO: VNC password has 8 chars?
        //TODO: PUA server regex match ten.osc.edu.
        //TODO: SSHHost match *.osc.edu
                
        // EX: nxxxx.ten.osc.edu:8080
        public String PUAServer {get; set; }
        
        // EX: 8080
        public int RedirectPort { get; set; }
        
        // EX: oakley.osc.edu
        public String SSHHost { get; set; }
        
        // EX: an0018
        public String UserName { get; set; }
        
        // EX: XD4F893S
        public String VNCPassword { get; set; }  
    }
}
