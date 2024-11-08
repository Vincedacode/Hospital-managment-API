using System.ComponentModel.DataAnnotations;

class StaffClass
{
    public Guid DoctorId { get; set; } = new Guid();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Specialization { get; set; }
    [Required]
    public string? Contact { get; set; }
    [Required]
    public string? Address { get; set; }

    public bool Availability { get; set; }











}