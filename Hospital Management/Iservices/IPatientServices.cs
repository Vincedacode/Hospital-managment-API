interface PatientFunctionsInterface
{

    public bool CreatePatient(PatientClass Createnewpatient, List<PatientClass> patientdb);


    public List<PatientClass> Getallpatients(List<PatientClass> patientdb);

    public PatientClass Getpatient(Guid PatientID, List<PatientClass> patientdb);

    public bool UpdatePatient(PatientClass updatepatient, List<PatientClass> patientdb);

    public bool DeletePatient(Guid PatientId, List<PatientClass> patientdb);






}