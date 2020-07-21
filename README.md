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

