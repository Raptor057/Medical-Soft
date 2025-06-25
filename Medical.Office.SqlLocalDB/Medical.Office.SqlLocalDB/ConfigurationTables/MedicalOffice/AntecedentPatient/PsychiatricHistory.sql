CREATE TABLE [dbo].[PsychiatricHistory]
(
	id bigint PRIMARY KEY IDENTITY(1,1),
    IDPatient bigint,
    FamilyHistory BIT,
    FamilyHistoryData varchar(max),
    AffectedAreas varchar(MAX),
    PastAndCurrentTreatments varchar(MAX),
    FamilySocialSupport BIT,
    FamilySocialSupportData varchar(max),
    WorkLifeAspects varchar(MAX),
    SocialLifeAspects varchar(MAX),
    AuthorityRelationship varchar(MAX),
    ImpulseControl VARCHAR(MAX),
    FrustrationManagement VARCHAR(MAX),
    
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_PsychiatricHistory_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
