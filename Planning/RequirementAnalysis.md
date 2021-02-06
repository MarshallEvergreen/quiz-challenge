# Planning

Assuming the Essential and Desirable requirements have come from a previous discussion with 
stakeholders / product owners. This document intends to show how I would prioritize the work with the 
goal of getting a minimal viable product into the hands of the product owners / stakeholders to 
start the all important iterative feedback loop with them.

I see the minimum viable product here as having a backend with an api which allows:
* The creation of quizzes.
* The ability for users to take the quizzes.
* The ability for users to retrieve their scores and answers.

An approach I like to take to prioritization is the MoSCoW method where you break down work into
Must do, Should do, Could do and Won't do. Below is the my breakdown of the given requirements into these 
categories with some reasoning given.

Its important to note that these categories are with the aim of getting to the minimum viable product. 
Won't have for example does not mean that it won't be done for example. Just that it's not a priority to the current goal.

### Must Have
Non - negotiable features that are mandatory for the product.

* The backend should be built with containerisation in mind.
  * The clients infrastructure requires the app to be deployed to the cloud via docker.
  * This can be a pain to retrofit so it should be it should definitely be considered as part of the initial design.

* Quizzes can be added to the quiz engine.
  * This is the basis of everything so the ability to have some quizzes to work with gives us a
    base to build upon on.
    
* A user can take available quizzes.
  * Important to get an understanding of what the basic workflow through the software will be.

* A user can retrieve their quiz scores and answers.
  * Another important workflow to start to understand what solutions can be applied.  
    
### Should Have
Important features that are not vital but add significant value.

* Once a person has completed a quiz, they may not do that one again.
  * Important for the final product but not absolutely crucial to get to a minimum viable product. 

### Could Have
Nice to have features that will have a small impact if left out.

* The mean score for a particular quiz for a particular user can be retrieved (to within the same 10% increment)
    (ie if a user scored 57% I would expect to see something like 36% of people completing this quiz also scored between 50 and 60%)
  * The logic for this will most likely be handled by the backend so it would be could to start thinking about how to 
    implement this.

### Won't Have
Features that are not a priority for this specific time frame but could be added in future releases.

* The ability to edit quizzes.
  * There is some contradiction in the given requirements as they state that published quizzes can not be edited
    but that an administrator should be able to edit quizzes.
  * This is not crucial to the functionality of the software and needs little bit more clarification.
    
* Everything to do with the administration area should would need more discussion such as: 
  * Should the backend or front end hand the logic around this area? 
  * Not crucial to getting the workflow correct.