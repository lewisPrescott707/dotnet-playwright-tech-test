# Carer Mobile - Technical Testing Task

## Task 1
We are going to push changes to the search infrastructure, the functionality should stay the same. In order to ensure we have delivered quality, reliable and stable software what approach should we take?
1. Add a TEST-APPROACH.md explaining your test approach for this task, including different levels & types of test

## Task 2
1. Fix the broken test
1. Add a negative scenario
1. Refactor anything you would improve

## Tips
1. Cera Care is our company name
1. Make sure to comment and add details of your thought process and any assumptions you have made
1. Don't spend too long on it (2 hours max)

## Setup
- Java
- Maven
- Appium

### Appium
appium version (`1.21.0`)
java version (`1.8.0_291`)
maven version (`3.8.1`)    
Run appium doctor (npm install -g appium-doctor)

### Run Tests
1. `cd wiki`
1. Change DEVICE_NAME in test to be your device (`adb devices`)
1. Start appium server
1. `mvn clean`
1. `mvn test`
