CREATE TABLE [dbo].[NonPathologicalHistory]
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
    IDPatient bigint NOT NULL,
    PhysicalActivity BIT,
    Smoking BIT,
    Alcoholism BIT,
    SubstanceAbuse BIT, -- Uso de otras sustancias (Drogas)
    SubstanceAbuseData varchar(50),
    RecentVaccination BIT, -- Vacuna o Inmunización reciente
    RecentVaccinationData varchar(50),
    Others BIT,
    OthersData varchar(50),
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_NonPathologicalHistory_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
