This document will give an overview of the project.

# Project Description #

This project is a solution to organize and manage Judo Kata tournaments.

## Solution Architecture ##
The solution is based on a **client/server architecture**:
The server concentrates on the championships administration while the client part is more an user interface (UI) to introduce and save the result of the competitions.

### Server ###
The server consists of 2 major parts:
  1. The first one, is the **administration of the competitions**. The administrator can create a championship, manage the Judo Kata techniques, write down notes and important remarks for the judges to establish a regulation. Furthermore, the server handles the registration of the championship participators (judges and competitors).
  1. The second part, is the **record of the championship results**. The server centralizes the results of the competitions introduced by the judges through the client application. Once saved in the database, results can be used for statistics and reports.

Many clients can be remotely connected with the server.

### Client ###
The client is a user interface specialized to introduce and and save the result of each judo kata demonstration. The principle is simple. Each judge assets and notes each Judo techniques. At the end of the Kata demonstration, each judge submit their evaluation to the server by the used of the user interface. The results are centralized by the server and saved for futures statistics and reports. (Statistics and reports can be exctracted on the server side).