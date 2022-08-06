﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Seed;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService seedService;
        public SeedController(ISeedService seedService)
        {
            this.seedService = seedService;
        }

        [HttpPost("InitializeSeeder")]
        public async Task<IActionResult> InitializeSeeder()
        {
            try
            {
                var data = await seedService.SeederAsync();
                if (data.Status)
                    return Ok(data);
                return BadRequest(data);
            }
            catch
            {
                throw;
            }
        }
    }
}
