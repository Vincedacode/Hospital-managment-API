interface Treatmentfunctioninterface
{
    public bool Addtreatmentrecord(Treatmentrecordclass treat, List<Treatmentrecordclass> treatdb);

    public Treatmentrecordclass Gettreatmentrecord(Guid Patientid, List<Treatmentrecordclass> treatdb);

    public bool Updatetreatmentrecord(Treatmentrecordclass update, List<Treatmentrecordclass> treatdb);

    public bool Deletetreatmentrecord(Guid patientid, List<Treatmentrecordclass> treatdb);






}