using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Domain;
using MediatR;
using Application.Activities;
using Application;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

         [HttpGet("{id}")] //api/activities/sadagsk
         public async Task<ActionResult<Activity>> GetActivity(Guid id)
         {
             return await Mediator.Send(new Details.Query{Id = id});
         }

         [HttpPost]
         public async Task<IActionResult> CreateActivity(Activity activity)
         {
            await Mediator.Send(new Create.Command{Activity = activity});
             return Ok();
         }


         [HttpPut("{id}")]
         public async Task<IActionResult> EditActivity(Guid id, Activity activity)
         {
             activity.Id = id;
             await Mediator.Send(new Edit.Command{Activity = activity});
             return Ok();
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteActivity(Guid id)
         {
             await Mediator.Send(new Delete.Command{Id = id});
             return Ok();
    }
}
}