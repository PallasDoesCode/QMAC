QMAC
====

[![Build status](https://ci.appveyor.com/api/projects/status/dxigd9ndirm8awmy?svg=true)](https://ci.appveyor.com/project/RandomlyKnighted/qmac)


This project was developed using C# and Windows Presentation Foundation. It was my first WPF application and my first time using the MVVM design pattern. It gives you the ability to quickly get MAC addresses for all wired and wireless network adapters.

I created this project for the IT Department at the DeKalb County Board of Education. They were instituting a new DHCP white list and needed a quick way to get the MAC address for each computer during the set up process. This project was the solution used to resolve that need.


####Dependencies
1. [MVVM Light Toolkit](http://www.mvvmlight.net/)
2. [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged)


####Change log
######v2.0 (Release Coming Soon)
* Displays computer name in addition to the IP address
* User can select multiple schools from the list designating that the computer (more than likely laptop) will travel between schools
* Added textboxes to allow the user to type their username and password (for saving the file(s) on the server)
* User can now choose to save the information locally on the computer
* Added keyboard shortcuts for saving the file(s) locally and for closing the application
* Added a status bar at the bottom of the window to inform the user what is happening

######v1.0
* Displays IP address of computer
* User can select from a list of schools designating which one purchased the computer
* User can export MAC address and computer name from the computer with a click of a button
* Computer information is saved to a text file on a file server
