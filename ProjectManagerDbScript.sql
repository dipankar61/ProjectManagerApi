
CREATE TABLE [User]
(
  [User_ID] int primary key identity(1,1) not null, 
  FirstName varchar(30) not null, 
  LastName varchar(30) not null, 
  Employee_ID int not null
 
);

CREATE TABLE ParentTask
(
  Parent_ID int primary key identity(1,1) not null, 
  TaskName varchar(30) not null
);

CREATE TABLE Project
(
  Project_ID int primary key identity(1,1), 
  ProjectName varchar(100) not null,
  StartDate datetime null,
  EndDate datetime null,
  [Priority] int,
  [User_ID] int  null,
  FOREIGN KEY([User_ID]) REFERENCES [User]([User_ID]),
);

CREATE TABLE Task
(
  Task_ID int primary key identity(1,1), 
  TaskName varchar(30) not null, 
  [Status] varchar(30) null, 
  [Priority] int,
  Parent_ID int null,
  Project_ID int not null,
  [User_ID] int  not null,
  [Start_Date] datetime not null,
  End_Date datetime not null,
  FOREIGN KEY(Parent_ID) REFERENCES ParentTask(Parent_ID),
  FOREIGN KEY(Project_ID) REFERENCES Project(Project_ID),
  FOREIGN KEY([User_ID]) REFERENCES [User]([User_ID]),
);



