using CodeMonkeySpecflowSelenium.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMonkeySpecflowSelenium.Variables
{
    public abstract class StudentAppVariables
    {
        string signInButton = "//*[@id=\"root\"]/nav/div[3]/button";
        string createStudentTab = "//*[@id=\"application-tabs-tab-createStudent\"]";
        string valCreateStudentTab = "//*[@id=\"studentForm\"]/div/div[1]/div[1]/span";


    }
}
