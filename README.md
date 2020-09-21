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

## Chapter 3: Download an encrypted RS and execute in memory (code in VB.net)
###### 21/09/20 ver 1.0
* The victim
	* Fully patched Win10 pro edition, FW is enabled and managed by the AV software
 	* Download the encoded payload as string through HTTPS
 	* Load the binary in memory and execute it
 
* On the other side (attacker)
 	* Host an encoded (Base64) reverse shell that implements SSLstream (TLS 1.2 as encryption protocol)
 	* Stunnel wait for incoming encrypted request
 	* Got a shell without AV detection
<hr>

<sub>The linked files are in Cherry Tree format: https://www.giuspen.com/cherrytree</sub>
	

 
