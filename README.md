# Yotaka_Khawkomol testing driven development assignment

## Description
this project consist of following componets:
1. Calculator : A class perform a simple basic arithmetic operations. 
2. String Processor : A class for string manipulation tasks, for example, how to handler with lower cases also with null value. 
3. API : A class for API testing, to get the data from weather service by mocking data.
4. Bank Account :100: A class for bank account, to perform deposit and withdraw.
5. Warehouse handling : A class for warehouse handling, to perform add and remove items from the warehouse.
6. Booking System : A class for booking system, to perform booking available time slot and shows list of booked time slot.
7. Null Kontroll :1234: A class for null kontroll, to perform null check and return the value in boolean  if it is null or null, also shows the list 
which one contains null value.

Under the journy of testing driven development, I have created the test cases for each of the above components and then implemented the code to pass the test cases.
also, use Visual Studio Code as an IDE to perform tasks.

## Requirements
1. Visual Studio Code
2. .NET 6.0 SDK or later
3. MSTest framework for Unit testing
4. NSubstitute packgae to mock data

## Installation
1. Clone the repository
```
git clone https://github.com/Campus-Molndal-CLOH24/Yotaka_FinalTDD.git
```
2. Let the IDE to install the required packages
3. Start testing the components
4. Run the test cases to check the functionality of the components
5. Don't fotget to comment to me if you have any questions or suggestions.
### I am open to any suggestions and feedbacks with my test cases and code. :wink:

## Test Driven Development -  Checkad av NOR. 

till att b�rja med s� ser strukturen p� detta projekt v�ldigt fint ut.
Jag sj�lv har gjort lite annorlunda �n det h�r och m�rker att detta �r mycket b�ttre.

Jag clonade Yotakas project och k�rde hennes tester i alla testklasser och det fungerade bra.
Tycker det ser komplett ut och att alla testerna �r bra skrivna och t�cker alla scenarier.

### Ett f�r�ndringsf�rslag 

jag kan komma p� �r i Null uppgiften, ObjectValidatorTest.cs,
Namnet p� metoden
````csharp
IsNull_ShouldReturnFalse_ForNullObject 
````
Den �r lite missvisande eftersom 
testet inte bara kontrollerar att metoden returnerar false f�r ett null-objekt,
utan ocks� inkluderar scenarier f�r icke-null objekt.
Ett b�ttre namn som beskriver hela testets syfte kan vara t.ex:
````csharp
IsNull_ShouldReturnExpectedResult_ForVariousObjects
````
Alternativt kan testet delas upp i tv� separata metoder f�r att tydligt skilja p� vad som testas, 
ett f�r null-objekt och ett f�r icke-null objekt.

SUPER bra jobbat! :smile: 
Jag f�tt l�ra mig en del sj�lv av att kolla p� detta projektet.
[19:10]
(OBS! denna text skickades privat till Yotaka d� det inte gick att pusha texten till henne.)

<div align="center">
  <img src="https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExdTZ1MW5kYjg0Z3czbHdsanl3NTJqNDN6amJ3MnhuMXBoMjQ0M2gzZCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/4zceKGWTSwv9889U45/giphy.gif" alt="My Image" width="400">
</div>