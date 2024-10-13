drop table ApplicationUsers
drop table courses
drop table departments
drop table professors
drop table students
drop table tasks
drop table teachingassistants

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL,
    HeadID char(14) NULL 
);

CREATE TABLE ApplicationUsers (
    NationalID char(14) PRIMARY KEY,
    RecoveryEmail NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(50),
    Gender bit,
    [Password] NVARCHAR(50) NOT NULL,
    [Role] NVARCHAR(50) NOT NULL,
    Picture VARBINARY(MAX) NULL,
    FirstName NVARCHAR(30) not null,
    LastName NVARCHAR(30) not null -- 2nd + 3rd + 4th
);

CREATE TABLE Professors (
    ProfessorID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUsers(NationalID) on delete cascade on update cascade ,
    PhDAt NVARCHAR(50) NOT NULL,
    EnterYear INT NOT NULL,
    OfficeLocation NVARCHAR(50),
    DocUni NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Departments(DepartmentID) on delete set default on update cascade
); 


CREATE TABLE Students (
    NationalID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUsers(NationalID) on delete cascade on update cascade,
	StudentId nvarchar(15) NOT NULL , -- By Default contains the NationalID , after the student registrain will be ended => the admin chages it to a new one.
    EntryYear Date NOT NULL,
    GradYear Date NULL,
    [CurrentState] bit, -- Pass 0 / Continous 1 NY
    [CollegeState] bit, -- Student 0 / Graduated 1 
    CurrentYear smallint CHECK (CurrentYear IN (1, 2, 3, 4)),
    TotalGPA DECIMAL NULL,
    HoursTaken int NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID) on delete set null on update cascade
);



CREATE TABLE TeachingAssistants (
    TAID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUsers(NationalID) on delete cascade on update cascade ,
    AcademicDegree NVARCHAR(50) NOT NULL,
    University NVARCHAR(50) NOT NULL,
    Faculty NVARCHAR(50) NOT NULL,
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Departments(DepartmentID) on delete set default on update cascade ,
    AssistingProfessorID char(14) FOREIGN KEY REFERENCES ApplicationUsers(NationalID) 
);


CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    Code nVARCHAR(10) UNIQUE NOT NULL,
    [Hours] INT NOT NULL,
	PrerequisiteCourseId INT FOREIGN KEY REFERENCES Courses(CourseID),  
	Semseter bit Not Null , -- The course Semester => 0 = 1st , 1 = 2nd
    CourseLevel INT NOT NULL , ---
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Departments(DepartmentID) on delete set default on update cascade
);

CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID) on delete cascade on update cascade,
    Grade DECIMAL(4 , 2) NOT NULL,
    Deadline DATETIME NOT NULL,
    Content NVARCHAR(50) NOT NULL, -- The Task Link (Like PDF document in Google Drive) --
    [Type] NVARCHAR(50) CHECK ([Type] IN ('Project', 'Assignment')) NOT NULL,
    AssignedByTAID char(14) FOREIGN KEY REFERENCES TeachingAssistants(TAID) 
);

CREATE TABLE Submissions (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT FOREIGN KEY REFERENCES Tasks(TaskID) on delete cascade on update cascade ,
    StudentID char(14) FOREIGN KEY REFERENCES Students(NationalID) ,
    SubmissionLink NVARCHAR(50) NOT NULL,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Tests (
    TestID INT PRIMARY KEY IDENTITY(1,1),
    TotalGrade DECIMAL(5, 2) NOT NULL,
    MadeBy char(14) FOREIGN KEY REFERENCES ApplicationUsers(NationalID) ,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID) on delete cascade on update cascade,
    [Date] DATETIME NOT NULL,
    [Time] TIME NOT NULL,
    [Type] NVARCHAR(50) CHECK ([Type] IN ('Quiz', 'Midterm', 'Final')) NOT NULL,
    Duration INT NOT NULL -- The Test Duration in minutes --                                               
);

CREATE TABLE Questions (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Tests(TestID) on delete cascade on update cascade,
    QuestionNumber INT NOT NULL,
    QuestionText NVARCHAR(MAX) NOT NULL,
    Grade DECIMAL(4, 2) NOT NULL
);

CREATE TABLE TestSubmissions (
    TestSubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Tests(TestID) on delete cascade on update cascade,
    StudentID char(14) FOREIGN KEY REFERENCES Students(NationalID) ,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Timetables (
    TimetableID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID) on delete cascade on update cascade,
    ProfessorID char(14) FOREIGN KEY REFERENCES Professors(ProfessorID) ,
    [Day] NVARCHAR(20) NOT NULL,
    [Time] TIME NOT NULL,
    Duration TIME NOT NULL -- INT OR TIME --
);

CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    [Message] NVARCHAR(50) NOT NULL,
    SentBy char(14) FOREIGN KEY REFERENCES ApplicationUsers(NationalID) ,
    SentTo char(14) FOREIGN KEY REFERENCES ApplicationUsers(NationalID) ,
    /*New Column*/[State] bit NOT NULL -- 0 : Unread | 1 : Read --
);

CREATE TABLE Feedbacks (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    Question NVARCHAR(50) NOT NULL,
    -- SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) 
);

CREATE TABLE FeedbackResponses (
    ResponseID INT PRIMARY KEY IDENTITY(1,1),
    FeedbackID INT FOREIGN KEY REFERENCES Feedbacks(FeedbackID) on delete cascade on update cascade,
    ResponseText NVARCHAR(50) NOT NULL,
    SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Students(NationalID) 
);

CREATE TABLE PasswordResetTickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Students(NationalID) ,
    RequestDate DATETIME NOT NULL,
    ResetDate DATETIME NULL,
    [State] bit NOT NULL , -- Checks if the response was made by any admin or not 
    AdminID char(14) FOREIGN KEY REFERENCES ApplicationUsers(NationalID) on update cascade
);

CREATE TABLE CourseEnrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Students(NationalID) ,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID) on delete cascade on update cascade,
    EnrollmentDate DATETIME NOT NULL ,
	ClassWork decimal(4 , 2) NOT NULL ,
	FinalGrade decimal(4 , 2) NOT NULL ,
	[State] bit -- 0 => The student failed | 1 => The student passed
);

CREATE TABLE CourseTeaching (
    TeachingID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID) on delete cascade on update cascade,
    ProfessorID char(14) NULL FOREIGN KEY REFERENCES Professors(ProfessorID)  ,
    TAID char(14) NULL FOREIGN KEY REFERENCES TeachingAssistants(TAID) 
);

alter table Departments 
add constraint FK_Dept_Head_Prof FOREIGN KEY (HeadID)  REFERENCES Professors(ProfessorID)