# WakeApp
## Назначение
Веб-приложение, предназначенное для удаленного "пробуждения" компьютера по локальной сети (Wake-on-LAN).  
Основная идея заключается в том, что пользователь подключается к локальной сети через VPN по сети Интернет и использует веб-интерфейс приложения для отправки "магического пакета", без необходимости подключения к удаленному рабочему столу какого-либо посредника.  
Разумеется, для реализации функционала необходимо, чтобы целевой компьютер был настроен для работы с Wake-on-LAN.  
  
> **Важно**. Использование Wake-on-LAN возможно непосредственно через VPN, но данное веб-приложение предназначено для случаев, когда *существуют какие-либо ограничения на применение такого способа*.  
## Используемые технологии
На серверной стороне используется C# (.NET Core), клиентская сторона представляет собой веб-страницу, функционирующую на JavaScript.  
## Appointment  
Web application created for remote computer wake up by local network (Wake-on-LAN).  
The basic idea is that the user connects to the local network via VPN over the Internet and uses the web interface of the application to send the "magic packet", without the need for any intermediary to connect to the remote desktop.  
Of course, to implement the functionality, the target computer must be configured to work with Wake-on-LAN.  
  
> **Important**. The use of Wake-on-LAN is possible directly through the VPN, but this web application is intended for cases where *there are any restrictions on the use of this method*.  
## Used technologies
The server side uses C # (.NET Core), the client side is a web page that runs in JavaScript.  
