# Carer Web - Technical Testing Task

## Scenario
Carer jobs are constantly being added to our website. Using https://www.ceracare.co.uk/ (live website, don't bring it down please) complete the tasks below.

## Task 1
We are going to push changes to the search infrastructure, the functionality should stay the same. In order to ensure we have delivered quality, reliable and stable software what approach should we take?
1. Add a TEST-APPROACH.md explaining your test approach for this task, including different levels & types of test

## Task 2

### Setup
dotnet version (`5.0.203`)   
playwright version (`1.13.0`)
1. Install Playwright CLI (Make sure you have [.Net 5.0](https://dotnet.microsoft.com/download/dotnet/5.0))
```PowerShell
cd Playwright.Task
dotnet build
playwright install
```

### Code
1. Fix the broken test
1. Add a negative scenario
1. Refactor anything you would improve

### Run
1. Open `.proj` in Visual Studio
1. Test Explorer > Run Test   
_Note:_ videos are stored in `Playwright.Task/videos` folder

## Tips
1. Make sure to comment and add details of your thought process and any assumptions you have made
1. Don't spend too long on it (2 hours max)

## On Completion
- Fork and push your changes, then notify the hiring manager   
or
- Clone then zip it up and email to hiring manager
(please do not create a pull request or push to main)
