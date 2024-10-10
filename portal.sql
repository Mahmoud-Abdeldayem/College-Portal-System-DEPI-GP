Use master
Drop database college_portal_system;

CREATE DATABASE college_portal_system;
USE college_portal_system;

CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL,
    HeadID char(14) NULL
);

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
    NationalID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade ,
	StudentId nvarchar(15) NOT NULL , -- By Default contains the NationalID , after the student registrain will be ended => the admin chages it to a new one.
    EntryYear Date NOT NULL,
    GradYear Date NULL,
    [CurrentState] bit, -- Pass 0 / Continous 1 NY
    [CollegeState] bit, -- Student 0 / Graduated 1 
    CurrentYear smallint CHECK (CurrentYear IN (1, 2, 3, 4)),
    TotalGPA DECIMAL NULL,
    HoursTaken int NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) on delete cascade 
);

CREATE TABLE TeachingAssistant (
    TAID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade ,
    AcademicDegree NVARCHAR(50) NOT NULL,
    University NVARCHAR(50) NOT NULL,
    Faculty NVARCHAR(50) NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) on delete set null ,
    AssistingProfessorID char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade
);

CREATE TABLE Professor (
    ProfessorID char(14) PRIMARY KEY FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade ,
    PhDAt NVARCHAR(50) NOT NULL,
    EnterYear INT NOT NULL,
    OfficeLocation NVARCHAR(50),
    DocUni NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) on delete cascade
);

CREATE TABLE Course (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    Code nVARCHAR(10) UNIQUE NOT NULL,
    [Hours] INT NOT NULL,
	PrerequisiteCourseId INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade,  
	Semseter bit Not Null , -- The course Semester => 0 = 1st , 1 = 2nd
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) on delete cascade
);

CREATE TABLE Task (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    Grade DECIMAL(4, 2) NOT NULL,
    Deadline DATETIME NOT NULL,
    Content NVARCHAR(50) NOT NULL,
    Type NVARCHAR(50) CHECK (Type IN ('Project', 'Assignment')) NOT NULL,
    AssignedByTAID char(14) FOREIGN KEY REFERENCES TeachingAssistant(TAID)
);

CREATE TABLE Submission (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT FOREIGN KEY REFERENCES Task(TaskID) on delete cascade,
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade,
    SubmissionLink NVARCHAR(50) NOT NULL,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Test (
    TestID INT PRIMARY KEY IDENTITY(1,1),
    TotalGrade DECIMAL(5, 2) NOT NULL,
    MadeBy char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade,
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade,
    Date DATETIME NOT NULL,
    Time TIME NOT NULL,
    Type NVARCHAR(50) CHECK (Type IN ('Quiz', 'Midterm', 'Final')) NOT NULL,
    Duration TIME NOT NULL
);

CREATE TABLE Question (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID) on delete cascade,
    QuestionNumber INT NOT NULL,
    QuestionText NVARCHAR(MAX) NOT NULL,
    Grade DECIMAL(4, 2) NOT NULL
);

CREATE TABLE TestSubmission (
    TestSubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID) on delete cascade,
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Timetable (
    TimetableID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade,
    ProfessorID char(14) FOREIGN KEY REFERENCES Professor(ProfessorID) on delete cascade,
    [Day] NVARCHAR(20) NOT NULL,
    [Time] TIME NOT NULL,
    Duration TIME NOT NULL
);

CREATE TABLE Notification (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    [Message] NVARCHAR(50) NOT NULL,
    SentByAdminID char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade
);

CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    Question NVARCHAR(50) NOT NULL,
    SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade
);

CREATE TABLE FeedbackResponse (
    ResponseID INT PRIMARY KEY IDENTITY(1,1),
    FeedbackID INT FOREIGN KEY REFERENCES Feedback(FeedbackID) on delete cascade,
    ResponseText NVARCHAR(50) NOT NULL,
    SubmittedByStudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade
);

CREATE TABLE PasswordResetTicket (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade,
    RequestDate DATETIME NOT NULL,
    ResetDate DATETIME NULL,
    AdminID char(14) FOREIGN KEY REFERENCES ApplicationUser(NationalID) on delete cascade
);

CREATE TABLE CourseEnrollment (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID char(14) FOREIGN KEY REFERENCES Student(NationalID) on delete cascade,
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade,
    EnrollmentDate DATETIME NOT NULL ,
	ClassWork decimal(4 , 2) NOT NULL ,
	FinalGrade decimal(4 , 2) NOT NULL ,
	[State] bit -- 0 => The student failed | 1 => The student passed
);

CREATE TABLE CourseTeaching (
    TeachingID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID) on delete cascade,
    ProfessorID char(14) NULL FOREIGN KEY REFERENCES Professor(ProfessorID) on delete cascade,
    TAID char(14) NULL FOREIGN KEY REFERENCES TeachingAssistant(TAID) on delete cascade
);

ALTER TABLE Department
ADD CONSTRAINT FK_HeadID_Professor
FOREIGN KEY (HeadID) REFERENCES Professor(ProfessorID);
