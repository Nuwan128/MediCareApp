



if not exists (select 1 from dbo.Users)
begin
	insert into dbo.Users (FirstName,LastName,Password,NIC,Birthday,Email,Address,UserType)
	VALUES ('nuwan', 'pradeep', 'admin123', '123456789V', '1990-05-15', 'nuwan@email.com', '123 Main Street', 'admin'),
       ('chalana', 'shehara', 'doc1', '987654321N', '1985-10-23', 'chalana@email.com', '456 Park Avenue', 'doctor'),
       ('dulisha', 'pathirana', 'patient1', '456789123K', '1995-02-01', 'dulisha@email.com', '789 Maple Street', 'patient'),
       ('danesha', 'sana', 'patient2', '567891234M', '1988-07-12', 'danesha@email.com', '1010 Ocean Boulevard', 'patient'),
       ('hasitha', 'wimrshana', 'doc2', '654321789J', '1977-11-29', 'hasitha@email.com', '555 Pine Street', 'doctor');
end

if not exists (select 1 from dbo.Doctors)
begin
	declare @doctorId1 int
	declare @doctorId2 int

	select @doctorId1 = Id from dbo.Users where (NIC = '987654321N')
	select @doctorId2 = Id from dbo.Users where (NIC = '654321789J')


	insert into dbo.Doctors(Speciality,UserId)
	VALUES ('Cardiology', @doctorId1),
       ('Dermatology', @doctorId2);
	
end

if not exists (select 1 from dbo.Patients)
begin

	declare @patientId1 int
	declare @patientId2 int

	select @patientId1 = Id from dbo.Users where (NIC = '456789123K')
	select @patientId2 = Id from dbo.Users where (NIC = '567891234M')

	insert into dbo.Patients(Height,Weight,UserId)
	VALUES (170.0,160.5, @patientId1),
       (165.25,180, @patientId2);	
end