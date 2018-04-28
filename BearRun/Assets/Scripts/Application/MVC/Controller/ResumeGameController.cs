using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ResumeGameController : Controller
{
    public override void Execute(object data)
    {
        UIResume resume = GetView<UIResume>();
        resume.StartCount();
    }
}
