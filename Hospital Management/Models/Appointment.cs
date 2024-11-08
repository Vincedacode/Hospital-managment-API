using System.ComponentModel.DataAnnotations;

class AppointmentClass
{
    [Required]
    public Guid AppointmentId { get; set; } = new Guid();
    [Required]
    public Guid PatientId { get; set; } = new Guid();
    [Required]
    public Guid DoctorId { get; set; } = new Guid();
    [Required]
    public DateTime Date { get; set; }

    public string? Status { get; set; }




}