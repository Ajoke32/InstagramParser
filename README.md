

## Getting Started

 - Clone application

```bash
git clone https://github.com/Ajoke32/InstagramParser.git
```
 - Open solution folder
 - Open project folder
 - Open terminal

Run application:

```bash
dotnet run 
```

## Requirements

- .NET CLI (https://dotnet.microsoft.com/en-us/download/)
- Selenium WebDriver

## Usage

After the application starts, you need to choose the appropriate action using the console interface

After you select the login option, you will be prompted to enter your username and password.
 After successful authorization, you will be provided with additional functionality of the application:
- Parsing data about your followers
- Parsing of follower data of any account (you must provide a link)

I recommend choosing option 2, because it will speed up the work. (The application will not need to close modal windows and switch to your account).
When you choose the parsing method you want, the application will start collecting user data.
I recommend keeping the browser window open in full screen

After collecting information about subscribers, you will be able to save this data in JSON format

## Additional info
- iIf the console is empty, you need to wait a few seconds. If something goes wrong, an error will be generated and the application will terminate