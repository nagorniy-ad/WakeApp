# WakeApp
## Appointment
Web application created for remote computer wake up by local network (Wake-on-LAN).  
  
The basic idea is that the user connects to the local network via VPN over the Internet and uses the web interface of the application to send the "magic packet", without the need for any intermediary to connect to the remote desktop.  
Of course, to implement the functionality, the target computer must be configured to work with Wake-on-LAN.  
  
> **Important**. The use of Wake-on-LAN is possible directly through the VPN, but this web application is intended for cases where *there are any restrictions on the use of this method*.  
## Used technologies
The server side uses C# (.NET Core), the client side is a web page that runs in JavaScript.  
