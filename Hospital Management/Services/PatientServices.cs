
class PatientFunctionsImplementation : PatientFunctionsInterface
{
    public bool CreatePatient(PatientClass Createnewpatient, List<PatientClass> patientdb)
    {
        patientdb.Add(Createnewpatient);
        return true;
    }

    public bool DeletePatient(Guid PatientId, List<PatientClass> patientdb)
    {
        var patient = patientdb.Contains(patientdb.Where(r => r.PatientId == PatientId).First());
        if (patient)
        {
            patientdb.Remove(patientdb.Where(r => r.PatientId == PatientId).First());
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<PatientClass> Getallpatients(List<PatientClass> patientdb)
    {
        return patientdb.ToList();
    }

    public PatientClass Getpatient(Guid PatientID, List<PatientClass> patientdb)
    {
        return patientdb.Where(r => r.PatientId == PatientID).FirstOrDefault();

    }

    public bool UpdatePatient(PatientClass updatepatient, List<PatientClass> patientdb)
    {
        var patient = patientdb.Where(r => r.PatientName == updatepatient.PatientName).First();
        if (patient != null)
        {
            patientdb.Remove(patientdb.Where(r => r.PatientName == updatepatient.PatientName).First());
            patient = updatepatient;
            patientdb.Add(updatepatient);
            return true;
        }
        else
        {
            return false;
        }
    }
}