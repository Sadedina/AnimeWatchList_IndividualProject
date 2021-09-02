# **WPF-Entity Framework C# Project** 

![HomePage](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/HomePage.JPG)

### Project Description

The chosen project is a basic Anime Watchlist for different users.
Users can register themselves into the database, update their details in future or remove themselves within the database.
Users can scroll through and add anime currently in the database to their watchlist. Their tab will be updated automatically with all their anime.
Anime detailed information is displayed below their watchlist.

### Project Goals
The Project Goal is to create a Three-Tier Application, must have:

- a WPF as a front-end, 
- an SQL database back-end (minimum of Two linked tables),
- use Entity Framework to manage the relationship between back-end object model and databases and have a business layer with logic (other than CRUD)
- an adequate amount of Unit tests for the Business layer code, which exercises the normal functionality, boundary and error conditions.

##### MVP - Minimum Viable Product

- Application runs with WPF platform

- User can register, update and delete themselves from system

- User can add and remove anime into watchlist

  

### Project Definition of Done

1. Application runs with WPF platform
2. Code has been reviewed / refactored
3. Code sufficiently commented
4. All defects are resolved
5. Unit test for Business Layer implemented
6. All Unit test for passed
7. Acceptance criteria for each issue met
8. All manual test for functionality passed
9. Documentation of Project is up-to-date



### Sprint 0

##### Designing  Entity Relationship Diagram (ERD)

In Sprint 0, I decided to concentrate majority of my time on designing the ERD. Reason for doing this is to be able to know and create a foundation for the application. Knowing and understanding what needs to be present in the application is essential in the designing process. This limits the time of refactoring during the creating process.

The ERD shown below was created using Draw.io

![ERD](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/erd.JPG)

##### Designing Graphical User Interface (GUI)

After designing the ERD, the next step was to design the front end of the application. Essentially, getting the building blocks for what my program needed, in terms of buttons and functions. Importantly, I was able to think of how to display the information I was going to be printing out in an intuitive way.

The image below is the first sketch of GUI by hand

![WPF](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/WPF%20.png)

The GUI was represented in a User Story formation, Wireframe. to display how the application was going to work and also enable me to find out flaws in the creative zone.

The set of images below are the Wireframe of the application using Fluid.ui

![HomePage1](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Fluidui%201.JPG)

![UserPage1](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Fluidui%202.JPG)

![WatchlistPage1](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Fluidui%203.JPG)

### Sprint 1 

[Tuesday - Wednesday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2003-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2003-08.JPG)

##### Sprint Review

In this sprint, I did not manage to finish all of my sprints backlog set. The completed User Stories for this sprint includes:

- Creating the Database
- Scaffolding the Database
- Set-Up of Visual Studio
- CRUD method for Profiles

Work to put back into Sprint Backlog: 

- User Register - WPF

![Database](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Query.JPG)

### Sprint Retrospective

##### Mood: 8/10

Whilst completing the project during the day, my mood was high. I felt the workload was not too much and I knew exactly what I needed to do.

##### Time Management: 2/3

I think my time management during the day could have been better. Spent more time than should have on the set-up of the User Stories, and I still have a lot of User Stories not clearly defined or relying on other stories.

#####  Work load: 2/3

I think the workload I set myself at the start of the day was achievable. However, I overlooked the fact that creating a working WPF might have been too much. All the worked would have been completed by the end of sprint 1 if I did not have to create a WPF.

##### Blockers: 1/3

In the current Sprint there were two main blockers:

The first issue was after I scaffolded my database and I created the basic set-up of my Visual Studio. I completed the first CRUD for the Profile database. However, when I tried inserting data into my database. There were 10 compiler errors, which could not locate files in the bin folder.

Resolved the issue by deleting the file and starting over again.

The Second issue was trying to keep the ProfileId encapsulated from the code and allowing the user to change their details without seeing an ID. However, every code I tried resulted in a query rather than an iteration.

This issue is still to be solved.

##### Next Step

I know what will help me achieve my goal set for each sprint is to have more communication with the Trainer and evaluating my performance on task throughout the day.



### Sprint 2

[Wednesday - Thursday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2004-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2004-08.JPG)

##### Sprint Review

In this sprint, I manage to finish all of my sprints backlog set. The completed User Stories for this sprint includes from Sprint 1:

- Register User through WPF
- Unique Username 

Work is currently in review as I still have to refactor the code and ensure it is all unit tested

### Sprint Retrospective

##### Mood: 5/10

Whilst completing the project during the day, my mood was average. Started off high as I was finishing the Crud functions (I knew exactly what to do). Then my mood fell low as I, I ran into different blockers which are explained below.

##### Time Management: 3/3

My time management was excellent today. This is because I did not set a lot of User Stories, due to me thinking on how to tackle the WPF implementation. I manage to start implement other CRUD functionality, which were not set into the sprint as I needed them in order to fully implement the WPF user stories.

#####  Work load: 2/3

The workload set was a little low for the day. This is because I thought implementing the WPF would take a lot of time. Which it did. However, I finished them on time for the end of the Sprint 2

##### Blockers: 1/3

In the current Sprint there were a lot of blockers:

Firstly, I solved the blockers of the previous day (changeable username with same personalId). This was solved by referencing the old username to change into the new username. This ensures the ID is completely encapsulated.

As I was trying to implementing the UI, I took reference from a previous code. The Visual Studio started showing errors saying a name did not have a reference, where the name was not even being used. The way I solved this was by restarting the project from scratch.

Before restarting from scratch I tried pulling the previous version from GitHub. However, I accidentally created a new branch, were I was not able to commit my new work to remote location. This was solved by creating a temp branch, merging and deleting them.

##### Next Step

I will try and set an adequate amount of work to do in Sprint 3., so I can maintain a high mood and finish my work on time for the end of the sprints.



### Sprint 3

[Thursday - Friday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2005-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2005-08.JPG)

##### Sprint Review

In this sprint, I manage to finish all of my sprints backlog set. Most of my User stories are in the review section as I have not refactored and tested all of my codes, which are essential for defining my User Stories as done

The user stories completed:

- Adding data into the Anime table

The User Stories under review:

- Register User through WPF
- Update User
- Display Username
- Unique Username
- Delete User

### Sprint Retrospective

##### Mood: 7/10

Whilst completing the project during the day, my mood was above average. I knew exactly what to do and how to implement the code. Therefore, I just got on with my work. It was not very smooth as I did have problem implementing some of the GUI

##### Time Management: 3/3

My time management was excellent today. I manage to finish everything that I set myself for the day.

#####  Work load: 3/3

The workload set was just enough. I did not have time to add comments or refactor my code. However, I accomplished a big part of the project. 

##### Blockers: 3/3

In the current Sprint there were no major blockers. I mainly was going through the process of designing my GUI according to the Wireframe

##### Next Step

I will keep the same workload as I performed well during todays sprint.



































### Sprint 4

[Friday - Saturday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2006-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2006-08.JPG)

##### Sprint Review

In this sprint, I did not manage to finish any of my sprints set, apart from displaying a summary of what the user clicks on their list box. I mainly did CRUD functionality, which was a backend logic implementation for the Watchlist database. This allowed me to complete the MVP set for the project in terms of database used. I also made a new functionality, which was overlooked by the user stories set. This is the ability to set a User on the watchlist page and enable them to carry on doing CRUD functionality on the page without having to reset the user over and over again, during the course of them using the application.

The user stories completed:

- Displaying Summary of Anime the user clicked on

Work to put back into Sprint Backlog: 

- List box feature to view all Anime not in the list
- Add a rating List box with functionality
- Add a watching List box with functionality

#### Class Diagram 

The image below shows the Class Diagram from the database layer and the relationship between them, including all the properties and methods needed for the implementation of the logic.

![Class Diagram](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/ClassDiagram.JPG)

### Sprint Retrospective

##### Mood: 5/10

My mood today was average. This is due to the type of work that was being done. I knew what was expected of me. However, the work I was doing was not particularly exciting and was very repetitive compared to what I have done in the past sprints.  This work needed to be done and took a little time to complete.

##### Time Management: 1/3

My time management was very poor today. This is due to me not realising the amount of work I set myself. Additionally, the implementation of some features took longer to implement than expected.

#####  Work load: 2/3

The work load set was not to much. However, I was not able to finish it due to me taking time to go through the process of implementing a certain feature, which would have benefited the application in the long run.

##### Blockers: 3/3

There were no blockers in todays sprint.

##### Next Step

I reduce the amount of workload done in the next sprint in order to set myself an adequate amount of work.



### Sprint 5

[Saturday - Sunday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2006-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board]()

##### Sprint Review

In this sprint, I manage to finish all of my sprints backlog set. Most of my User stories are in the review section as I have not refactored and tested all of my codes, which are essential for defining my User Stories as done

The user stories completed:

- Adding data into the Anime table

The User Stories under review:

- Register User through WPF
- Update User
- Display Username
- Unique Username
- Delete User

### Sprint Retrospective

##### Mood: 7/10

Whilst completing the project during the day, my mood was above average. I knew exactly what to do and how to implement the code. Therefore, I just got on with my work. It was not very smooth as I did have problem implementing some of the GUI

##### Time Management: 3/3

My time management was excellent today. I manage to finish everything that I set myself for the day.

#####  Work load: 3/3

The workload set was just enough. I did not have time to add comments or refactor my code. However, I accomplished a big part of the project. 

##### Blockers: 3/3

In the current Sprint there were no major blockers. I mainly was going through the process of designing my GUI according to the Wireframe

##### Next Step

I will keep the same workload as I performed well during todays sprint.























































### Sprint 6

[Sunday - Monday ]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2009-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2009-08.JPG)

##### Sprint Review

In this sprint, I was able to add a background layer to the GIU in preparation of the presentation. I was also able to implement the Update function for the Watching and Rating feature. Finally, I implemented the remove button to remove anime from users watchlist. A pop up button was implemented to display to the user that current features were not enabled in this application.

Upon reviewing the application, I implemented I removed the following features:

- Pop up button for Updates, Deletes and Register. 

  This is because I found it very annoying as a consumer to be alerted all the time that I was doing an action on the application. which resulted in slowing down the process when using it.

### Sprint Retrospective

##### Mood: 9/10

Today I was able to implement a lot of features into the application. And apart from a noticeable bug. all the feature were working as expected. which meant I could take it a little easier that I normally do.

##### Time Management: 3/3

My time management was excellent today. I manage to finish everything that I set myself for the day as well as prepare for the upcoming presentation.

#####  Work load: 1/3

The workload was a lot today. However, as the user stories were set in a way that they could be implemented at the same time. The day progressed smoothly.

##### Blockers: 3/3

There were no blockers in todays sprint.



### Sprint 7

[Monday - Tuesday]

##### Kanban Board at the start

![Start Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20morning%2010-08.JPG)

##### Kanban Board at the end

![End Sprint Kanban Board](https://github.com/Sadedina/AnimeWatchList_IndividualProject/blob/main/Images/Sprint%20evening%2010-08.JPG)

##### Sprint Review

In this sprint, I only focused on fixing bugs I discovered, Did some more Unit Testing and finished my documentation and retrospective for the Project

The user stories I did not finish in my project:

- Statistics for Anime watchlist to show User
- Request feature to add more Anime to database

### Sprint Retrospective

##### Mood: 9/10

Today was a light day in comparison to previous day. There was no mush work to do. So I spent most of the time doing extra manual test to catch bugs and updating my documentation.

##### Time Management: 3/3

My time management was excellent today. I manage to finish everything that I set myself for the day.

#####  Work load: 3/3

The was no choice in the amount of workload. As deadline is approaching. But overall , I appreciate the light work

##### Blockers: 3/3

There were no blockers in todays sprint



### In Conclusion

I learnt a lot from this project as to how to set the sprint and the agile methodologies.

My mood overall started high then went low and back high .

Time management was something I struggled with as I encounter a lot of blockers and had to deal with. 

I learnt how to set my sprints at the start of the day and how important defining a good User Story ca be to the overall success of the project.

What I would do differently is analyse my current skills and concentrate on the difficult parts first and the work on the other parts. This will give me enough time to complete the project.





