<h1 align="center"> Selenium Tests with xUnit</h1>

## This repository is a testament to my journey of self-learning, where I have applied the Selenium framework in conjunction with xUnit to perform a series of tests on the OLX website. 
### It serves as a practical demonstration of my acquired skills and understanding of the fundamentals of the automated testing.


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


### Abstraction
Code redundancy was reduced through the use of abstract classes that implement recurring methods found in many similar objects. This approach enhances code readability, simplifies maintenance, and boosts the efficiency of test creation.


<br>
<br>
## If you have any constructive feedback about the code and it's structure, feel free to reach me. Thanks!
