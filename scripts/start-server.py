#!/usr/bin/python2
# taken from http://www.piware.de/2011/01/creating-an-https-server-in-python/
# generate server.xml with the following command:
#    openssl req -new -x509 -keyout server.pem -out server.pem -days 365 -nodes
# run as follows:
#    python simple-https-server.py <local IP>
# then in your browser, visit:
#    https://<local IP>:4443

import BaseHTTPServer, SimpleHTTPServer
import ssl
import sys

if len(sys.argv) > 1:
    httpd = BaseHTTPServer.HTTPServer((sys.argv[1], 443), SimpleHTTPServer.SimpleHTTPRequestHandler)
    httpd.socket = ssl.wrap_socket (httpd.socket, certfile='./bundle_wc_K2.pem', server_side=True)
    httpd.serve_forever()    
else:
    print "You must pass the local IP address to bind: " + sys.argv[0] + " 192.168.1.11"

