# InfoSec_chronicles
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
I used a file system object to write the source code of the shell to the user temp folder
```
    Dim path As String
    path = Environ("Temp")
    Dim FSO As Object
    Set FSO = CreateObject("Scripting.FileSystemObject")
    Dim oFile As Object
    Set oFile = FSO.CreateTextFile(path & "\mal.cs")
```
* I used the same technique to get the port that is parametric and to initialize the wscript shell object<br>
![Screenshot](screen/propxlsm.png)
```
    shellObj = ActiveWorkbook.BuiltinDocumentProperties(4)`
    wSo = CreateObject(shellObj)`
```

