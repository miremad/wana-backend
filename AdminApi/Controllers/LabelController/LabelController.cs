using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Service.LabelService;

namespace AdminApi.Controllers.LabelController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController: ControllerBase
    {
        private readonly ILabelService labelService;

        public LabelController(ILabelService _labelService)
        {
            labelService = _labelService;
        }

        [HttpGet("getLabels")]
        public async Task<IList<LabelDto>> getLabels()
        {
            return await labelService.getLabels();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<bool> deleteLabel(int id)
        {
            return await labelService.DeleteLabel(id);
        }


    }
}
