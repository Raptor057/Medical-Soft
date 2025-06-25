SELECT MAC.[Id]
      ,MAC.[IDPatient]
      ,CONCAT(PD.Name,' ',PD.FathersSurname,' ',PD.MothersSurname) AS [PatientFullName]
      ,PD.Email
      ,PD.PhoneNumber
      ,MAC.[IDDoctor]
      ,CONCAT(D.FirstName,' ',D.LastName) AS [DoctorFullName]
      ,dbo.[UfnToLocalTime](MAC.[AppointmentDateTime]) AS [AppointmentDateTime]
      ,MAC.[ReasonForVisit]
      ,MAC.[AppointmentStatus]
      ,MAC.[Notes]
      ,MAC.[EndOfAppointmentDateTime]
      ,MAC.[CreatedAt]
      ,MAC.[UpdatedAt]
      ,MAC.[TypeOfAppointment]
  FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar]  MAC
  INNER JOIN PatientData PD
  ON PD.ID = MAC.IDPatient
  INNER JOIN Doctors D
  ON MAC.IDDoctor = D.ID
  WHERE MAC.AppointmentStatus = 'Activa' AND MAC.AppointmentDateTime BETWEEN GETUTCDATE()+1 AND DATEADD(HOUR,1,GETUTCDATE()+1)

UPDATE  [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] SET AppointmentDateTime = DATEADD(MINUTE,10,GETUTCDATE()+1)