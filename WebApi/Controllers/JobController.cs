using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController
{
    private readonly IWebHostEnvironment _environment;
    private readonly JobService _jobService;

    public JobController(IWebHostEnvironment environment, JobService jobService)
    {
        _environment = environment;
        _jobService = jobService;
    }

    [HttpGet("ListJob")]
    public List<JobDto> ListJob()
    {
        return _jobService.ListJob();
    }

    [HttpGet("GetById")]
    public JobDto GetJobById(int Id)
    {
        return _jobService.GetJobById(Id);
    }

    [HttpPost("InsertJob")]
    public JobDto AddJob([FromForm] JobDto job)
    {
        return _jobService.AddJob(job);
    }

    [HttpPut("UpdateJob")]
    public JobDto UpdateJob([FromForm] JobDto job)
    {
        return _jobService.UpdateJob(job);
    }

    [HttpDelete("DeleteJob")]
    public JobDto DeleteJob(JobDto job)
    {
        return _jobService.DeleteJob(job);
    }

    [HttpGet("FiltreJob")]
    public List<JobDto> FiltreJob(string title)
    {
        return _jobService.FiltreJob(title);
    }
}
