using System;
using Microsoft.AspNetCore.Mvc;
using Streamish.Repositories;
using Streamish.Models;

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
       
            private readonly IUserProfileRepository _userProfileRepository;
            public UserProfileController(IUserProfileRepository userProfileRepository)
            {
                _userProfileRepository = userProfileRepository;
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var video = _userProfileRepository.GetUserProfileByIdWithVideos(id);
                if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
            }


            [HttpPost]
            public IActionResult Post(UserProfile userProfile)
            {
                _userProfileRepository.Add(userProfile);
                return CreatedAtAction("Get", new { id = userProfile.Id }, userProfile);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, UserProfile userProfile)
            {
                if (id != userProfile.Id)
                {
                    return BadRequest();
                }

                _userProfileRepository.Update(userProfile);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _userProfileRepository.Delete(id);
                return NoContent();
            }
        }
    }