# Overview
A gPRC service is hosted by a server on port 30051 and allows the outside world to communicate with the QuizEngineCore.

The server can be manually hit using [BloomRPC](https://github.com/uw-labs/bloomrpc) to prove the functionality is working.
A small suite integration tests could be written to prove the communication is working.

Ideally this should be dockerised build which exposes this port from the container.

## Core library
Current has no persistence but provides backend functionality to:
* Add and store Quizzes / Users. 
* Query quizzes available to the user.
* Submit and retrieve quiz results for the user. 

Going forward this would ideally incorporate some data access layer in order to store and persist data. 

## Quiz Engine Service
Compiles the QuizEngine.proto file into a dll that can be used by the other projects.

## Quiz Engine Server
Provides the QuizEngineService class which is derived from the gRPC base class and is a thin wrapper around the core QuizEngine which 
allows its public api to be hit with gRPC requests. 
This service is hosted by the server. 
