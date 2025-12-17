using System;
using ModelContextProtocol.Server;

namespace MCP_medlink;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Specialty { get; set; } = "";
    public bool IsAvailable { get; set; }
}
public static class FakeDatabase
{
    public static List<Doctor> Doctors = new()
    {
        new Doctor { Id = 1, Name = "Иван Петров", Specialty = "Терапевт", IsAvailable = true },
        new Doctor { Id = 2, Name = "Анна Смирнова", Specialty = "Невролог", IsAvailable = true },
        new Doctor { Id = 3, Name = "Олег Ким", Specialty = "Хирург", IsAvailable = false }
    };
}
[McpServerToolType]
public class DoctorAvailable
{
    [McpServerTool]
     public static object SearchDoctors(string? specialty = null)
    {
        var doctors = FakeDatabase.Doctors
            .Where(d => d.IsAvailable);

        if (!string.IsNullOrWhiteSpace(specialty))
        {
            doctors = doctors.Where(d =>
                d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase));
        }

        return doctors.Select(d => new
        {
            d.Id,
            d.Name,
            d.Specialty
        }).ToList();
    }
}

