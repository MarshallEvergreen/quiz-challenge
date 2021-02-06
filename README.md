# quiz-challenge

## Summary
A popular TV show has asked us to build a website that will allow them to publish quizzes. 

### Essential Requirements

* Each quiz will consist of a variable number of multiple choice questions.
* Each question will consist of 4 possible answers.
* Every person taking part in a quiz will have their results stored (and made retrievable) by email address.
* Once a person has completed a quiz, they may not do that one again.
* After a user has completed a quiz the total score can be retrieved.
* Once a quiz has been published it can not be edited only deleted.
* A facillity to retrieve all quizzes completed by a user as well as the answers submitted.

### Desirable Requirements
* Quiz engine needs an administration area. 
* The admin area must allow the creation, publishing, editting and deletion of quizzes and questions.
* The admin area only needs a single admin user with simple username/password authentication.
* The mean score for a particular quiz for a particular user can be retrieved (to within the same 10% increment)
(ie if a user scored 57% I would expect to see something like 36% of people completing this quiz also scored between 50 and 60%)
* The client uses cloud infrastruture and requires that the backend and supporting databases are containerised with docker.s

### Task 

* Work out a solution for building the quiz engine backend. 
* No front-end ui is required. 
* You many use any backend language and database solution of your choice. 
