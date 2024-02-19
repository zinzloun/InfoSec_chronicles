# InfoSec Chronicles from Noobland
<i>PLease note that the linked files are in Cherry Tree format: https://www.giuspen.com/cherrytree</i>

## Chapter 0: Abuse Excel VBA macro, a simple approach
###### 21/07/20 ver 1.2
In this article I will illustrate how to execute a payload loaded from a VBA macro script embedded in an Excel xlsm file.<br>
I did not implement any obfuscation\encrypting technique, this has to be consider as a POC

[Read this story](./chapters/chap0.ctb)

## Chapter 1: Abuse IE to download and execute a payload through PS
###### 13/09/20 ver 1.0
I had to bypass a white list applications execution enviroment, lucky PS scripts were allowed on almost every machine, as well as .Net FW 3.5 executable (not signed).
The client has installed an AV solution, with an host firewall. No IPS\IDS were present on the network (now they are!)

[Read this story](./chapters/chap1.ctb)

##  ~~Chapter 2: Setup a Virtualbox LAB to test Security Onion~~

## Chapter 3: Abuse MSBuild to compile and execute a C# wrapper that, using the Runspace object, executes a Powershell reverse shell
###### 30/09/20 ver 1.0
The test has been carried out against 3 Win10X64 machine, fully patched with different AV software installed.
No encoding\encryption has been implemented. Keeping the things simple actually did the trick

[Read this story](./chapters/chap3.ctb)

## ~~Chapter 4: Configure a DMZ LAB on Vmware Workstation using pfSense firewall~~

## ~~Chapter 5: A simple example of a Test Drive Development solution in VS2019ce~~

##  ~~Chapter 6: WebGoat 8~~


## ~~Chapter 7: Set up a simple PKI using CFSSL~~

##  ~~Chapter 8: Modsecurity 2.9 OWASP CRS~~ 

## Chapter 9: Simda trojan reverse engineering being an amateur
###### 13/09/21 ver 1.0
I created a this story following a course. Prerequisites are:
1. Installed Flare VM: https://github.com/fireeye/flare-vm
2. Basic knowledge of IA32 assembly

<b>Warning: RUN THE MALWARE INSIDE A VIRTUAL ENVIROMENT, USIGN AN HOST ONLY NET CONNECTION. TAKE A SNAPSHOT BEOFRE PROCEED
</b>

[Read this story](./chapters/chap9.ctb)
<br/>
[Download the malware](./simda.7z). Password is: S1md@

## Chapter 10: Get a reverse shell using ngrok
###### 04/04/23 ver 1.0

You could have the necessity to get a reverse shell in a <i>natted</i> enviroment (e.g. your systeme access Internet using an ISP router) and your public IP is not fixed. 
<br>[Read this story](./chapters/chap10.ctb)


 
