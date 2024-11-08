

class Treatmentfunctionimplementation : Treatmentfunctioninterface
{
    public bool Addtreatmentrecord(Treatmentrecordclass treat, List<Treatmentrecordclass> treatdb)
    {
        treatdb.Add(treat);
        return true;
    }

    public bool Deletetreatmentrecord(Guid patientid, List<Treatmentrecordclass> treatdb)
    {
        var treat = treatdb.Contains(treatdb.Where(r => r.Patientid == patientid).First());
        if (treat)
        {
            treatdb.Remove(treatdb.Where(r => r.Patientid == patientid).First());
            return true;
        }
        else
        {
            return false;
        }
    }

    public Treatmentrecordclass Gettreatmentrecord(Guid Patientid, List<Treatmentrecordclass> treatdb)
    {
        return treatdb.Where(r => r.Patientid == Patientid).FirstOrDefault();
    }

    public bool Updatetreatmentrecord(Treatmentrecordclass update, List<Treatmentrecordclass> treatdb)
    {
        var treat = treatdb.Where(r => r.Patientid == update.Patientid).First();
        if (treat != null)
        {
            treatdb.Remove(treatdb.Where(r => r.Patientid == update.Patientid).First());
            treatdb.Add(update);
            return true;
        }
        else
        {
            return false;
        }
    }
}