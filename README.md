# InfoSec Chronicles from Noobland
## Chapter 0: Abuse Excel VBA macro, a simple approach
###### 21/07/20 ver 1.2
In this article I will illustrate how to execute a payload loaded from a VBA macro script embedded in an Excel xlsm file.<br>
I did not implement any obfuscation\encrypting technique, this has to be consider as a POC.<br>
https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap0.ctb

## Chapter 1: Abuse IE to download and execute a payload through PS
###### 13/09/20 ver 1.0
I had to bypass a white list applications execution enviroment, lucky PS scripts were allowed on almost every machine, as well as .Net FW 3.5 executable (not signed).
The client has installed an AV solution, with an host firewall. No IPS\IDS were present on the network (now they are!).<br>
https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap1.ctb

## Chapter 2: Setup a Virtualbox LAB to test Security Onion
###### 17/09/20 ver 1.0
In oreder to test Security Onion before to install it on production I wrote down some notes, this has to be consider a Homelab and no payed software were used, you can get an evaluation copy of Win 10 enterprise valid for 90 days or just install another light Linux OS like: https://www.bunsenlabs.org. Parrot OS is also used.<br>
https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap2.ctb

## Chapter 3: Abuse MSBuild to compile and execute a C# wrapper that, using the Runspace object, executes a Powershell reverse shell
###### 30/09/20 ver 1.0
The test has been carried out against 3 Win10X64 machine, fully patched with different AV software installed. No encoding\encryption has been implemented. Keeping the things simple actually did the trick. Here the article: https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap3.ctb

## Chapter 4: Configure a DMZ LAB on Vmware Workstation using pfSense firewall
###### 09/12/20 ver 1.0
The LAB setup is composed by 3 VM: the pfSense firewall, a Centos 8 HTTP server and Win7 client. The requirements are:
- Firewall administration should be allowed from the WAN only to the Host machine
- Configure the access to the HTTP server into the DMZ from the LAN and WAN
- The LAN client must able to access in SSH only the Centos server

https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap4.ctb

## Chapter 5: A simple sample Test Drive Development solution in VS2019ce
###### 10/12/20 ver 1.0
The Visual Studio solution is composed by 2 projects:
1. A simple class to validate email, password and credit card datas (class1.cs)
2. A Nunit test class to perform unit test of the class1 (UnitTest1.cs)

https://github.com/zinzloun/InfoSec_chronicles/blob/master/chapters/chap5.ctb
<br/>
Source code is available at: https://github.com/zinzloun/InfoSec_chronicles/blob/master/SampleTDD_src


<hr>

<sub>The linked files are in Cherry Tree format: https://www.giuspen.com/cherrytree</sub>
	

 
