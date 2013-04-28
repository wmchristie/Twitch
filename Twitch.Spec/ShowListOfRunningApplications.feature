Feature: ShowListOfRunningApplications
	In order to make mode switching more efficient
	As a keyboardist
	I want to type a chord and see a list of open applications that can be activated without a mouse

Background: A specified list of applications are running thereby making them the most recently activated
Given notepad is opened on testfile1.txt
And notepad is opened on testfile2.txt

Scenario: Show the list of running applications
When the chord is pressed
Then a window is displayed that lists the running applications

Scenario: The running application list is sorted in descending order of last activation
When the chord is pressed
Then the list of running applications is sorted in descending order of most recent activation

Scenario: The running application list is numbered
When the chord is pressed
Then each item in the list or running applications displays a number from 1 to Z (base 37)

Scenario: an application will be activated by typing it's number
When the chord is pressed
And the 2 key is pressed
Then the application instance assigned the number 2 is activated

