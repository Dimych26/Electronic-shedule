# Electronic-shedule
Electronic-shedule using ASP.NET WebAPI

Application consists of subsystems:
1) Schedule creation subsystem (classrooms, groups, teachers, disciplines)
2) Schedule output subsystem (classrooms, groups, teachers)

User Roles: Administrator, Editor, Management, Teacher, Student.

The editor can change the schedule information. 

Management can view the entire schedule for each of the filters (audiences, groups, teachers, disciplines).

Teachers can view their schedule and the schedule of any groups.

The student can only view the group schedule.

An unauthorized user should not have access to the schedule.

Initially, application models were created at the DAL, then using the Code First method was created database, at the same level, repository patterns and unit of work were implemented.

BLL implements all application functionality and uses  Ninject and AutoMapper

PL have controllers, presentation models, uses Ninject, and filter to catch all exceptions

Application has tests, what use NUnit
