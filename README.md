# LeapReleaser
This program is created to make the process of creating a release for the Leap game engine faster. It automatically copies all the necessary files from the assigned working directory. The only thing you still need to do is place an example next to the .exe and zip the result. It's important to know that this only works with Visual Studio.


## Usage
Before using the program, ensure that you have both the Release and Debug versions compiled in the Leap engine folder you intend to use for copying.

In the Release tab, you will discover a zip file containing the .exe and an example folder. Unpack this and run the .exe. The program will prompt you to provide the path to your Leap engine directory, for instance, 'D:/LeapEngine.' It will then search for all the necessary files to create a clean release from it.