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

<h2 align="center">Test Cases</h2>  
<table >
    <tr>
      <th>Features</th>
      <th>Test Case ID</th>
      <th>Test Description</th>
      <th>Test Steps</th>
      <th>Expected Results</th>
      <th>Test Case Method Coverage</th>
    </tr>
  <tr>
    <td>Login Form</td>
    <td>LOG-1</td>
    <td>Given the application is running,<br> When the login form is visible,<br> Then all elements of the login form should be displayed</td>
    <td>1. Navigate to Login Page <br>2. Verify that all login form elements are visible</td>
    <td> <b>Login Form and it's content are visible:</b> <br> <b>Fields</b>: <sub><br>1. UserEmail input<br> 2.Password Input</sub><br> <b>Buttons</b>:<sub><br> 1. Login Button<br> 2. Sign in with Facebook <br> 3. Sign in with Apple account <br> 4. Sign in with Google account <br> 5. Navigation sign up button <br> 6. Toggle password visibility button</sub><br> <b>Links</b>:<sub><br> 1. Forgot Password</td>
  <td>LoginForm_WebElements_<br>AreVisible</td>
    </tr>
     <tr>
       <td>Login Form</td>
       <td>LOG-2</td>
       <td>Given the user has not entered any credentials,<br> When the user attempts to sign in,<br> Then the user should not be able to sign in and an appropriate error message should be displayed</td>
       <td>1. Navigate to Login Page <br>2. Click on a Login Button without filled input fields</td>
       <td>Error message indicating invalid email and password is displayed</td>
       <td>Login_With_Empty_<br>Credentials_Should_Fail</td>
     </tr> 
      <tr>
        <td>Login Form</td>
        <td>LOG-3</td>
        <td>Given valid user email credentials, when the form is submitted without a password, then the login button should be disabled</td>
        <td>1. Navigate to Login Page<br> 2. Enter User Email credentials <br> 3. Click Login Button</td>
        <td>Button is disabled</td>
        <td>Login_With_Only_Email_<br>Should_Fail</td>
      </tr>
      <tr>
        <td>Login Form</td>
        <td>LOG-4</td>
        <td>Given invalid user email credentials and password, <br>When user attempts to sign in, <br>Then the user should not be able to sign in and an error message should be displayed</td>
        <td>1. Navigate to Login Page<br> 2. Enter invalid User Email credentials and password<br> 3. Click Login Button</td>
        <td>Error message indicating invalid email is displayed</td>
        <td>Login_With_Invalid_Credentials_<br>Should_Fail</td>
      </tr>
      <tr>
        <td>Login Form</td>
        <td>LOG-5</td>
        <td>Given valid user email credentials and password,<br> When user attempts to sign in,<br> Then the user should be able to sign in and be redirected to expected url</td>
        <td> 1. Navigate to Login Page <br> 2. Enter valid User Email and Password <br> 3. Click Login Button</td>
         <td> User is signed in and redirected to expected URL</td>
          <td>Login_With_Valid_Credentials_<br>Redirects_To_Expected_Url</td>
      </tr>
          <tr>
            <td>Login Form</td>
            <td>LOG-6</td>
            <td>Given appropriate third-party app login button,<br> When user clicks on the button,<br> Then the user is redirected to expected third-party URL</td>
            <td>1. Navigate to the Login Page <br>2. Click on a third-party app button|User is redirected to expected URL</td>
            <td>User is redirected to expected URL</td>
            <td>Login_With_Facebook_Button_<br>Redirects_To_Expected_Url <br><br>  Login_With_Apple_Button_<br>Redirects_To_Expected_Url <br><br> Login_With_Google_Button_<br>Redirects_To_Expected_Url</td>
          </tr>
      <tr>
    <td>Login Form</td>
    <td>LOG-7</td>
    <td>Given appropriate sign-up button,<br> When user clicks on the button,<br> Then the user is redirected to expected sign-up page</td>
    <td>1. Navigate to the Login Page <br>2. Click on a sign-up button</td>
    <td>User is redirected to expected URL</td>
    <td>Signup_Button_Clicked_<br>Redirects_To_Expected_Page</td>
</tr>
<tr>
    <td>Login Form</td>
    <td>LOG-8</td>
    <td>Given appropriate 'Forgot Pasword' link,<br> When user clicks on the link,<br> Then the user is redirected to expected password recovery URL</td>
    <td>1. Navigate to the Login Page <br>2. Click on a 'Forgot Password' link</td>
    <td>User is redirected to expected URL</td>
    <td>Forgot_Password_Link_Button_<br>Redirects_To_Expected_Page</td>
</tr>
<tr>
    <td>Login Form</td>
    <td>LOG-9</td>
    <td>Given appropriate Toggle Password visibility button,<br> When user clicks on the button,<br> Then the password credentials visibility changes back and forth</td>
    <td>1. Navigate to the Login Page <br>2. Enter password <br> 3. Click on Toggle Password Visibilty button <br> 4. Verify that password has visible characters <br> 5. Click the Toggle Password Visibly button again. <br> 6. Verify that password characters are obscurred</td>
    <td>Password characters visibility changes back and forth when clicking on a button</td>
    <td>Password_Characters_Visibility_<br>Changes_On_Button_Click</td>
</tr>
</table>
<table>
  <th>Features</th>
  <th>Test Case ID</th>
  <th>Test Description</th>
  <th>Test Steps</th>
  <th>Expected Results</th>
  <th>Test Case Method Coverage</th>
  <tr>
    <td>Register Form</td>
    <td>REG-1</td>
    <td>Given the application is running,<br> When the register form is visible,<br> Then all elements of the register form should be displayed</td>
    <td>1. Navigate to the Register Page <br>2. Verify that register form elements are visible</td>
    <td>Login Form and it's content are visible:<br> Fields:<br><sub>1. UserEmail input<br>2. Password Input<br></sub> Buttons:<br> <sub>1. Sign up Button<br> 2. Sign in with Facebook<br> 3. Sign in with Apple account<br> 4. Sign in with Google account<br> 5. Navigation sign-in button</sub><br> Labels:<br> <sub>1. User consent label</sub><br> CheckBox:<br> <sub>1. User consent CheckBox</td>
    <td>RegisterForm_WebElements_<br>Are_Visible</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-2</td>
    <td>Given the user has not entered any credentials,<br> When user attempts to register,<br> Then the user should not be able to do it and appropriate error message should be displayed</td>
    <td>1. Navigate to Register Page <br>2. Click on a register button</td>
    <td>Error message indicating invalid email and password is displayed</td>
    <td>Register_With_Empty_Credentials_<br>Should_Fail</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-3</td>
    <td>Given a valid user email credentials,<br> When user submits the form,<br> Then the user should not be able to register and appropriate error message should be displayed</td>
    <td>1. Navigate to Register  Page <br>2. Enter User Email credentials <br>3. Click Register button</td>
    <td>Appropriate error message for password input appears</td>
    <td>Register_With_Only_Valid_Email_<br>Should_Fail</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-4</td>
    <td>Given invalid user email credentials and password,<br> When user attempts to register,<br> Then the user should not be able to do it and an error message should be displayed</td>
    <td>1. Navigate to Register Page <br>2. Enter invalid User Email credentials and password  <br>3. Click Register Button</td>
    <td>Error message indicating invalid email is displayed</td>
    <td>Register_With_Invalid_Credentials_<br>Should_Fail</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-5</td>
    <td>Given valid user email credentials and password,<br> When user attempts to register,<br> Then the user is signed-in and redirected to the main page</td>
    <td>1. Navigate to Register Page <br>2. Enter valid User Email credentials and password <br>3. Click on a Register Button</td>
    <td>User is redirected to expected URL with already logged in account</td>
    <td>Register_With_Valid_Credentials_<br>Redirects_To_Expected_Url</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-6</td>
    <td>Given appropriate sign-in button,<br> When user clicks on the button,<br> Then the user is redirected to expected sign-in url</td>
    <td>1. Navigate to Register Page <br> 2. Click on a Log-in button</td>
    <td>User is redirected to expected URL</td>
    <td>Login_With_Facebook_Button_<br>Redirects_To_Expected_Url <br><br> Login_With_Apple_Button_<br>Redirects_To_Expected_Url <br><br> Login_With_Google_Button_<br>Redirects_To_Expected_Url</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-7</td>
    <td>Given appropriate Toggle Password visibility button,<br> When user clicks on the button,<br> Then the password credentials visibility changes back and forth</td>
    <td>1. Navigate to the Register Page <br>2. Enter any password <br> 3. Click on Toggle Password Visibilty button <br> 4. Verify that password has visible characters <br> 5. Click the Toggle Password Visibly button again. <br> 6. Verify that password characters are obscurred</td>
    <td>Password characters visibility changes back and forth when clicking on a button</td>
    <td>Password_Characters_Visibility_<br>Changes_On_Button_Click</td>
</tr>
<tr>
    <td>Register Form</td>
    <td>REG-8</td>
    <td>Given appropriate User Consent Checkbox button,<br> When user clicks on the button,<br> Then the checkbox selection state changes back and forth</td>
    <td>1. Navigate to Register Page <br> 2. Click on a User Consent Checkbox <br> 3. Verify that checkbox is selected <br> 4. Click on User Consent Checkbox again <br> 5. Verify that checkbox is unselected</td>
    <td>Checkbox selection state changes back and forth</td>
    <td>User_Consent_CheckBox_<br>Is_Selected_On_Click</td>
</tr>
</table>








## If you have any constructive feedback about the code and it's structure, feel free to reach me. Thanks!
