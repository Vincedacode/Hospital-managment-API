interface AppointmentFunctionInterface
{
    public bool ScheduleAppointment(AppointmentClass Bookappointment, List<AppointmentClass> appointdb);

    public AppointmentClass ViewAppointment(Guid Id, List<AppointmentClass> appointdb);

    public bool UpdateAppointment(AppointmentClass Update, List<AppointmentClass> appointdb);

    public bool CancelAppointment(Guid id, List<AppointmentClass> appointdb);







}