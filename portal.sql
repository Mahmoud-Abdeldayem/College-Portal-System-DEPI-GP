Create database college_portal_system;
USE college_portal_system;


CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL,
    HeadID INT NULL -- will reference prof
);

CREATE TABLE Person (
    PersonID INT PRIMARY KEY IDENTITY(1,1),
    RecoveryEmail NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    NationalID NVARCHAR(20) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL, -- Could be 'Admin', 'Student', 'Teaching Assistant', 'Professor'
    Picture VARBINARY(MAX) NULL,
    FirstName nvarchar(50),
	SecondName nvarchar(50),
    ThirdName nvarchar(50),
    LastName nvarchar(50),
);

CREATE TABLE Student (
    StudentID INT PRIMARY KEY FOREIGN KEY REFERENCES Person(PersonID),
    EnterYear INT NOT NULL,
    GradYear INT NULL,
    State NVARCHAR(10) CHECK (State IN ('Passed', 'Failed')),
    CurrentYear INT CHECK (CurrentYear IN (1, 2, 3, 4)),
    TotalGPA DECIMAL(3, 2) NULL, -- Derived
    HoursTaken INT NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID)
);

CREATE TABLE TeachingAssistant (
    TAID INT PRIMARY KEY FOREIGN KEY REFERENCES Person(PersonID),
    AcademicDegree NVARCHAR(50) NOT NULL, -- 'Bachelor', 'Master'
    University NVARCHAR(100) NOT NULL,
    Faculty NVARCHAR(100) NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID),
    AssistingProfessorID INT FOREIGN KEY REFERENCES Person(PersonID) -- References Professor
);

CREATE TABLE Professor (
    ProfessorID INT PRIMARY KEY FOREIGN KEY REFERENCES Person(PersonID),
    PhDAt NVARCHAR(100) NOT NULL, -- Major || Subject
    EnterYear INT NOT NULL,
    OfficeLocation NVARCHAR(100) NOT NULL,
    DocUni NVARCHAR(100) NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID)
);

CREATE TABLE Course (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL,
    Hours INT NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID)
);

CREATE TABLE Task (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    Grade DECIMAL(4, 2) NOT NULL,
    Deadline DATETIME NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    Type NVARCHAR(50) CHECK (Type IN ('Project', 'Assignment')) NOT NULL,
    AssignedByTAID INT FOREIGN KEY REFERENCES TeachingAssistant(TAID)
);

CREATE TABLE Submission (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT FOREIGN KEY REFERENCES Task(TaskID),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    SubmissionLink NVARCHAR(255) NOT NULL,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Test (
    TestID INT PRIMARY KEY IDENTITY(1,1),
    TotalGrade DECIMAL(5, 2) NOT NULL,
    MadeBy INT FOREIGN KEY REFERENCES Person(PersonID), -- Could be TA or Professor
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    Date DATETIME NOT NULL,
    Time TIME NOT NULL,
    Type NVARCHAR(50) CHECK (Type IN ('Quiz', 'Midterm', 'Final')) NOT NULL,
    Duration TIME NOT NULL
);

CREATE TABLE Question (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID),
    QuestionNumber INT NOT NULL,
    QuestionText NVARCHAR(MAX) NOT NULL,
    Grade DECIMAL(4, 2) NOT NULL
);

CREATE TABLE TestSubmission (
    TestSubmissionID INT PRIMARY KEY IDENTITY(1,1),
    TestID INT FOREIGN KEY REFERENCES Test(TestID),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    SubmissionLink NVARCHAR(255) NOT NULL,
    SubmissionDate DATETIME NOT NULL
);

CREATE TABLE Timetable (
    TimetableID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    ProfessorID INT FOREIGN KEY REFERENCES Professor(ProfessorID),
    Day NVARCHAR(20) NOT NULL,
    Time TIME NOT NULL,
    Duration TIME NOT NULL
);

CREATE TABLE Notification (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    Message NVARCHAR(MAX) NOT NULL,
    SentByAdminID INT FOREIGN KEY REFERENCES Person(PersonID)
);

CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    Question NVARCHAR(MAX) NOT NULL,
    SubmittedByStudentID INT FOREIGN KEY REFERENCES Student(StudentID)
);

CREATE TABLE FeedbackResponse (
    ResponseID INT PRIMARY KEY IDENTITY(1,1),
    FeedbackID INT FOREIGN KEY REFERENCES Feedback(FeedbackID),
    ResponseText NVARCHAR(MAX) NOT NULL,
    SubmittedByStudentID INT FOREIGN KEY REFERENCES Student(StudentID)
);

CREATE TABLE PasswordResetTicket (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    RequestDate DATETIME NOT NULL,
    ResetDate DATETIME NULL,
    AdminID INT FOREIGN KEY REFERENCES Person(PersonID)
);

CREATE TABLE CourseEnrollment (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    EnrollmentDate DATETIME NOT NULL
);

CREATE TABLE CourseTeaching (
    TeachingID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    ProfessorID INT NULL FOREIGN KEY REFERENCES Professor(ProfessorID),
    TAID INT NULL FOREIGN KEY REFERENCES TeachingAssistant(TAID)
);

ALTER TABLE Department
ADD CONSTRAINT FK_HeadID_Professor
FOREIGN KEY (HeadID) REFERENCES Professor(ProfessorID);
