

class StaffFunctionImplentation : StaffFunctionInterface
{
    public bool Deletestaff(Guid doctorid, List<StaffClass> staffdb)
    {
        var staff = staffdb.Contains(staffdb.Where(r => r.DoctorId == doctorid).First());
        if (staff)
        {
            staffdb.Remove(staffdb.Where(r => r.DoctorId == doctorid).First());
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<StaffClass> Getallstaffs(List<StaffClass> staffdb)
    {
        return staffdb.ToList();
    }

    public StaffClass GetoneStaff(Guid DoctorId, List<StaffClass> staffdb)
    {
        return staffdb.Where(r => r.DoctorId == DoctorId).FirstOrDefault();
    }

    public bool RegisterStaff(StaffClass Regstaff, List<StaffClass> staffdb)
    {
        staffdb.Add(Regstaff);
        return true;
    }

    public bool Updatestaff(StaffClass update, List<StaffClass> staffdb)
    {
        var staff = staffdb.Where(r => r.Name == update.Name).First();
        if (staff != null)
        {
            staffdb.Remove(staffdb.Where(r => r.Name == update.Name).First());
            staff = update;
            staffdb.Add(update);
            return true;
        }
        else
        {
            return false;
        }
    }
}