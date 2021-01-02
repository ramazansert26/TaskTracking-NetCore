using Microsoft.AspNetCore.Razor.TagHelpers;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getWorkByAppUserId")]
    public class WorksByAppUserIdTagHelper : TagHelper
    {
        private readonly IWorkService _workService;
        public WorksByAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Work> works = _workService.GetByAppUserId(AppUserId);
            int finishedWorkCount = works.Where(I => I.Finished).Count();
            int workInProgressCount = works.Where(I => !I.Finished).Count();

            string htmlString = $"<strong>Tamamlanan Görev Sayısı: </strong><span class='badge badge-pill badge-success'> {finishedWorkCount}</span><br><strong>Devam Eden Görev Sayısı: </strong><span class='badge badge-pill badge-info'> {workInProgressCount}</span>";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
