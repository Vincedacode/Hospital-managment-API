

class AppointmentFunctionImplementation : AppointmentFunctionInterface
{
    public bool CancelAppointment(Guid id, List<AppointmentClass> appointdb)
    {
        var app = appointdb.Contains(appointdb.Where(r => r.AppointmentId == id).First());
        if (app)
        {
            appointdb.Remove(appointdb.Where(r => r.AppointmentId == id).First());
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ScheduleAppointment(AppointmentClass Bookappointment, List<AppointmentClass> appointdb)
    {

        appointdb.Add(Bookappointment);
        return true;

    }

    public bool UpdateAppointment(AppointmentClass Update, List<AppointmentClass> appointdb)
    {
        var app = appointdb.Where(r => r.AppointmentId == Update.AppointmentId).First();
        if (app != null)
        {
            appointdb.Remove(appointdb.Where(r => r.AppointmentId == Update.AppointmentId).First());
            appointdb.Add(Update);
            return true;
        }
        else
        {
            return false;
        }
    }

    public AppointmentClass ViewAppointment(Guid Id, List<AppointmentClass> appointdb)
    {
        return appointdb.Where(r => r.AppointmentId == Id).FirstOrDefault();
    }
}