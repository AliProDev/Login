Feature: Login

@Login
Scenario: launch application and login 
Given launch the application
When input value in username and password
| UserName | Password |
| dbAdmin  | password |
Then logout the application