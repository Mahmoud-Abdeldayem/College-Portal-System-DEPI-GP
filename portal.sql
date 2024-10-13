Use master
Drop database college_portal_system;

CREATE DATABASE college_portal_system;
USE college_portal_system;


CREATE TABLE ApplicationUser (
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

CREATE TABLE Student (
    NationalID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade on update cascade,
	StudentId nvarchar(15) NOT NULL , -- By Default contains the NationalID , after the student registrain will be ended => the admin chages it to a new one.
    EntryYear Date NOT NULL,
    GradYear Date NULL,
    [CurrentState] bit, -- Pass 0 / Continous 1 NY
    [CollegeState] bit, -- Student 0 / Graduated 1 
    CurrentYear smallint CHECK (CurrentYear IN (1, 2, 3, 4)),
    TotalGPA DECIMAL NULL,
    HoursTaken int NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) on delete set null on update cascade
);

CREATE TABLE TeachingAssistant (
    TAID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade on update cascade ,
    AcademicDegree NVARCHAR(50) NOT NULL,
    University NVARCHAR(50) NOT NULL,
    Faculty NVARCHAR(50) NOT NULL,
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Department(DepartmentID) on delete set default on update cascade ,
    AssistingProfessorID char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) 
);

CREATE TABLE Professor (
    ProfessorID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade on update cascade ,
    PhDAt NVARCHAR(50) NOT NULL,
    EnterYear INT NOT NULL,
    OfficeLocation NVARCHAR(50),
    DocUni NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Department(DepartmentID) on delete set default on update cascade
); 

CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL,
    HeadID char(14) NULL FOREIGN KEY REFERENCES Professor(ProfessorID)
);

CREATE TABLE Course (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    Code nVARCHAR(10) UNIQUE NOT NULL,
    [Hours] INT NOT NULL,
	PrerequisiteCourseId INT FOREIGN KEY REFERENCES Course(CourseID),  
	Semseter bit Not Null , -- The course Semester => 0 = 1st , 1 = 2nd
    CourseLevel INT NOT NULL , ---
    DepartmentID INT Default 1 FOREIGN KEY REFERENCES Department(DepartmentID) on delete set default on update cascade
);

CREATE TABLE Task (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade on update cascade,
    Grade DECIMAL(4 , 2) NOT NULL,
    Deadline DATETIME NOT NULL,
    Content NVARCHAR(50) NOT NULL, -- The Task Link (Like PDF document in Google Drive) --
    [Type] NVARCHAR(50) CHECK ([Type] IN ('Project', 'Assignment')) NOT NULL,
    AssignedByTAID char(14) FOREIGN KEY REFERENCES TeachingAssistant(TAID) 
);

CREATE TABLE Submission (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT FOREIGN KEY REFERENCES Task(TaskID) on delete cascade on update cascade ,
    StudentID char(14) FOREIGN KEY REFERENCES Student(StudentId) ,
    SubmissionLink NVARCHAR(50) NOT NULL,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Test (
    TestID INT PRIMARY KEY IDENTITY(1,1),
    TotalGrade DECIMAL(5, 2) NOT NULL,
    MadeBy char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) ,
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade on update cascade,
    [Date] DATETIME NOT NULL,
    [Time] TIME NOT NULL,
    [Type] NVARCHAR(50) CHECK ([Type] IN ('Quiz', 'Midterm', 'Final')) NOT NULL,
    Duration INT NOT NULL -- The Test Duration in minutes --                                               
);

CREATE TABLE Question (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID) on delete cascade on update cascade,
    QuestionNumber INT NOT NULL,
    QuestionText NVARCHAR(MAX) NOT NULL,
    Grade DECIMAL(4, 2) NOT NULL
);

CREATE TABLE TestSubmission (
    TestSubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID) on delete cascade on update cascade,
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) ,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Timetable (
    TimetableID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade on update cascade,
    ProfessorID char(14) FOREIGN KEY REFERENCES Professor(ProfessorID) ,
    [Day] NVARCHAR(20) NOT NULL,
    [Time] TIME NOT NULL,
    Duration TIME NOT NULL -- INT OR TIME --
);

CREATE TABLE Notification (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    [Message] NVARCHAR(50) NOT NULL,
    SentBy char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) ,
    SentTo char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) ,
    /*New Column*/[State] bit NOT NULL -- 0 : Unread | 1 : Read --
);

CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    Question NVARCHAR(50) NOT NULL,
    -- SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) 
);

CREATE TABLE FeedbackResponse (
    ResponseID INT PRIMARY KEY IDENTITY(1,1),
    FeedbackID INT FOREIGN KEY REFERENCES Feedback(FeedbackID) on delete cascade on update cascade,
    ResponseText NVARCHAR(50) NOT NULL,
    SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) 
);

CREATE TABLE PasswordResetTicket (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) ,
    RequestDate DATETIME NOT NULL,
    ResetDate DATETIME NULL,
    [State] bit NOT NULL , -- Checks if the response was made by any admin or not 
    AdminID char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) on update cascade
);

CREATE TABLE CourseEnrollment (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) ,
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade on update cascade,
    EnrollmentDate DATETIME NOT NULL ,
	ClassWork decimal(4 , 2) NOT NULL ,
	FinalGrade decimal(4 , 2) NOT NULL ,
	[State] bit -- 0 => The student failed | 1 => The student passed
);

CREATE TABLE CourseTeaching (
    TeachingID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade on update cascade,
    ProfessorID char(14) NULL FOREIGN KEY REFERENCES Professor(ProfessorID)  ,
    TAID char(14) NULL FOREIGN KEY REFERENCES TeachingAssistant(TAID) 
);
