using System.ComponentModel.DataAnnotations;
using System.Globalization;

class PatientClass
{
    public Guid PatientId { get; set; } = Guid.NewGuid();
    [Required]
    public string? PatientName { get; set; }
    [Required]
    public string? PatientDOB { get; set; }
    [Required]
    public string? Gender { get; set; }
    [Required]
    public string? PatientContact { get; set; }
    [Required]
    public string? PatientAddress { get; set; }
    [Required]
    public string? MedicalHistory { get; set; }
    [Required]
    public string? Allergies { get; set; }













}