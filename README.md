# Electronic-shedule
Electronic-shedule using ASP.NET WebAPI

It consists of subsystems:
1) Schedule creation subsystem (classrooms, groups, teachers, disciplines)
2) Schedule output subsystem (classrooms, groups, teachers)
User Roles: Administrator, Editor, Management, Teacher, Student.
The editor can change the schedule information. 
Management can view the entire schedule for each of the filters (audiences, groups, teachers, disciplines).
Teachers can view their schedule and the schedule of any groups.
The student can only view the group schedule.
An unauthorized user should not have access to the schedule.
