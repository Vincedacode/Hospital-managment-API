interface StaffFunctionInterface
{
    public bool RegisterStaff(StaffClass Regstaff, List<StaffClass> staffdb);

    public List<StaffClass> Getallstaffs(List<StaffClass> staffdb);

    public StaffClass GetoneStaff(Guid DoctorId, List<StaffClass> staffdb);

    public bool Updatestaff(StaffClass update, List<StaffClass> staffdb);

    public bool Deletestaff(Guid doctorid, List<StaffClass> staffdb);










}