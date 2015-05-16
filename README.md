# UC_Test_Framework
Supports creating Usecase-based automated tests

Get started by just opening the Solution "Prototype.sln"
The use of this Framework is shown in the "SeleniumTesting" unittest projekt.

#How to get started using the UC_Test_Framework in your own unittest projekt:
1. Add your Unittesting Projekt to the Solution. 
2. Add the Projekt-Reference "UsecaseTesting".
3. Create your Activites by deriving from the Activity class. Setup test data structures if needed.
4. Create custom environments that are used within the usecase test.

# What is UC_Test_Framework

This Framework should accelerate automated testcase creation by modularitation of the testcode. 

The modules should be integrated into one usecase test. Modules are called activites within this Framework. An activity has a specific data-scheme that can hold different data per testcase.  

Whats the difference to a normal unittest? The unittests are good for areas of a application that changes a lot, they are also good to test small parts of the applications. One level further you have integration tests. And on this level you expect stable functionality. On this level the tests only uses unittests to achieve a higher goal: Is my use case working? Does the overall workflow still work?  

The design of the activites are totally depended on the AUT (Application under Test). 

#When should I use UC_Test_Framework? 
It could be used best in a stable application or stable parts of an application. That means it only makes sense in long term applications, that are developed and maintained constantly. 
