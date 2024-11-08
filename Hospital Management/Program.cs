using System.Runtime.Serialization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PatientFunctionsInterface, PatientFunctionsImplementation>();

builder.Services.AddSingleton<StaffFunctionInterface, StaffFunctionImplentation>();

builder.Services.AddSingleton<AppointmentFunctionInterface, AppointmentFunctionImplementation>();

builder.Services.AddSingleton<Treatmentfunctioninterface, Treatmentfunctionimplementation>();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = " Vince Hospital",
        Description = "Welcome to my Hospital Management System",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
       options.RoutePrefix = string.Empty;
   });
}


/// Patient API

List<PatientClass> patientlist = new List<PatientClass>() { new PatientClass { Allergies = "salt", Gender = "male", PatientAddress = "34, upper district", MedicalHistory = "Covid", PatientDOB = "23rd of Nov 1987", PatientContact = "dd2@gmail.com", PatientName = "Mark rogers", PatientId = new Guid() } };

// Register Patient
app.MapPost("v1/registerpatient", (PatientClass newpatient, PatientFunctionsInterface implementpatientfunction) =>
{
    var patient = implementpatientfunction.CreatePatient(newpatient, patientlist);
    if (patient)
    {
        return "Patient Successfully registered!";
    }
    else
    {
        return "Patient Registration failed!";
    }
});

// View All Patients
app.MapGet("v1/viewpatients", (PatientFunctionsInterface implementpatientfunction) =>
{
    return implementpatientfunction.Getallpatients(patientlist);
});

// Get A Patient
app.MapGet("v1/getonepatient", (Guid PatientID, PatientFunctionsInterface implementpatientfunction) =>
{
    return implementpatientfunction.Getpatient(PatientID, patientlist);
});

// Update Patient Details
app.MapPut("/v1/updatepatient", (PatientClass updatepatient, PatientFunctionsInterface implementpatientfunction) =>
{
    var patient = implementpatientfunction.UpdatePatient(updatepatient, patientlist);
    if (patientlist != null)
    {
        return "Patient successfully updated!";
    }
    else
    {
        return "Patient Update failed!";
    }
});

// Delete Patient
app.MapDelete("v1/deletepatient", (Guid PatientId, PatientFunctionsInterface implementpatientfunction) =>
{
    var patient = implementpatientfunction.DeletePatient(PatientId, patientlist);
    if (patient)
    {
        return "Patient successfully deleted!";
    }
    else
    {
        return "Delete Patient failed!";
    }
});


/// Staff API

List<StaffClass> stafflist = new List<StaffClass>() { new StaffClass { Name = "John Meke", DoctorId = new Guid(), Address = "2, Park lane", Contact = "johnm@yahoo.com", Availability = true, Specialization = "Gynecology" } };

// Register new staff
app.MapPost("v1/registerstaff", (StaffClass regstaff, StaffFunctionInterface implementstafffunction) =>
{
    var staff = implementstafffunction.RegisterStaff(regstaff, stafflist);
    if (stafflist != null)
    {
        return "Doctor successfully registered!";
    }
    else
    {
        return "Doctor Registration failed!";
    }
});

// Get all  staffs
app.MapGet("v1/getallstaffs", (StaffFunctionInterface implementstafffunction) =>
{
    return implementstafffunction.Getallstaffs(stafflist);
});

// Get one staff
app.MapGet("v1/getonestaff", (Guid Doctorid, StaffFunctionInterface implementstafffunction) =>
{
    return implementstafffunction.GetoneStaff(Doctorid, stafflist);
});

// Update staff
app.MapPut("v1/updatestaff", (StaffClass update, StaffFunctionInterface implementstafffunction) =>
{
    var staff = implementstafffunction.Updatestaff(update, stafflist);
    if (staff)
    {
        return "Doctor updated successfully!";
    }
    else
    {
        return "Doctor update failed!";
    }
});

// Delete Staff
app.MapDelete("v1/deletestaff", (Guid doctorid, StaffFunctionInterface implementstafffunction) =>
{
    var staff = implementstafffunction.Deletestaff(doctorid, stafflist);
    if (staff)
    {
        return "Doctor deleted successfully!";
    }
    else
    {
        return "Delete doctor failed!";
    }
});


/// Appointment API

List<AppointmentClass> appointmentlist = new List<AppointmentClass>() { new AppointmentClass { Date = DateTime.MaxValue, Status = "Pending" } };

// Schedule Appointment
app.MapPost("v1/scheduleappointment", (AppointmentClass Bookappointment, AppointmentFunctionInterface implementappfunction) =>
{
    var app = implementappfunction.ScheduleAppointment(Bookappointment, appointmentlist);
    if (app)
    {
        return "Appointment booked successfully!";
    }
    else
    {
        return "Booking appointment failed!";
    }
});

// View appointment
app.MapGet("v1/viewappointment", (Guid id, AppointmentFunctionInterface implementappfunction) =>
{
    return implementappfunction.ViewAppointment(id, appointmentlist);
});

// Update appointment
app.MapPut("v1/updateappointment", (AppointmentClass update, AppointmentFunctionInterface implementappfunction) =>
{
    var app = implementappfunction.UpdateAppointment(update, appointmentlist);
    if (app)
    {
        return "Appointment updated successfully!";
    }
    else
    {
        return "Update appointment failed!";
    }
});

// Cancel appointment
app.MapDelete("v1/cancelappointment", (Guid id, AppointmentFunctionInterface implementappfunction) =>
{
    var app = implementappfunction.CancelAppointment(id, appointmentlist);
    if (app)
    {
        return "Appointment canceled successfully!";
    }
    else
    {
        return "Delete appointment failed!";
    }
});


/// Treatment API

List<Treatmentrecordclass> treatrecord = new List<Treatmentrecordclass>() { new Treatmentrecordclass { Date = DateTime.Now, Diagnosis = "Malaria", Doctorid = new Guid(), Patientid = new Guid(), Prescription = ["Paracetamol", "Ampiclox", "Lomartem"], Notes = "Patient did not complete drug dosage", Treatmentrecordid = new Guid() } };

// Add Treatment record
app.MapPost("v1/addtreatmentrecord", (Treatmentrecordclass treat, Treatmentfunctioninterface implementtreatfunction) =>
{
    var mytreat = implementtreatfunction.Addtreatmentrecord(treat, treatrecord);
    if (mytreat)
    {
        return "Treatment record added successfully!";
    }
    else
    {
        return "Adding treatment record failed!";
    }
});

// Get Treatment record
app.MapGet("v1/gettreatmentrecord", (Guid patientid, Treatmentfunctioninterface implementtreatfunction) =>
{
    return implementtreatfunction.Gettreatmentrecord(patientid, treatrecord);
});

// Update Treatment record
app.MapPut("v1/updatetreatmentrecord", (Treatmentrecordclass update, Treatmentfunctioninterface implementtreatfunction) =>
{
    var treat = implementtreatfunction.Updatetreatmentrecord(update, treatrecord);
    if (treat)
    {
        return "Treatment record updated successfully!";
    }
    else
    {
        return "Treatment record updated failed!";
    }
});

// Delete Treatment record
app.MapDelete("v1/deletetreatmentrecord", (Guid Patientid, Treatmentfunctioninterface implementtreatfunction) =>
{
    var treat = implementtreatfunction.Deletetreatmentrecord(Patientid, treatrecord);
    if (treat)
    {
        return "Treatment record deleted successfully!";
    }
    else
    {
        return "Treatment record delete failed!";
    }
});


app.Run();
