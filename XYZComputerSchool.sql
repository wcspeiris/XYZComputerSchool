CREATE DATABASE XYZComputerSchool;

create table Employees
(
employeeId varchar(10) primary key not null,
password varchar(10) not null,
authorityLevel int not null,
firstName varchar(30) not null,
lastName varchar(30) not null,
address varchar(50) not null,
contactNo varchar(10) not null,
DOB varchar(12) not null,
salary float not null,
emailAddress varchar(30) not null,
addedBy varchar(10) not null,
addedDateTime varchar(25) not null,
constraint fkEmpAddedBy foreign key (addedBy) references Employees (employeeId)
);

create table Students
(
studentId varchar(10) primary key not null,
password varchar(10) not null,
authorityLevel int not null,
firstName varchar(30) not null,
lastName varchar(30) not null,
address varchar(50) not null,
contactNo varchar(10) not null,
DOB varchar(12) not null,
enrolledCourseId varchar(10) not null,
emailAddress varchar(30) not null,
averageMarks float,
addedBy varchar(10) not null,
addedDateTime varchar(25) not null,
constraint fkEnrolledCourseId foreign key (enrolledCourseId) references Courses (courseId),
constraint fkStuAddedBy foreign key (addedBy) references Employees (employeeId),
);

create table Courses
(
courseId varchar(10) primary key not null,
courseName varchar(30) not null,
courseDuration varchar(10) not null,
courseFee float not null,
courseStatus varchar(10) not null,
addedBy varchar(10) not null,
addedDateTime varchar(25) not null,
constraint fkCourseAddedBy foreign key (addedBy) references Employees (employeeId),
);

create table Modules
(
moduleId varchar(10) primary key not null,
moduleName varchar(30) not null,
moduleStatus varchar(10) not null,
addedBy varchar(10) not null,
constraint fkModuleAddedBy foreign key (addedBy) references Employees (employeeId),
);

create table CourseContainModules
(
containCourseId varchar(10) not null,
containModuleId varchar(10) not null,
primary key (containCourseId, containModuleId),
constraint fkContainCouseId foreign key (containCourseId) references Courses (courseId),
constraint fkContainModuleId foreign key (containModuleId) references Modules (moduleId)
);

create table Questions
(
questionId varchar(10) primary key not null,
questionModuleId varchar(10) not null,
question varchar(200) not null,
answer01 varchar(200) not null,
answer02 varchar(200) not null,
answer03 varchar(200) not null,
answer04 varchar(200) not null,
correctAnswer int not null,
managedBy varchar(10) not null,
constraint fkquestionModuleId foreign key (questionModuleId) references Modules (moduleId),
constraint fkQuestionManagedBy foreign key (managedBy) references Employees (employeeId),
);

create table StudentStudy
(
studyStudentId varchar(10) not null,
studyModuleId varchar(10) not null,
examAttempt int not null,
examAttemptedDateTime varchar(25) not null,
examMarks float default 0,
primary key (studyStudentId, studyModuleId, examAttempt),
constraint fkStudyStudentId foreign key (studyStudentId) references Students (studentId),
constraint fkStudyModuleId foreign key (studyModuleId) references Modules (moduleId)
);

create table StudentAnswer
(
answeredStudentId varchar(10) not null,
answeredQuestionId varchar(10) not null,
answerModuleId varchar(10) not null,
questionAttempt int not null,
providedAnswer int not null,
primary key (answeredStudentId, answeredQuestionId, answerModuleId, questionAttempt),
constraint fkAnsweredStudentId foreign key (answeredStudentId) references Students (studentId),
constraint fkAnsweredQuestionId foreign key (answeredQuestionId) references Questions (questionId),
constraint fkAnsweredModuleId foreign key (answerModuleId) references Modules (moduleId),
);
