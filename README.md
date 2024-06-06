<h1 align="center"><a href="https://www.selenium.dev/"><img src="https://img.shields.io/badge/-selenium-%43B02A?style=for-the-badge&logo=selenium&logoColor=white" ></a> Tests with  <a href="https://xunit.net/"><img src="https://xunit.net/images/full-logo.svg" width=130></a></h1>

## This repository is a testament to my journey of self-learning, where I have applied the Selenium framework in conjunction with xUnit to perform a series of tests on the OLX website. 
### It serves as a practical demonstration of my acquired skills and understanding of the fundamentals of the automated testing.

<p align="center">
  

</p>

## Insights into the Code Structure
### Page Object Model
The tests incorporated the **Page Object Model (POM)** pattern, a highly recommended approach for website testing. This design pattern improves test maintenance and code management.

Example:  <a href="https://github.com/WojciechMarczewski/OLX-Selenium-Tests/blob/main/PageObjects/LandingPage.cs">LandingPage.cs</a>

### Page Component Object Model
The OLX website presented repeating web elements across various pages. To handle this efficiently and prevent code redundancy, the **Page Component Object Model (PCOM)** was implemented. This crucial feature allowed to prevent code duplication and improved reusability.

Example:  <a href="https://github.com/WojciechMarczewski/OLX-Selenium-Tests/blob/main/PageComponentObjects/SearchBoxComponent.cs">SearchBoxComponent.cs</a>
### Extensions
To further enhance the efficiency of the tests, extensions for web elements were used. These extensions encapsulated recurring method calls during testing, promoting cleaner and more readable code.

Example: <a href="https://github.com/WojciechMarczewski/OLX-Selenium-Tests/blob/main/Helpers/WebDriverExtensions.cs">WebDriverExtensions.cs</a>

### Data Driven Tests
Tests are powered by a data source, which can either come directly from a simple InlineData method attribute or from Excel files containing prepared data. This approach allows for the creation of more flexible and scalable tests that can be easily adapted to various data sets.

Example: <a href="https://github.com/WojciechMarczewski/OLX-Selenium-Tests/blob/main/PageTests/LoginPageTests.cs">LoginPageTests.cs</a>
### Abstraction
Code redundancy was reduced through the use of abstract classes that implement recurring methods found in many similar objects. This approach enhances code readability, simplifies maintenance, and boosts the efficiency of test creation.

Example: <a href="https://github.com/WojciechMarczewski/OLX-Selenium-Tests/blob/main/PageTests/PageTestBase.cs">PageTestBase.cs</a>

### On Test Failure Screenshots
Test logic inside test methods is wrapped by another method implemented in PageTestBase.cs - UITest(), which catches test failures and saves captured screenshots in the app directory.

<br>
<br>

## Test Cases

|Features|Test Case ID|Test Description|Test Steps|Expected Results|Test Case Method Coverage
|--------|:----------:|:--------:|:-----------------:|:--------------:|:-----------------------
|Login Form| LOG-1| Given the application is running,<br> When the login form is visible,<br> Then all elements of the login form should be displayed|1. Navigate to Login Page <br>2. Verify that all login form elements are visible| **Login Form and it's content are visible:** <br>**Fields**: <sub><br>1. UserEmail input<br> 2.Password Input</sub><br> **Buttons**:<sub><br> 1. Login Button<br> 2. Sign in with Facebook <br> 3. Sign in with Apple account <br> 4. Sign in with Google account <br> 5. Navigation sign up button <br> 6. Toggle password visibility button</sub><br> **Links**:<sub><br> 1. Forgot Password|LoginForm_WebElements_AreVisible
|Login Form|LOG-2|Given the user has not entered any credentials,<br> When the user attempts to sign in,<br> Then the user should not be able to sign in and an appropriate error message should be displayed|1. Navigate to Login Page <br>2. Click on a Login Button without filled input fields| Error message indicating invalid email and password is displayed|Login_With_Empty_Credentials_Should_Fail
|Login Form|LOG-3|Given valid user email credentials, when the form is submitted without a password, then the login button should be disabled|1. Navigate to Login Page<br> 2. Enter User Email credentials <br> 3. Click Login Button|Button is disabled|Login_With_Only_Email_Should_Fail
|Login Form|LOG-4|Given invalid user email credentials and password, <br>When user attempts to sign in, <br>Then the user should not be able to sign in and an error message should be displayed|1. Navigate to Login Page<br> 2. Enter invalid User Email credentials and password<br> 3. Click Login Button|Error message indicating invalid email is displayed|Login_With_Invalid_Credentials_Should_Fail
|Login Form|LOG-5|Given valid user email credentials and password,<br> When user attempts to sign in,<br> Then the user should be able to sign in and be redirected to expected url|1. Navigate to Login Page <br> 2. Enter valid User Email and Password <Bbr> 3. Click Login Button| User is signed in and redirected to expected URL|Login_With_Valid_Credentials_Redirects_To_Expected_Url
|Login Form|LOG-6|Given appropriate third-party app login button,<br> When user clicks on the button,<br> Then the user is redirected to expected third-party URL|1. Navigate to the Login Page <br>2. Click on a third-party app button|User is redirected to expected URL|Login_With_Facebook_Button_Redirects_To_Expected_Url <br> Login_With_Apple_Button_Redirects_To_Expected_Url <br> Login_With_Google_Button_Redirects_To_Expected_Url
|Login Form|LOG-7|Given appropriate sign-up button,<br> When user clicks on the button,<br> Then the user is redirected to expected sign-up page|1. Navigate to the Login Page <br>2. Click on a sign-up button| User is redirected to expected URL| Signup_Button_Clicked_Redirects_To_Expected_Page
|Login Form|LOG-8|Given appropriate 'Forgot Pasword' link,<br> When user clicks on the link,<br> Then the user is redirected to expected password recovery URL|1. Navigate to the Login Page <br>2. Click on a 'Forgot Password' link|User is redirected to expected URL|Forgot_Password_Link_Button_Redirects_To_Expected_Page
|Login Form|LOG-9|Given appropriate Toggle Password visibility button,<br> When user clicks on the button,<br> Then the password credentials visibility changes back and forth|<sub>1. Navigate to the Login Page <br>2. Enter password <br> 3. Click on Toggle Password Visibilty button <br> 4. Verify that password has visible characters <br> 5. Click the Toggle Password Visibly button again. <br> 6. Verify that password characters are obscurred|Password characters visibility changes back and forth when clicking on a button|Password_Characters_Visibility_Changes_On_Button_Click

|Features|Test Case ID|Test Description|Test Steps|Expected Results|Test Case Method Coverage
|--------|:----------:|:--------:|:-----------------:|:--------------:|:-----------------------
|Register Form|REG-1|Given the application is running,<br> When the register form is visible,<br> Then all elements of the register form should be displayed| 1. Navigate to the Register Page <br>2. Verify that register form elements are visible| **Login Form and it's content are visible:** <br> **Fields:** <br><sub>1. UserEmail input<br>2. Password Input<br></sub> **Buttons:** <br> <sub>1. Sign up Button<br> 2. Sign in with Facebook<br> 3. Sign in with Apple account<br> 4. Sign in with Google account<br> 5. Navigation sign-in button</sub><br> **Labels:** <br> <sub>1. User consent label</sub><br> **CheckBox:** <br> <sub>1. User consent CheckBox|RegisterForm_WebElements_Are_Visible
|Register Form|REG-2|Given the user has not entered any credentials,<br> When user attempts to register,<br> Then the user should not be able to do it and appropriate error message should be displayed|1. Navigate to Register Page <br>2. Click on a register button|Error message indicating invalid email and password is displayed|Register_With_Empty_Credentials_Should_Fail  
|Register Form|REG-3|Given a valid user email credentials,<br> When user submits the form,<br> Then the user should not be able to register and appropriate error message should be displayed|1. Navigate to Register  Page <br>2. Enter User Email credentials <br>3. Click Register button| Appropriate error message for password input appears| Register_With_Only_Valid_Email_Should_Fail
|Register Form|REG-4|Given invalid user email credentials and password,<br> When user attempts to register,<br> Then the user should not be able to do it and an error message should be displayed|1. Navigate to Register Page <br>2. Enter invalid User Email credentials and password  <br>3. Click Register Button| Error message indicating invalid email is displayed|Register_With_Invalid_Credentials_Should_Fail
|Register Form|REG-5|Given valid user email credentials and password,<br> When user attempts to register,<br> Then the user is signed-in and redirected to the main page|1. Navigate to Register Page <br>2. Enter valid User Email credentials and password <br>3. Click on a Register Button| User is redirected to expected URL with already logged in account|Register_With_Valid_Credentials_Redirects_To_Expected_Url
|Register Form|REG-6|Given appropriate sign-in button,<br> When user clicks on the button,<br> Then the user is redirected to expected sign-in url|1. Navigate to Register Page <br> 2. Click on a Log-in button|User is redirected to expected URL|Login_With_Facebook_Button_Redirects_To_Expected_Url <br> Login_With_Apple_Button_Redirects_To_Expected_Url <br>Login_With_Google_Button_Redirects_To_Expected_Url
|Register Form|REG-7|Given appropriate Toggle Password visibility button,<br> When user clicks on the button,<br> Then the password credentials visibility changes back and forth|<sub> 1. Navigate to the Register Page <br>2. Enter any password <br> 3. Click on Toggle Password Visibilty button <br> 4. Verify that password has visible characters <br> 5. Click the Toggle Password Visibly button again. <br> 6. Verify that password characters are obscurred |Password characters visibility changes back and forth when clicking on a button|Password_Characters_Visibility_Changes_On_Button_Click
|Register Form|REG-8|Given appropriate User Consent Checkbox button,<br> When user clicks on the button,<br> Then the checkbox selection state changes back and forth|<sub>1. Navigate to Register Page <br> 2. Click on a User Consent Checkbox <br> 3. Verify that checkbox is selected <br> 4. Click on User Consent Checkbox again <br> 5. Verify that checkbox is unselected| Checkbox selection state changes back and forth|User_Consent_CheckBox_Is_Selected_On_Click






## If you have any constructive feedback about the code and it's structure, feel free to reach me. Thanks!
