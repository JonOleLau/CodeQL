##JAVA


#SQL_Injection2
java dir includes a \lib librarary, that should contain the latest sqlite JDBC release to create a database in-memory, if not it can be found here:
https://github.com/xerial/sqlite-jdbc/releases
and should lead to the same path found in .vscode/settings.json

Testing the vulnrability:
try writing "' OR 1=1 --" in the field and if the application is vulnerable to SQL injection, this input will return all records in the database instead of just the record with the username entered.

#XSS2
For ease of use the XSS application XSS2.java doesent acually run in the broswer, but it uses html code. you can write normal text and see it displayed or you can test the vulnrability with the following injections:
"<script>alert("XSS")</script>"
"<img src="nonexistent-image.jpg" onerror="alert('XSS')">"


#CSRF2
The following code is just an example of how CSRF1 would work in a real world senario. the user visits the "Attacker Site" and clicks the "Click me for free stuff!" button. This button has an action listener that simulates the CSRF attack by directly calling the same action that transfers funds (shown by the "Funds transferred!" message).

#Remote_code
This code has the following:
1. Deserialization (lines 9-12): Untrusted data is deserialized, allowing attackers to craft malicious objects and execute arbitrary code.
2. Runtime.exec() (lines 20-22): Shell commands are executed, enabling attackers to inject commands and perform remote code execution (RCE).
3. Reflection (lines 25-39): Java reflection creates class instances, posing security risks if attackers control the class name or behavior, leading to arbitrary code execution

#SSRF
This code performs a simple HTTP GET request to a user-specified URL and prints the response code and body.
example try writing : "https://www.example.com" when prompted




##Js/ts

#SQL injection2
this app is run with React in the Folder sql_injection2
if the attacker entered "'; DROP TABLE users; --," the resulting query would be:

SELECT * FROM users WHERE username=''; DROP TABLE users; --'

#xss
this file contains 3 vulnrabilites
1. Unsanitized user input: Enter the following message in the input field and click the "Display Message" button: "<script>alert('XSS')</script>" or "<img src="nonexistent-image.jpg" onerror="alert('XSS')">"
2. Injected script in URL: and add the following query string to the URL: " ?param=<script>alert('XSS')</script> " 
3.  The displayImage method is vulnerable to cross-site scripting (XSS) attacks because it uses unsanitized user input to generate HTML content. This allows an attacker to inject malicious code, such as a script tag, into the generated HTML and execute it in the context of the web page.
