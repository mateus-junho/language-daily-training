using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Service.Controllers
{
    [Route("api/training-plan")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanAppService trainingPlanAppService;

        public TrainingPlanController(ITrainingPlanAppService trainingPlanAppService)
        {
            this.trainingPlanAppService = trainingPlanAppService;
        }

        [HttpGet(@"{trainingPlanId}")]
        public async Task<ActionResult<TrainingPlanDto>> GetTrainingPlan(Guid trainingPlanId)
        {
            var trainingPlan = await trainingPlanAppService.GetTrainingPlanById(trainingPlanId);

            if (trainingPlan == null)
            {
                return NotFound();
            }

            return Ok(trainingPlan);
        }

        [HttpPut(@"{trainingPlanId}")]
        public async Task<ActionResult> UpdateTrainingPlan(Guid trainingPlanId, TrainingPlanDto trainingPlan)
        {
            if (trainingPlanId != trainingPlan.Id)
            {
                return BadRequest();
            }

            await trainingPlanAppService.UpdateTrainingPlan(trainingPlan);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TrainingPlanDto>> AddTrainingPlan(TrainingPlanDto trainingPlan)
        {
            var savedTrainingPlan = await trainingPlanAppService.AddTrainingPlan(trainingPlan);

            return CreatedAtAction(nameof(GetTrainingPlan), new { trainingPlanId = savedTrainingPlan.Id }, savedTrainingPlan);
        }

        [HttpDelete(@"{trainingPlanId}")]
        public async Task<ActionResult<TrainingPlanDto>> DeleteTrainingPlan(Guid trainingPlanId)
        {
            var deletedTrainingPlan = await trainingPlanAppService.DeleteTrainingPlan(trainingPlanId);

            return Ok(deletedTrainingPlan);
        }

        [HttpPost(@"{trainingPlanId}/sentence")]
        public async Task<ActionResult> AddSentence(Guid trainingPlanId, SentenceDto sentence)
        {
            if (trainingPlanId != sentence.TrainingPlanId)
            {
                return BadRequest();
            }

            await trainingPlanAppService.AddSentence(sentence);

            return Ok();
        }

        [HttpDelete(@"sentence/{sentenceId}")]
        public async Task<ActionResult<TrainingPlanDto>> DeleteTrainingPlan(Guid trainingPlanId, Guid sentenceId)
        {
            await trainingPlanAppService.DeleteSentence(sentenceId);

            return Ok();
        }
    }
}
