using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartVotingSystem.Data;
using SmartVotingSystem.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SmartVotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingService : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VotingService> _logger;

        public VotingService(ApplicationDBContext context, ILogger<VotingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Parties

        [HttpGet("getparties")]
        public async Task<List<PartiesMaster>> GetElectionParties()
        {
            var getpartylist = await _context.PartiesMasters.ToListAsync();

            return getpartylist;
        }



        [HttpPost("addparty")]
        public async Task<IActionResult> AddElectionParty([FromBody] PartiesMaster request)
        {
            if (request == null)
            {
                return BadRequest("Request Returned Null");
            }

            //else
            //{
            //    await _context.PartiesMasters.AddAsync(request);
            //    await _context.SaveChangesAsync();
            //    return Ok(request);
            //}
            else
            {
                var checkparty = await _context.PartiesMasters.Where(x => x.PartyName == request.PartyName).FirstOrDefaultAsync();
                if (checkparty == null)
                {
                    return BadRequest("Request Returned Null");

                }
                else
                {
                    await _context.PartiesMasters.AddAsync(request);
                    await _context.SaveChangesAsync();
                    return Ok(request);
                }



            }
        }

        [HttpPut("editparty")]
        public async Task<IActionResult> EditElectionParty([FromBody] PartiesMaster pm)
        {
            try
            {
                if (pm.Id == 0)
                {
                    return BadRequest("Request Returned Null");
                }
                else
                {
                    var party = await _context.PartiesMasters.FindAsync(pm.Id);
                    if (party == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        party.PartyType = pm.PartyType;
                        party.PartyName = pm.PartyName;

                        await _context.SaveChangesAsync();
                        return Ok(party);
                    }
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion Parties


        [HttpPost("addvote")]
        public async Task<IActionResult> Vote([FromBody] VoteMaster request)
        {
            if(request == null)
            {
                return BadRequest("Request Returned Null");
            }
            else
            {
                var response = await _context.VoteMasters.AddAsync(request);
                await _context.SaveChangesAsync();

                return Ok(response);
            }
        }

        [HttpGet("getvotes")]
        public async Task<List<VoteMaster>> getVoteList()
        {
            return await _context.VoteMasters.ToListAsync();
        }


    }
}
