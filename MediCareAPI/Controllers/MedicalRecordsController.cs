using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediCareLibrary.Data; 
using MediCareLibrary.Models; 
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

[Route("api/[controller]")]
[EnableCors("AllowOrigin")]
[ApiController]
public class MedicalRecordsController : ControllerBase
{
    private readonly IMedicalRecordsData _db;
    private readonly IWebHostEnvironment _environment;

    public MedicalRecordsController(IMedicalRecordsData db, IWebHostEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    // GET: api/MedicalRecords
    [HttpGet]
    public IEnumerable<MedicalRecord> Get()
    {
        return _db.GetMedicalRecords();
    }

    // GET: api/MedicalRecords/5
    [HttpGet("{id}")]
    public MedicalRecord Get(int id)
    {
        return _db.GetMedicalRecordById(id);
    }

    
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] MedicalRecordViewModel formData)
    {
        if (formData == null)
        {
            return BadRequest("Invalid data");
        }

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(new { Errors = errors });
        }
        try
        {
            
            string filePath = await _db.UploadFileAsync(formData.File);

            MedicalRecord medicalRecord = new MedicalRecord
            {
                MedicalRecordDescription = formData.Description,
                MedicalRecordDate = formData.Date,
                PatientId = formData.PatientID,
                DoctorId = formData.DoctorID,
                FilePath = filePath,


            };

            _db.CreateMedicalRecord(medicalRecord);

            return Ok("Medical record submitted successfully.");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex}");
        }
      

    }



    // PUT: api/MedicalRecords/5
    

    // DELETE: api/MedicalRecords/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _db.DeleteMedicalRecord(id);
            return Ok(new { message = "Medical record deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"An error occurred while deleting the medical record: {ex.Message}" });
        }
    }

}
