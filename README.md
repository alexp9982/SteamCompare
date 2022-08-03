# SteamCompare


[Info](#info)

[Getting a Steam API Key](#getting-a-steam-api-key)

[Using the Program](#using-the-program)

[To-Do](#to-do)

[Pull Requests and Issues](#pull-requests-and-issues)

[Credits](#credits)

---

## Info
So this is a little project of mine that uses the brand new .NET MAUI. The application asks for a Steam API key as well as two Steam usernames. This is my first ever actual C# program, so code may be pretty messy. If you think you can simplify the code, or clean it up, please feel free to [make a pull request.](#pull-requests-and-issues)

At this time, MAUI is still very buggy. A big example of that is the fact I can't provide a binary because it won't work, since WinUI3 doesn't support self-contained apps yet. For more information, as well as a possible timeframe of a binary, please refer to the following issues:

[MAUI Issue](https://github.com/dotnet/maui/issues/3166)

[WinUI3 Issue](https://github.com/microsoft/WindowsAppSDK/issues/2684)
 
---

## Getting a Steam API Key

NOTE: Keep your Steam API key a **SECRET**! Do not give it to anyone, as it allows you to do just about anything regarding Steam, which includes making trades.

Step 1. Go to the [Steam API Key site](https://steamcommunity.com/dev/apikey)

![Step 2](Images/Step2.PNG)

Step 2. In the field labeled Domain Name, type in "127.0.0.1". This stands for localhost (since the application will be running on your computer). Ensure the checkbox is checked and click Register.

![Step 3](Images/Step3.PNG)

Step 3. Copy the "Key" field and paste this into the application in the API key field.

---

## Using the Program


### Start Screen

When the program first starts up, you'll be greeted with a welcome screen. Click the Start button to continue.


### API Key Screen

Next you'll see the API Key screen. This is where you'll paste the key from the Steam website (See [here](#getting-a-steam-api-key))


### Comparison Screen

You'll see the comparison screen next. This is where you'll be typing the information of the users you want to compare games with. Type either the numerical SteamID64 number, or their steam username. NOTE: The Steam username is *NOT* the same thing as a display name.


### Results Screen

Once you hit this screen, click the Get Results button to start the process of checking inputs and generating results. If you want to refresh, just hit the button again. NOTE: The amount of time this takes varies based off of internet connection and computer speed.

---

## To-Do

I intend to do everything in this list, however, depending on my schedule, I may or may not implement them.

- Make a Details screen when clicking a game on the results list. The details screen will show additional information about the game, as well as launch the game if requested.
- Ensure the entire program works on a Mac
- Make Android and iOS versions of the program (won't be in app store)

---

## Pull Requests and Issues

If you believe you can help to improve the code, while retaining the same functionality, I welcome you to make a pull request. Anyone is welcome to do this, even newcomers, as I am new to C# as well. When creating a pull request, ensure there are no merge conflicts if possible, and that you detail the changes you made and why you made them. In addition, if the program won't compile as a result of your changes, they will be reverted or declined. Thank you for your help!

If you believe you've come across an issue, feel free to create an issue in the Issues tab. I will try my best to solve it.

---

## Credits

- Microsoft for making [.NET MAUI](https://github.com/dotnet/maui)
- babelshift for translating the [SteamWebAPI to C#](https://github.com/babelshift/SteamWebAPI2)
