using System.ComponentModel.DataAnnotations;

class Treatmentrecordclass
{
    [Required]
    public Guid Treatmentrecordid { get; set; } = new Guid();
    [Required]
    public Guid Patientid { get; set; } = new Guid();
    [Required]
    public Guid Doctorid { get; set; } = new Guid();
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string? Diagnosis { get; set; }
    [Required]
    public List<String>? Prescription { get; set; }

    public string? Notes { get; set; }













}